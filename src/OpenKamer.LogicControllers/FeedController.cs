//
// (c) 2022, Alphons van der Heijden
//
// https://opendata.tweedekamer.nl/documentatie/
// https://opendata.tweedekamer.nl/documentatie/syncfeed-api
//

using System.Xml;

namespace OpenKamer.LogicControllers;


public class FeedController
{
	private static readonly string FEED = "https://gegevensmagazijn.tweedekamer.nl/SyncFeed/2.0/";

	private string DB = @"\\192.168.28.195\f$\gegevensmagazijn";

	public FeedController(string DB)
	{
		this.DB = DB;
	}

	public event EventHandler? OnLog;

	public string LastSkipToken { get; set; }

	private void Log(string message)
	{
		OnLog?.Invoke(message, new EventArgs());
	}


	async public Task SyncFeedAsync(string? skiptoken)
	{
		Log("SyncFeedAsync");

		HttpClient httpclient = new();

		XmlDocument xmlDoc = new();

		string urlFeed = FEED;

		if (string.IsNullOrWhiteSpace(skiptoken) == false)
			urlFeed += "?skiptoken=" + skiptoken;

		if (string.IsNullOrWhiteSpace(skiptoken))
			skiptoken = "empty";

		do
		{
			LastSkipToken = skiptoken;

			Log("Skiptoken: " + skiptoken);

			string FileName = DB + @"\" + skiptoken + ".xml";

			if (File.Exists(FileName))
			{
				Log("Cached");

				xmlDoc.Load(FileName);
			}
			else
			{
				var xml = await httpclient.GetStringAsync(urlFeed);

				await File.WriteAllTextAsync(FileName, xml);

				Log("Saved");

				xmlDoc.LoadXml(xml);
			}

			XmlNamespaceManager nsmgr = new(xmlDoc.NameTable);
			if (xmlDoc.DocumentElement != null)
				nsmgr.AddNamespace("ns", xmlDoc.DocumentElement.NamespaceURI);

			if (nsmgr == null)
			{
				Log("XmlNamespaceManager missing");
				return;
			}

			var resumeNode = xmlDoc.SelectSingleNode("/ns:feed/ns:link[@rel='resume']", nsmgr);

			if(resumeNode != null)
			{
				Log("Resume exit");
				return;
			}

			var nextNode = xmlDoc.SelectSingleNode("/ns:feed/ns:link[@rel='next']", nsmgr);

			if (nextNode == null)
			{
				Log("Normal exit");
				return;
			}

			if (nextNode.Attributes == null)
			{
				Log("Abnormal Attributes exit");
				return;
			}

			var attr = nextNode.Attributes["href"];

			if (attr == null)
			{
				Log("Abnormal href exit");
				return;
			}

			urlFeed = attr.Value;

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

			skiptoken = urlFeed[(intI + 10)..];

		} while (!string.IsNullOrWhiteSpace(skiptoken));

		Log("Abnormal empty skiptoken exit");
	}
}
