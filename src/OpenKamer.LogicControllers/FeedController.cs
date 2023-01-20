//
// (c) 2022,2023 Alphons van der Heijden
//
// https://opendata.tweedekamer.nl/documentatie/
// https://opendata.tweedekamer.nl/documentatie/syncfeed-api
//

using MongoDB.MvcCore;
using System.Xml.Linq;

namespace OpenKamer.LogicControllers;

public class FeedController
{
	private static readonly string FEED = "https://gegevensmagazijn.tweedekamer.nl/SyncFeed/2.0/";

	private string FilesDirectory;

	public FeedController(string FilesDirectory, string Token)
	{
		this.FilesDirectory = FilesDirectory;
		this.Token = Token;
		this.Status = string.Empty;
	}

	public event EventHandler? OnLog;

	public string Status { get; set; }

	public string Token { get; set; }

	public int FilesTotal { get; set; }

	public int FilesIndex { get; set; }

	private void Log(string message)
	{
		OnLog?.Invoke(message, new EventArgs());
	}

	async public Task SyncFeedAsync(CancellationToken cancellationToken)
	{
		Log($"MongoDB.MvcCore.BsonJsonSerializer: {typeof(BsonJsonSerializer).Assembly.GetName().Version}");

		Log("SyncFeedAsync");

		HttpClient httpclient = new();

		XDocument xDoc;

		XNamespace ns = "http://www.w3.org/2005/Atom";

		string? urlFeed = FEED;

		if (string.IsNullOrWhiteSpace(Token) == false)
			urlFeed += "?skiptoken=" + this.Token;

		if (string.IsNullOrWhiteSpace(this.Token))
			this.Token = "0";

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
			var FileName = FilesDirectory + @"\" + this.Token + ".xml";

			if (File.Exists(FileName))
			{
				Status = "cached";
			}
			else
			{
				var xml = await httpclient.GetStringAsync(urlFeed, cancellationToken);

				await File.WriteAllTextAsync(FileName, xml, cancellationToken);

				Status = "saved";
			}

			var textReader = File.OpenText(FileName);

			xDoc = await XDocument.LoadAsync(textReader, LoadOptions.None, cancellationToken);

			textReader.Dispose();

			var links = xDoc.Descendants(ns + "link");

			var nodeSelf = links.FirstOrDefault(x => x.Attribute("rel")?.Value == "self");

			var urlSelf = nodeSelf?.Attribute("href")?.Value;

			var nodeResume = links.FirstOrDefault(x => x.Attribute("rel")?.Value == "resume");

			var nodeNext = links.FirstOrDefault(x => x.Attribute("rel")?.Value == "next");

			urlFeed = nodeNext?.Attribute("href")?.Value;

			if(urlSelf == null)
			{
				Log("Self error, exit");
				return;
			}

			if(this.Token!= "0" && !urlSelf.EndsWith(this.Token))
			{
				Log("Incomplete, exit");
				return;
			}

			if (nodeResume != null)
			{
				if (Status == "cached")
				{
					File.Delete(FileName);
					continue;
				}
				if (Status == "saved")
				{
					Log("Resume exit");
					return;
				}
			}

			if (nodeNext == null)
			{
				Log("Normal exit");
				return;
			}

			if (urlFeed == null)
			{
				Log("Abnormal feed exit");
				return;
			}

			var intI = urlFeed.IndexOf("skiptoken=");
			if (intI < 0)
			{
				Log("Abnormal skiptoken exit");
				return;
			}

			this.Token = urlFeed[(intI + 10)..];

			this.FilesIndex++;

		} while (!string.IsNullOrWhiteSpace(this.Token));

		Log("Abnormal empty skiptoken exit");
	}
}
