namespace mhf_displayer
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelHPValue = new System.Windows.Forms.Label();
            this.labelMonName = new System.Windows.Forms.Label();
            this.labelAtkTitle = new System.Windows.Forms.Label();
            this.AtkDefTitle = new System.Windows.Forms.Label();
            this.labelHitCountTitle = new System.Windows.Forms.Label();
            this.labelAtkValue = new System.Windows.Forms.Label();
            this.labelDefValue = new System.Windows.Forms.Label();
            this.labelHitCountsValue = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTimeValue1 = new System.Windows.Forms.Label();
            this.labelTime1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelHPValue
            // 
            this.labelHPValue.BackColor = System.Drawing.Color.Transparent;
            this.labelHPValue.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelHPValue.ForeColor = System.Drawing.Color.Lime;
            this.labelHPValue.Location = new System.Drawing.Point(225, 0);
            this.labelHPValue.Name = "labelHPValue";
            this.labelHPValue.Size = new System.Drawing.Size(86, 34);
            this.labelHPValue.TabIndex = 1;
            this.labelHPValue.Text = "300000";
            this.labelHPValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMonName
            // 
            this.labelMonName.BackColor = System.Drawing.Color.Transparent;
            this.labelMonName.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelMonName.ForeColor = System.Drawing.Color.Lime;
            this.labelMonName.Location = new System.Drawing.Point(0, 0);
            this.labelMonName.Name = "labelMonName";
            this.labelMonName.Size = new System.Drawing.Size(219, 34);
            this.labelMonName.TabIndex = 2;
            this.labelMonName.Text = "Lavasioth Subspecies:";
            this.labelMonName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAtkTitle
            // 
            this.labelAtkTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelAtkTitle.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelAtkTitle.ForeColor = System.Drawing.Color.Lime;
            this.labelAtkTitle.Location = new System.Drawing.Point(0, 34);
            this.labelAtkTitle.Name = "labelAtkTitle";
            this.labelAtkTitle.Size = new System.Drawing.Size(186, 34);
            this.labelAtkTitle.TabIndex = 3;
            this.labelAtkTitle.Text = "Atk:";
            this.labelAtkTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AtkDefTitle
            // 
            this.AtkDefTitle.BackColor = System.Drawing.Color.Transparent;
            this.AtkDefTitle.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.AtkDefTitle.ForeColor = System.Drawing.Color.Lime;
            this.AtkDefTitle.Location = new System.Drawing.Point(0, 68);
            this.AtkDefTitle.Name = "AtkDefTitle";
            this.AtkDefTitle.Size = new System.Drawing.Size(186, 34);
            this.AtkDefTitle.TabIndex = 4;
            this.AtkDefTitle.Text = "Def:";
            this.AtkDefTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelHitCountTitle
            // 
            this.labelHitCountTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelHitCountTitle.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelHitCountTitle.ForeColor = System.Drawing.Color.Lime;
            this.labelHitCountTitle.Location = new System.Drawing.Point(0, 102);
            this.labelHitCountTitle.Name = "labelHitCountTitle";
            this.labelHitCountTitle.Size = new System.Drawing.Size(186, 34);
            this.labelHitCountTitle.TabIndex = 5;
            this.labelHitCountTitle.Text = "Hit Counts:";
            this.labelHitCountTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAtkValue
            // 
            this.labelAtkValue.BackColor = System.Drawing.Color.Transparent;
            this.labelAtkValue.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelAtkValue.ForeColor = System.Drawing.Color.Lime;
            this.labelAtkValue.Location = new System.Drawing.Point(225, 34);
            this.labelAtkValue.Name = "labelAtkValue";
            this.labelAtkValue.Size = new System.Drawing.Size(86, 34);
            this.labelAtkValue.TabIndex = 6;
            this.labelAtkValue.Text = "30000";
            this.labelAtkValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDefValue
            // 
            this.labelDefValue.BackColor = System.Drawing.Color.Transparent;
            this.labelDefValue.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelDefValue.ForeColor = System.Drawing.Color.Lime;
            this.labelDefValue.Location = new System.Drawing.Point(225, 68);
            this.labelDefValue.Name = "labelDefValue";
            this.labelDefValue.Size = new System.Drawing.Size(86, 34);
            this.labelDefValue.TabIndex = 7;
            this.labelDefValue.Text = "30000";
            this.labelDefValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelHitCountsValue
            // 
            this.labelHitCountsValue.BackColor = System.Drawing.Color.Transparent;
            this.labelHitCountsValue.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelHitCountsValue.ForeColor = System.Drawing.Color.Lime;
            this.labelHitCountsValue.Location = new System.Drawing.Point(225, 102);
            this.labelHitCountsValue.Name = "labelHitCountsValue";
            this.labelHitCountsValue.Size = new System.Drawing.Size(86, 34);
            this.labelHitCountsValue.TabIndex = 8;
            this.labelHitCountsValue.Text = "30000";
            this.labelHitCountsValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.labelTimeValue1);
            this.panel1.Controls.Add(this.labelTime1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.labelMonName);
            this.panel1.Controls.Add(this.labelHitCountsValue);
            this.panel1.Controls.Add(this.labelDefValue);
            this.panel1.Controls.Add(this.labelHPValue);
            this.panel1.Controls.Add(this.labelAtkValue);
            this.panel1.Controls.Add(this.labelAtkTitle);
            this.panel1.Controls.Add(this.labelHitCountTitle);
            this.panel1.Controls.Add(this.AtkDefTitle);
            this.panel1.Location = new System.Drawing.Point(12, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 278);
            this.panel1.TabIndex = 9;
            // 
            // labelTimeValue1
            // 
            this.labelTimeValue1.BackColor = System.Drawing.Color.Transparent;
            this.labelTimeValue1.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelTimeValue1.ForeColor = System.Drawing.Color.Lime;
            this.labelTimeValue1.Location = new System.Drawing.Point(225, 136);
            this.labelTimeValue1.Name = "labelTimeValue1";
            this.labelTimeValue1.Size = new System.Drawing.Size(168, 34);
            this.labelTimeValue1.TabIndex = 11;
            this.labelTimeValue1.Text = "30000";
            this.labelTimeValue1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTime1
            // 
            this.labelTime1.BackColor = System.Drawing.Color.Transparent;
            this.labelTime1.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelTime1.ForeColor = System.Drawing.Color.Lime;
            this.labelTime1.Location = new System.Drawing.Point(0, 136);
            this.labelTime1.Name = "labelTime1";
            this.labelTime1.Size = new System.Drawing.Size(186, 34);
            this.labelTime1.TabIndex = 10;
            this.labelTime1.Text = "Remaining Time:";
            this.labelTime1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(317, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 24);
            this.button1.TabIndex = 9;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.LimeGreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Label labelHPValue;
        private Label labelMonName;
        private Label labelAtkTitle;
        private Label AtkDefTitle;
        private Label labelHitCountTitle;
        private Label labelAtkValue;
        private Label labelDefValue;
        private Label labelHitCountsValue;
        private Panel panel1;
        private Button button1;
        private Label labelTimeValue1;
        private Label labelTime1;
    }
}