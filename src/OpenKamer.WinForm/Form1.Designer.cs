﻿namespace OpenKamer.WinForm
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.ButtonStop = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.txtToken = new System.Windows.Forms.TextBox();
			this.txtMongoConnectionString = new System.Windows.Forms.TextBox();
			this.txtFilesDirectory = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtDbName = new System.Windows.Forms.TextBox();
			this.lblSpeed = new System.Windows.Forms.Label();
			this.lblErrors = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.lblIndex = new System.Windows.Forms.Label();
			this.lblStatus = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.lblDuration = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(137, 22);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(94, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Feed Refresh";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(237, 22);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(94, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Get Entries";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2_Click);
			// 
			// ButtonStop
			// 
			this.ButtonStop.Enabled = false;
			this.ButtonStop.Location = new System.Drawing.Point(249, 162);
			this.ButtonStop.Name = "ButtonStop";
			this.ButtonStop.Size = new System.Drawing.Size(94, 23);
			this.ButtonStop.TabIndex = 16;
			this.ButtonStop.Text = "Stop";
			this.ButtonStop.UseVisualStyleBackColor = true;
			this.ButtonStop.Click += new System.EventHandler(this.ButtonStop_Click);
			// 
			// textBox1
			// 
			this.textBox1.AcceptsReturn = true;
			this.textBox1.AcceptsTab = true;
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(360, 12);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(306, 243);
			this.textBox1.TabIndex = 1;
			// 
			// txtToken
			// 
			this.txtToken.Location = new System.Drawing.Point(61, 22);
			this.txtToken.Name = "txtToken";
			this.txtToken.Size = new System.Drawing.Size(70, 23);
			this.txtToken.TabIndex = 3;
			// 
			// txtMongoConnectionString
			// 
			this.txtMongoConnectionString.Location = new System.Drawing.Point(63, 52);
			this.txtMongoConnectionString.Name = "txtMongoConnectionString";
			this.txtMongoConnectionString.Size = new System.Drawing.Size(268, 23);
			this.txtMongoConnectionString.TabIndex = 4;
			this.txtMongoConnectionString.Text = "mongodb://127.0.0.1:27017";
			// 
			// txtFilesDirectory
			// 
			this.txtFilesDirectory.Location = new System.Drawing.Point(63, 110);
			this.txtFilesDirectory.Name = "txtFilesDirectory";
			this.txtFilesDirectory.Size = new System.Drawing.Size(268, 23);
			this.txtFilesDirectory.TabIndex = 5;
			this.txtFilesDirectory.Text = "d:\\gegevensmagazijn";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtDbName);
			this.groupBox1.Controls.Add(this.txtMongoConnectionString);
			this.groupBox1.Controls.Add(this.txtFilesDirectory);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.txtToken);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(342, 144);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "settings";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(17, 25);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 15);
			this.label4.TabIndex = 10;
			this.label4.Text = "Token";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(0, 113);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 15);
			this.label3.TabIndex = 9;
			this.label3.Text = "FileCache";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 84);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 15);
			this.label2.TabIndex = 8;
			this.label2.Text = "DataBase";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 55);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 15);
			this.label1.TabIndex = 7;
			this.label1.Text = "MongDB";
			// 
			// txtDbName
			// 
			this.txtDbName.Location = new System.Drawing.Point(63, 81);
			this.txtDbName.Name = "txtDbName";
			this.txtDbName.Size = new System.Drawing.Size(268, 23);
			this.txtDbName.TabIndex = 6;
			this.txtDbName.Text = "tweedekamer";
			// 
			// lblSpeed
			// 
			this.lblSpeed.AutoSize = true;
			this.lblSpeed.Location = new System.Drawing.Point(183, 166);
			this.lblSpeed.Name = "lblSpeed";
			this.lblSpeed.Size = new System.Drawing.Size(16, 15);
			this.lblSpeed.TabIndex = 15;
			this.lblSpeed.Text = "...";
			// 
			// lblErrors
			// 
			this.lblErrors.AutoSize = true;
			this.lblErrors.Location = new System.Drawing.Point(149, 166);
			this.lblErrors.Name = "lblErrors";
			this.lblErrors.Size = new System.Drawing.Size(16, 15);
			this.lblErrors.TabIndex = 14;
			this.lblErrors.Text = "...";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(103, 166);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 15);
			this.label8.TabIndex = 13;
			this.label8.Text = "Errors:";
			// 
			// lblIndex
			// 
			this.lblIndex.AutoSize = true;
			this.lblIndex.Location = new System.Drawing.Point(57, 166);
			this.lblIndex.Name = "lblIndex";
			this.lblIndex.Size = new System.Drawing.Size(16, 15);
			this.lblIndex.TabIndex = 12;
			this.lblIndex.Text = "...";
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point(57, 194);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(16, 15);
			this.lblStatus.TabIndex = 17;
			this.lblStatus.Text = "...";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(16, 166);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(39, 15);
			this.label5.TabIndex = 11;
			this.label5.Text = "Index:";
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.EntityController_Tick);
			// 
			// timer2
			// 
			this.timer2.Interval = 1000;
			this.timer2.Tick += new System.EventHandler(this.FeedController_Tick);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(10, 242);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(339, 12);
			this.progressBar1.TabIndex = 18;
			// 
			// lblDuration
			// 
			this.lblDuration.AutoSize = true;
			this.lblDuration.Location = new System.Drawing.Point(297, 224);
			this.lblDuration.Name = "lblDuration";
			this.lblDuration.Size = new System.Drawing.Size(16, 15);
			this.lblDuration.TabIndex = 19;
			this.lblDuration.Text = "...";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(16, 194);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(42, 15);
			this.label6.TabIndex = 20;
			this.label6.Text = "Status:";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(678, 267);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.lblSpeed);
			this.Controls.Add(this.lblDuration);
			this.Controls.Add(this.lblErrors);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.lblIndex);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.ButtonStop);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.textBox1);
			this.Name = "Form1";
			this.Text = "3e kamer";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Button button1;
		private Button button2;
		private Button ButtonStop;
		private TextBox textBox1;
		private TextBox txtToken;
		private TextBox txtMongoConnectionString;
		private TextBox txtFilesDirectory;
		private GroupBox groupBox1;
		private TextBox txtDbName;
		private Label label4;
		private Label label3;
		private Label label2;
		private Label label1;
		private Label lblSpeed;
		private Label lblErrors;
		private Label label8;
		private Label lblIndex;
		private Label label5;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Timer timer2;
		private Label lblStatus;
		private ProgressBar progressBar1;
		private Label lblDuration;
		private Label label6;
	}
}