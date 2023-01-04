//
// (c) 2022, Alphons van der Heijden
//
// https://opendata.tweedekamer.nl/documentatie/
// https://opendata.tweedekamer.nl/documentatie/syncfeed-api
//

using System.Xml.Linq;

namespace OpenKamer.LogicControllers;

public class FeedController
{
	private static readonly string FEED = "https://gegevensmagazijn.tweedekamer.nl/SyncFeed/2.0/";

	private string DB = @"\\192.168.28.195\f$\gegevensmagazijn";

	public FeedController(string DB, string skipToken)
	{
		this.DB = DB;
		this.SkipToken = skipToken;
		this.Status = string.Empty;
	}

	public event EventHandler? OnLog;

	public string Status { get; set; }

	public string SkipToken { get; set; }

	public int FileCount { get; set; }

	private void Log(string message)
	{
		OnLog?.Invoke(message, new EventArgs());
	}

	async public Task SyncFeedAsync(CancellationToken cancellationToken)
	{
		Log("SyncFeedAsync");

		HttpClient httpclient = new();

		XDocument xDoc;

		XNamespace ns = "http://www.w3.org/2005/Atom";

		string? urlFeed = FEED;

		this.FileCount = 0;

		if (string.IsNullOrWhiteSpace(SkipToken) == false)
			urlFeed += "?skiptoken=" + this.SkipToken;

		if (string.IsNullOrWhiteSpace(this.SkipToken))
			this.SkipToken = "0";

		do
		{
			this.FileCount++;

			var FileName = DB + @"\" + this.SkipToken + ".xml";

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

			this.SkipToken = urlFeed[(intI + 10)..];

		} while (!string.IsNullOrWhiteSpace(this.SkipToken));

		Log("Abnormal empty skiptoken exit");
	}
}
