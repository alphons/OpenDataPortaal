//
// (c) 2022, Alphons van der Heijden
//

// nuget MongoDB.MvcCore

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.MvcCore;

using System.Diagnostics;

using OpenKamer.LogicControllers;

namespace OpenKamer.WinForm
{
    public partial class Form1 : Form
	{
		private IMongoDatabase? db;

		private Stopwatch? sw;
		private long lngError;
		private long lngCount;

		public Form1()
		{
			InitializeComponent();

			this.Text += $" (MongoDB.MvcCore.BsonJsonSerializer: {typeof(BsonJsonSerializer).Assembly.GetName().Version})";
		}

		private void OnLog(object? sender, EventArgs e)
		{
			Log(string.Empty+sender);
		}

		private void Log(string line)
		{
			this.textBox1.Invoke((MethodInvoker)delegate
			{
				this.textBox1.AppendText(line + Environment.NewLine);
			});
		}

		async private void Button1_Click(object sender, EventArgs e)
		{
			this.groupBox1.Enabled = false;

			FeedController feedController = new(this.txtDbFileSystem.Text);

			feedController.OnLog += OnLog;

			await feedController.SyncFeedAsync(this.txtSkipToken.Text); // whitespace tot build DB

			this.txtSkipToken.Text = feedController.LastSkipToken;

			this.groupBox1.Enabled = true;
		}

		async private void Button2_Click(object sender, EventArgs e)
		{
			this.groupBox1.Enabled = false;

			MongoClient mongo = new(this.txtMongoConnectionString.Text);
			this.db = mongo.GetDatabase(this.txtDbName.Text);

			this.lngCount = 0;
			this.lngError = 0;

			this.sw = Stopwatch.StartNew();
			this.timer1.Start();

			EntityController entityController = new(this.txtDbFileSystem.Text);
			entityController.OnLog += OnLog;
			entityController.OnEntity += EntityController_OnEntity;
			await entityController.DecodeEntriesAsync(this.txtSkipToken.Text); // whitespace tot start from beginning

			this.timer1.Stop();

			this.groupBox1.Enabled = true;
		}

		/// <summary>
		/// Replacing (or adding) entity to mongo db
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="e"></param>
		/// <returns></returns>
		async private Task EntityController_OnEntity(object entity, EventArgs e)
		{
			if (db == null)
				return;

			var collection = this.db.GetCollection(entity.GetType().Name);

			if (collection == null)
				return;

			try
			{
				var replaceOneResult = await collection.ReplaceOneByIdAsync(entity);
				this.lngCount++;
			}
			catch (BsonSerializationException)
			{
				this.lngError++;
			}
			catch (MongoWriteException)
			{
				this.lngError++;
			}
			catch (Exception)
			{
				this.lngError++;
			}
		}

		private void Timer1_Tick(object sender, EventArgs e)
		{
			this.lblCount.Text = this.lngCount.ToString();
			this.lblErrors.Text = this.lngError.ToString();

			if (this.sw == null)
				return;

			var speed = (1000 * this.lngCount) / this.sw.ElapsedMilliseconds;

			this.lblSpeed.Text = $"{speed} e/sec";

		}

		private void Form1_Load(object sender, EventArgs e)
		{
			var last = Directory.GetFileSystemEntries(this.txtDbFileSystem.Text, "*.xml")
				.Select(x => long.Parse(Path.GetFileNameWithoutExtension(x)))
				.ToList()
				.OrderByDescending(x => x)
				.FirstOrDefault();
			this.txtSkipToken.Text = last.ToString();
		}
	}
}