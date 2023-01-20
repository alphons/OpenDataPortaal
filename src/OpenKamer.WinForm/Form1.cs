//
// (c) 2022,2023 Alphons van der Heijden
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
	}

	private void OnLog(object? sender, EventArgs e)
	{
		this.textBox1.Invoke((MethodInvoker)delegate
		{
			this.textBox1.AppendText(sender + Environment.NewLine);
		});
	}

	private void Form1_Load(object sender, EventArgs e)
	{
		try
		{
			var lastXml = Directory
				.GetFileSystemEntries(this.txtFilesDirectory.Text, "*.xml")
				.Select(x => long.Parse(Path.GetFileNameWithoutExtension(x)))
				.OrderByDescending(x => x)
				.FirstOrDefault();

			this.txtToken.Text = lastXml.ToString();
		}
		catch
		{
			this.txtToken.Text = "ERROR";
		}
	}

	private void ButtonStop_Click(object sender, EventArgs e)
	{
		this.cancelSource?.Cancel();

		this.ButtonStop.Enabled = false;
		this.groupBox1.Enabled = true;
	}


	async private void Button1_Click(object sender, EventArgs e)
	{
		this.textBox1.Clear();

		this.cancelSource = new();

		this.groupBox1.Enabled = false;

		this.ButtonStop.Enabled = true;

		this.lblErrors.Text = "0";

		this.progressBar1.Value = 0;

		// txtToken whitespace tot start from 0
		this.feedController1 = new FeedController(this.txtFilesDirectory.Text, this.txtToken.Text);

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

		this.txtToken.Text = this.feedController1.Token;

		this.ButtonStop.Enabled = false;

		this.groupBox1.Enabled = true;

		this.progressBar1.Value = 0;

		this.lblDuration.Text = "...";

		GC.Collect();
	}

	async private void Button2_Click(object sender, EventArgs e)
	{
		this.textBox1.Clear();

		this.progressBar1.Value = 0;

		this.cancelSource = new();

		this.groupBox1.Enabled = false;

		this.ButtonStop.Enabled = true;

		this.sw = Stopwatch.StartNew();

		this.timer1.Start();

		// txtToken whitespace tot start from beginning
		this.entityController1 = new EntityController(
			this.txtMongoConnectionString.Text, 
			this.txtDbName.Text, 
			this.txtFilesDirectory.Text, 
			this.txtToken.Text);

		this.entityController1.OnLog += OnLog;

		try
		{
			await this.entityController1.DecodeEntriesAsync(this.cancelSource.Token);
		}
		catch (OperationCanceledException)
		{

		}
		this.timer1.Stop();

		this.txtToken.Text = this.entityController1.Token;

		this.ButtonStop.Enabled = false;

		this.groupBox1.Enabled = true;

		this.progressBar1.Value = 0;

		this.lblDuration.Text = "...";

		GC.Collect();
	}



	private void EntityController_Tick(object sender, EventArgs e)
	{
		if (this.sw == null || this.entityController1 == null)
			return;

		this.lblIndex.Text = this.entityController1.FilesIndex.ToString();

		this.lblErrors.Text = this.entityController1.Error.ToString();

		this.progressBar1.Value = Math.Min(100, 100 * this.entityController1.FilesIndex / this.entityController1.FilesTotal);

		var speed = (1000 * this.entityController1.EntityCount) / this.sw.ElapsedMilliseconds;

		this.lblSpeed.Text = $"{speed} e/sec";

		var secondstogo = (this.entityController1.FilesTotal - this.entityController1.FilesIndex) * sw.ElapsedMilliseconds / (1 + this.entityController1.FilesIndex) / 1000;
		if (secondstogo < 0)
			secondstogo = 0;
		var takes = new DateTimeOffset().AddSeconds(secondstogo);

		this.lblDuration.Text = $"{takes.Hour:00}:{takes.Minute:00}:{takes.Second:00}";

		this.lblStatus.Text = $"{this.entityController1.EntityCount}";

		this.txtToken.Text = this.entityController1.Token;
	}

	private void FeedController_Tick(object sender, EventArgs e)
	{
		if (this.sw == null || this.feedController1 == null)
			return;

		this.lblIndex.Text = this.feedController1.FilesIndex.ToString();

		this.progressBar1.Value = Math.Min(100, 100 * this.feedController1.FilesIndex / this.feedController1.FilesTotal);

		var speed = (1000 * this.feedController1.FilesIndex) / this.sw.ElapsedMilliseconds;

		this.lblSpeed.Text = $"{speed} f/sec";

		var secondstogo = (this.feedController1.FilesTotal - this.feedController1.FilesIndex) * sw.ElapsedMilliseconds / (1 + this.feedController1.FilesIndex) / 1000;

		if (secondstogo < 0)
			secondstogo = 0;

		var takes = new DateTimeOffset().AddSeconds(secondstogo);

		this.lblDuration.Text = $"{takes.Hour:00}:{takes.Minute:00}:{takes.Second:00}";

		this.lblStatus.Text = this.feedController1.Status;

		this.txtToken.Text = this.feedController1.Token;
	}

}