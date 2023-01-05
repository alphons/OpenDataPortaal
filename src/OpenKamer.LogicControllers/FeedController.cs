//
// (c) 2022, Alphons van der Heijden
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
			.Select(x => Path.GetFileNameWithoutExtension(x))
			.ToList();

		this.FilesTotal = list.Count;
		this.FilesIndex = list.IndexOf(this.Token);

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

			using var textReader = File.OpenText(FileName);

			xDoc = await XDocument.LoadAsync(textReader, LoadOptions.None, cancellationToken);

			var links = xDoc.Descendants(ns + "link");

			var resumeNode = links.FirstOrDefault(x => x.Attribute("rel")?.Value == "resume");

			if(resumeNode != null)
			{
				Log("Resume exit");
				return;
			}

			var nextNode = links.FirstOrDefault(x => x.Attribute("rel")?.Value == "next");

			if (nextNode == null)
			{
				Log("Normal exit");
				return;
			}

			urlFeed = nextNode.Attribute("href")?.Value;

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
