//
// (c) 2022, Alphons van der Heijden
//
// https://opendata.tweedekamer.nl/documentatie/
//

using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;

// nuget MongoDB.MvcCore

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.MvcCore;

using nl.tweedekamer.opendata.DataModel;


namespace OpenKamer.LogicControllers;

public class EntityController
{
	private readonly IMongoDatabase mongodb;

	private readonly string FilesDirectory;
	public string Token { get; set; }
	public int FilesTotal { get; set; }
	public int FilesIndex { get; set; }
	public int EntityCount { get; set; }
	public int Error { get; set; }

	public event EventHandler? OnLog;

	public EntityController(string MongoConnectionString, string MongoDbName, string FilesDirectory, string token)
	{
		this.FilesDirectory = FilesDirectory;

		this.Token = token;

		this.FilesIndex = 0;

		this.EntityCount = 0;

		this.Error = 0;

		var mongoClient = new MongoClient(MongoConnectionString);

		this.mongodb = mongoClient.GetDatabase(MongoDbName);
	}

	private void Log(string message)
	{
		OnLog?.Invoke(message, new EventArgs());
	}

	async public Task DecodeEntriesAsync(CancellationToken cancellationToken)
	{
		Log($"MongoDB.MvcCore.BsonJsonSerializer: {typeof(BsonJsonSerializer).Assembly.GetName().Version}");

		Log("DecodeEntriesAsync");

		XmlSerializer serializer = new(typeof(Feed));

		if (string.IsNullOrWhiteSpace(Token))
			Token = "0";

		var list = Directory
			.GetFiles(this.FilesDirectory, "*.xml")
			.Select(x => long.Parse(Path.GetFileNameWithoutExtension(x)))
			.OrderBy(x => x)
			.Select(x => x.ToString())
			.ToList();

		this.FilesIndex = 0;
		this.FilesTotal = list.Count - list.IndexOf(this.Token);

		list.Clear();
		GC.Collect();

		do
		{
			var FileName = FilesDirectory + @"\" + Token + ".xml";

			using StreamReader reader = new(FileName);

			var feed = (Feed?)serializer.Deserialize(reader);

			if (feed == null)
			{
				Log("No valid feed exit");
				return;
			}

			var resumeNode = feed.Links.FirstOrDefault(x => x.Rel == "resume");
			if (resumeNode != null)
			{
				Log("Resume (not complete) exit");
				return;
			}

			var nextNode = feed.Links.FirstOrDefault(x => x.Rel == "next");
			if (nextNode == null || nextNode.Href == null)
			{
				Log("Normal exit");
				return;
			}

			var intI = nextNode.Href.IndexOf("skiptoken=");
			if (intI < 0)
			{
				Log("Abnormal skiptoken exit");
				return;
			}
			if (intI > 0)
				Token = nextNode.Href[(intI + 10)..];

			await ProcessEntitiesAsync(feed, cancellationToken);

			if (cancellationToken.IsCancellationRequested)
				return;

			this.FilesIndex++;

			await Task.Delay(100, cancellationToken);

		} while (!string.IsNullOrWhiteSpace(Token));

		Log("Abnormal empty skiptoken exit");
	}

	async private Task ReplaceEntityByIdAsync(object entity, CancellationToken cancellationToken)
	{
		var collection = this.mongodb.GetCollection(entity.GetType().Name);

		if (collection == null)
			return;

		try
		{
			var replaceOneResult = await collection.ReplaceOneByIdAsync(entity, cancellationToken);
			
			this.EntityCount++;
		}
		catch (BsonSerializationException)
		{
			this.Error++;
		}
		catch (MongoWriteException)
		{
			this.Error++;
		}
		catch (Exception)
		{
			this.Error++;
		}
	}

	async private Task<T?> GetEntityAsync<T>(XmlNode xmlNode, CancellationToken cancellationToken)
	{
		XmlSerializer serializer = new(typeof(T));

		if (xmlNode.Name == "ns1:verslag") // referentieLiteral unknown type
			xmlNode.InnerXml = xmlNode.InnerXml.Replace("xsi:type=\"ns1:referentieLiteral\"", string.Empty);

		try
		{
			var result = (T?)serializer.Deserialize(new XmlNodeReader(xmlNode));
			if(result != null)
				await ReplaceEntityByIdAsync(result, cancellationToken);
			return result;
		}
		catch(OperationCanceledException)
		{
			return default;
		}
		catch (Exception eeee)
		{
			Debug.WriteLine(eeee.ToString());
			Debug.WriteLine(xmlNode.OuterXml);
			return default;
		}
	}

	#pragma warning disable IDE0059

	async private Task ProcessEntitiesAsync(Feed feed, CancellationToken cancellationToken)
	{
		var entries = feed.Entries;

		if (entries == null)
		{
			Log("no entries found");
			return;
		}

		foreach (var entry in entries)
		{
			if (cancellationToken.IsCancellationRequested)
				break;

			if (entry.Content.FirstChild == null)
				continue;

			switch (entry.Category.Term)
			{
				default:
					Log($"Unknown Category {entry.Category.Term}");
					break;
				case "zaal":
					var zaal = await GetEntityAsync<zaalType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "reservering":
					var reservering = await GetEntityAsync<reserveringType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "vergadering":
					var vergadering = await GetEntityAsync<vergaderingType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "verslag":
					var verslag = await GetEntityAsync<verslagType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "activiteit":
					var activiteit = await GetEntityAsync<activiteitType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "documentVersie":
					var documentversie = await GetEntityAsync<documentVersieType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "document":
					var document = await GetEntityAsync<documentType>(entry.Content.FirstChild, cancellationToken); // document.Soort == "Motie"
					break;
				case "zaak":
					var zaak = await GetEntityAsync<zaakType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "agendapunt":
					var agendapunt = await GetEntityAsync<agendapuntType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "besluit":
					var besluit = await GetEntityAsync<besluitType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "kamerstukdossier":
					var kamerstukdossier = await GetEntityAsync<kamerstukdossierType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "activiteitActor":
					var activiteitActor = await GetEntityAsync<activiteitActorType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "zaakActor":
					var zaakActor = await GetEntityAsync<zaakActorType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "documentActor":
					var documentActor = await GetEntityAsync<documentActorType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "stemming":
					var stemming = await GetEntityAsync<stemmingType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "persoon":
					var persoon = await GetEntityAsync<persoonType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "fractie":
					var fractie = await GetEntityAsync<fractieType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "persoonNevenfunctie":
					var persoonNevenfunctie = await GetEntityAsync<persoonNevenfunctieType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "commissie":
					var commissie = await GetEntityAsync<commissieType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "persoonGeschenk":
					var persoonGeschenk = await GetEntityAsync<persoonGeschenkType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "persoonReis":
					var persoonReis = await GetEntityAsync<persoonReisType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "persoonLoopbaan":
					var persoonLoopbaan = await GetEntityAsync<persoonLoopbaanType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "persoonOnderwijs":
					var persoonOnderwijs = await GetEntityAsync<persoonOnderwijsType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "commissieZetel":
					var commissieZetel = await GetEntityAsync<commissieZetelType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "commissieZetelVastPersoon":
					var commissieZetelVastPersoon = await GetEntityAsync<commissieZetelVastPersoonType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "commissieZetelVervangerVacature":
					var commissieZetelVervangerVacature = await GetEntityAsync<commissieZetelVervangerVacatureType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "commissieZetelVervangerPersoon":
					var commissieZetelVervangerPersoon = await GetEntityAsync<commissieZetelVervangerPersoonType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "commissieZetelVastVacature":
					var commissieZetelVastVacature = await GetEntityAsync<commissieZetelVastVacatureType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "fractieZetel":
					var fractieZetel = await GetEntityAsync<fractieZetelType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "fractieZetelPersoon":
					var fractieZetelPersoon = await GetEntityAsync<fractieZetelPersoonType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "fractieZetelVacature":
					var fractieZetelVacature = await GetEntityAsync<fractieZetelVacatureType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "persoonNevenfunctieInkomsten":
					var persoonNevenfunctieInkomsten = await GetEntityAsync<persoonNevenfunctieInkomstenType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "commissieContactinformatie":
					var commissieContactinformatie = await GetEntityAsync<commissieContactinformatieType>(entry.Content.FirstChild, cancellationToken);
					break;
				case "persoonContactinformatie":
					var persoonContactinformatie = await GetEntityAsync<persoonContactinformatieType>(entry.Content.FirstChild, cancellationToken);
					break;
			}
		}
	}

#pragma warning restore IDE0059



}
