//
// (c) 2022, Alphons van der Heijden
//
using System.Diagnostics;

using OpenKamer.LogicControllers;

namespace OpenKamer.WinForm;

public partial class Form1 : Form
{
	private Stopwatch? sw;

	private CancellationTokenSource? cancelSource;

	private EntityController? entityController1;
	private FeedController? feedController1;

	public Form1()
	{
		InitializeComponent();

		//this.Text += $" (MongoDB.MvcCore.BsonJsonSerializer: {typeof(BsonJsonSerializer).Assembly.GetName().Version})";
	}

	private void OnLog(object? sender, EventArgs e)
	{
		Log(sender + Environment.NewLine);
	}

	private void Log(string line)
	{
		this.textBox1.Invoke((MethodInvoker)delegate
		{
			this.textBox1.AppendText(line);
		});
	}

	private void Form1_Load(object sender, EventArgs e)
	{
		var lastXml = Directory.GetFileSystemEntries(this.txtDbFileSystem.Text, "*.xml")
			.OrderByDescending(x => x)
			.ToList()
			.FirstOrDefault();

		if (lastXml == null)
			return;

		var last = long.Parse(Path.GetFileNameWithoutExtension(lastXml));
		this.txtSkipToken.Text = last.ToString();
	}

	private void ButtonStop_Click(object sender, EventArgs e)
	{
		this.cancelSource?.Cancel();

		this.ButtonStop.Enabled = false;
		this.groupBox1.Enabled = true;
	}


	async private void Button1_Click(object sender, EventArgs e)
	{
		this.cancelSource = new();

		this.groupBox1.Enabled = false;

		this.ButtonStop.Enabled = true;

		this.lblErrors.Text = "0";

		this.progressBar1.Value = 0;

		// txtSkipToken whitespace tot start from 0
		this.feedController1 = new FeedController(this.txtDbFileSystem.Text, this.txtSkipToken.Text);

		this.feedController1.OnLog += OnLog;

		this.sw = Stopwatch.StartNew();
		this.timer2.Start();

		try
		{
			await this.feedController1.SyncFeedAsync(cancelSource.Token);
		}
		catch(OperationCanceledException)
		{

		}

		this.timer2.Stop();

		this.txtSkipToken.Text = this.feedController1.SkipToken;

		this.ButtonStop.Enabled = false;

		this.groupBox1.Enabled = true;

		this.labelStatus.Text = "...";

		this.progressBar1.Value = 0;
	}

	async private void Button2_Click(object sender, EventArgs e)
	{
		this.labelStatus.Text = "...";

		this.progressBar1.Value = 0;

		this.cancelSource = new();

		this.groupBox1.Enabled = false;

		this.ButtonStop.Enabled = true;

		this.sw = Stopwatch.StartNew();
		this.timer1.Start();

		// txtSkipToken whitespace tot start from beginning
		this.entityController1 = new EntityController(this.txtMongoConnectionString.Text, this.txtDbName.Text, this.txtDbFileSystem.Text, this.txtSkipToken.Text);
		this.entityController1.OnLog += OnLog;

		try
		{
			await this.entityController1.DecodeEntriesAsync(this.cancelSource.Token);
		}
		catch (OperationCanceledException)
		{

		}

		this.txtSkipToken.Text = this.entityController1.SkipToken;

		this.timer1.Stop();

		this.ButtonStop.Enabled = false;

		this.groupBox1.Enabled = true;

		this.progressBar1.Value = 0;
	}



	private void EntityController_Tick(object sender, EventArgs e)
	{
		if (this.sw == null || this.entityController1 == null)
			return;

		this.lblCount.Text = this.entityController1.EntityCount.ToString();
		this.lblErrors.Text = this.entityController1.Error.ToString();

		this.progressBar1.Value = (this.entityController1.FileCount / 200);

		this.labelStatus.Text = $"Files: {this.entityController1.FileCount}";

		var speed = (1000 * this.entityController1.EntityCount) / this.sw.ElapsedMilliseconds;

		this.lblSpeed.Text = $"{speed} e/sec";

		this.txtSkipToken.Text = this.entityController1.SkipToken;
	}

	private void FeedController_Tick(object sender, EventArgs e)
	{
		if (this.sw == null || this.feedController1 == null)
			return;

		this.lblCount.Text = this.feedController1.FileCount.ToString();

		this.progressBar1.Value = (this.feedController1.FileCount / 200);

		var speed = (1000 * this.feedController1.FileCount) / this.sw.ElapsedMilliseconds;

		this.lblSpeed.Text = $"{speed} e/sec";

		this.txtSkipToken.Text = this.feedController1.SkipToken;

		this.labelStatus.Text = this.feedController1.Status;
	}

}