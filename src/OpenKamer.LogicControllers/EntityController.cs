//
// (c) 2022, Alphons van der Heijden
//
// https://opendata.tweedekamer.nl/documentatie/
//

using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;

using nl.tweedekamer.opendata.DataModel;


namespace OpenKamer.LogicControllers;

public class EntityController
{

	private readonly string DB;
	public EntityController(string DB)
	{
		this.DB = DB;
	}

	public delegate Task AsyncEventHandler(object sender, EventArgs e);

	public event AsyncEventHandler? OnEntity;

	public event EventHandler? OnLog;

	private void Log(string message)
	{
		OnLog?.Invoke(message, new EventArgs());
	}

	async public Task DecodeEntriesAsync(string? skiptoken)
	{
		Log("DecodeEntriesAsync");

		XmlSerializer serializer = new(typeof(Feed));

		if (string.IsNullOrWhiteSpace(skiptoken))
			skiptoken = "empty";

		do
		{
			Log("Skiptoken: " + skiptoken);

			string FileName = DB + @"\" + skiptoken + ".xml";

			using StreamReader reader = new(FileName);

			var feed = (Feed?)serializer.Deserialize(reader);

			if (feed == null)
			{
				Log("no valid feed exit");
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
				skiptoken = nextNode.Href[(intI + 10)..];

			await ProcessEntitiesAsync2(feed);

		} while (!string.IsNullOrWhiteSpace(skiptoken));

		Log("Abnormal empty skiptoken exit");
	}

	async private Task<T?> GetEntityAsync<T>(XmlNode xmlNode)
	{
		XmlSerializer serializer = new(typeof(T));

		if (xmlNode.Name == "ns1:verslag") // referentieLiteral unknown type
			xmlNode.InnerXml = xmlNode.InnerXml.Replace("xsi:type=\"ns1:referentieLiteral\"", string.Empty);

		try
		{
			var result = (T?)serializer.Deserialize(new XmlNodeReader(xmlNode));
			if(result != null && OnEntity != null)
				await OnEntity.Invoke(result, new EventArgs());
			return result;
		}
		catch (Exception eeee)
		{
			Debug.WriteLine(eeee.ToString());
			Debug.WriteLine(xmlNode.OuterXml);
			return default;
		}
	}

	#pragma warning disable IDE0059

	async private Task ProcessEntitiesAsync2(Feed feed)
	{

		var entries = feed.Entries;

		if (entries == null)
		{
			Log("no entries found");
			return;
		}

		foreach (var entry in entries)
		{
			if (entry.Content.FirstChild == null)
				continue;

			switch (entry.Category.Term)
			{
				default:
					Log($"Unknown Category {entry.Category.Term}");
					break;
				case "zaal":
					var zaal = await GetEntityAsync<zaalType>(entry.Content.FirstChild);
					break;
				case "reservering":
					var reservering = await GetEntityAsync<reserveringType>(entry.Content.FirstChild);
					break;
				case "vergadering":
					var vergadering = await GetEntityAsync<vergaderingType>(entry.Content.FirstChild);
					break;
				case "verslag":
					var verslag = await GetEntityAsync<verslagType>(entry.Content.FirstChild);
					break;
				case "activiteit":
					var activiteit = await GetEntityAsync<activiteitType>(entry.Content.FirstChild);
					break;
				case "documentVersie":
					var documentversie = await GetEntityAsync<documentVersieType>(entry.Content.FirstChild);
					break;
				case "document":
					var document = await GetEntityAsync<documentType>(entry.Content.FirstChild); // document.Soort == "Motie"
					break;
				case "zaak":
					var zaak = await GetEntityAsync<zaakType>(entry.Content.FirstChild);
					break;
				case "agendapunt":
					var agendapunt = await GetEntityAsync<agendapuntType>(entry.Content.FirstChild);
					break;
				case "besluit":
					var besluit = await GetEntityAsync<besluitType>(entry.Content.FirstChild);
					break;
				case "kamerstukdossier":
					var kamerstukdossier = await GetEntityAsync<kamerstukdossierType>(entry.Content.FirstChild);
					break;
				case "activiteitActor":
					var activiteitActor = await GetEntityAsync<activiteitActorType>(entry.Content.FirstChild);
					break;
				case "zaakActor":
					var zaakActor = await GetEntityAsync<zaakActorType>(entry.Content.FirstChild);
					break;
				case "documentActor":
					var documentActor = await GetEntityAsync<documentActorType>(entry.Content.FirstChild);
					break;
				case "stemming":
					var stemming = await GetEntityAsync<stemmingType>(entry.Content.FirstChild);
					break;
				case "persoon":
					var persoon = await GetEntityAsync<persoonType>(entry.Content.FirstChild);
					break;
				case "fractie":
					var fractie = await GetEntityAsync<fractieType>(entry.Content.FirstChild);
					break;
				case "persoonNevenfunctie":
					var persoonNevenfunctie = await GetEntityAsync<persoonNevenfunctieType>(entry.Content.FirstChild);
					break;
				case "commissie":
					var commissie = await GetEntityAsync<commissieType>(entry.Content.FirstChild);
					break;
				case "persoonGeschenk":
					var persoonGeschenk = await GetEntityAsync<persoonGeschenkType>(entry.Content.FirstChild);
					break;
				case "persoonReis":
					var persoonReis = await GetEntityAsync<persoonReisType>(entry.Content.FirstChild);
					break;
				case "persoonLoopbaan":
					var persoonLoopbaan = await GetEntityAsync<persoonLoopbaanType>(entry.Content.FirstChild);
					break;
				case "persoonOnderwijs":
					var persoonOnderwijs = await GetEntityAsync<persoonOnderwijsType>(entry.Content.FirstChild);
					break;
				case "commissieZetel":
					var commissieZetel = await GetEntityAsync<commissieZetelType>(entry.Content.FirstChild);
					break;
				case "commissieZetelVastPersoon":
					var commissieZetelVastPersoon = await GetEntityAsync<commissieZetelVastPersoonType>(entry.Content.FirstChild);
					break;
				case "commissieZetelVervangerVacature":
					var commissieZetelVervangerVacature = await GetEntityAsync<commissieZetelVervangerVacatureType>(entry.Content.FirstChild);
					break;
				case "commissieZetelVervangerPersoon":
					var commissieZetelVervangerPersoon = await GetEntityAsync<commissieZetelVervangerPersoonType>(entry.Content.FirstChild);
					break;
				case "commissieZetelVastVacature":
					var commissieZetelVastVacature = await GetEntityAsync<commissieZetelVastVacatureType>(entry.Content.FirstChild);
					break;
				case "fractieZetel":
					var fractieZetel = await GetEntityAsync<fractieZetelType>(entry.Content.FirstChild);
					break;
				case "fractieZetelPersoon":
					var fractieZetelPersoon = await GetEntityAsync<fractieZetelPersoonType>(entry.Content.FirstChild);
					break;
				case "fractieZetelVacature":
					var fractieZetelVacature = await GetEntityAsync<fractieZetelVacatureType>(entry.Content.FirstChild);
					break;
				case "persoonNevenfunctieInkomsten":
					var persoonNevenfunctieInkomsten = await GetEntityAsync<persoonNevenfunctieInkomstenType>(entry.Content.FirstChild);
					break;
				case "commissieContactinformatie":
					var commissieContactinformatie = await GetEntityAsync<commissieContactinformatieType>(entry.Content.FirstChild);
					break;
				case "persoonContactinformatie":
					var persoonContactinformatie = await GetEntityAsync<persoonContactinformatieType>(entry.Content.FirstChild);
					break;
			}
		}

		//Log($"{entries.Length}");
	}

#pragma warning restore IDE0059



}
