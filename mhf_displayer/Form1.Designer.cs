﻿namespace mhf_displayer
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
            this.labelHitCountTitle = new System.Windows.Forms.Label();
            this.labelHitCountsValue = new System.Windows.Forms.Label();
            this.panelPlayerInfo = new System.Windows.Forms.Panel();
            this.labelPlayerAtk = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.labelTimeValue1 = new System.Windows.Forms.Label();
            this.labelTime1 = new System.Windows.Forms.Label();
            this.panelHP = new System.Windows.Forms.Panel();
            this.labelMonHP4 = new System.Windows.Forms.Label();
            this.labelMonHP3 = new System.Windows.Forms.Label();
            this.labelMonHP2 = new System.Windows.Forms.Label();
            this.labelMonHP1 = new System.Windows.Forms.Label();
            this.labelMonN4 = new System.Windows.Forms.Label();
            this.labelMonN3 = new System.Windows.Forms.Label();
            this.labelMonN2 = new System.Windows.Forms.Label();
            this.labelMonN1 = new System.Windows.Forms.Label();
            this.panelMonsInfo = new System.Windows.Forms.Panel();
            this.labelSize = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.labelStun = new System.Windows.Forms.Label();
            this.labelBlast = new System.Windows.Forms.Label();
            this.labelPara = new System.Windows.Forms.Label();
            this.labelSleep = new System.Windows.Forms.Label();
            this.labelPoison = new System.Windows.Forms.Label();
            this.labelDefValue = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.labelAtkTitle = new System.Windows.Forms.Label();
            this.AtkDefTitle = new System.Windows.Forms.Label();
            this.labelAtkValue = new System.Windows.Forms.Label();
            this.panelSample = new System.Windows.Forms.Panel();
            this.labelSampleDmg3 = new System.Windows.Forms.Label();
            this.labelSampleDmg2 = new System.Windows.Forms.Label();
            this.labelSampleDmg1 = new System.Windows.Forms.Label();
            this.panelBodyParts = new System.Windows.Forms.Panel();
            this.labelBP10 = new System.Windows.Forms.Label();
            this.labelBP9 = new System.Windows.Forms.Label();
            this.labelBP8 = new System.Windows.Forms.Label();
            this.labelBP7 = new System.Windows.Forms.Label();
            this.labelBP6 = new System.Windows.Forms.Label();
            this.labelBP5 = new System.Windows.Forms.Label();
            this.labelBP4 = new System.Windows.Forms.Label();
            this.labelBP3 = new System.Windows.Forms.Label();
            this.labelBP2 = new System.Windows.Forms.Label();
            this.labelBP1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelPlayerInfo.SuspendLayout();
            this.panelHP.SuspendLayout();
            this.panelMonsInfo.SuspendLayout();
            this.panelSample.SuspendLayout();
            this.panelBodyParts.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelHitCountTitle
            // 
            this.labelHitCountTitle.AutoSize = true;
            this.labelHitCountTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelHitCountTitle.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelHitCountTitle.ForeColor = System.Drawing.Color.Lime;
            this.labelHitCountTitle.Location = new System.Drawing.Point(0, 0);
            this.labelHitCountTitle.Name = "labelHitCountTitle";
            this.labelHitCountTitle.Size = new System.Drawing.Size(117, 29);
            this.labelHitCountTitle.TabIndex = 5;
            this.labelHitCountTitle.Text = "Hit Counts:";
            this.labelHitCountTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelHitCountsValue
            // 
            this.labelHitCountsValue.AutoSize = true;
            this.labelHitCountsValue.BackColor = System.Drawing.Color.Transparent;
            this.labelHitCountsValue.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelHitCountsValue.ForeColor = System.Drawing.Color.Lime;
            this.labelHitCountsValue.Location = new System.Drawing.Point(225, 0);
            this.labelHitCountsValue.Name = "labelHitCountsValue";
            this.labelHitCountsValue.Size = new System.Drawing.Size(73, 29);
            this.labelHitCountsValue.TabIndex = 8;
            this.labelHitCountsValue.Text = "30000";
            this.labelHitCountsValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelPlayerInfo
            // 
            this.panelPlayerInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelPlayerInfo.Controls.Add(this.labelPlayerAtk);
            this.panelPlayerInfo.Controls.Add(this.label21);
            this.panelPlayerInfo.Controls.Add(this.labelTimeValue1);
            this.panelPlayerInfo.Controls.Add(this.labelTime1);
            this.panelPlayerInfo.Controls.Add(this.labelHitCountsValue);
            this.panelPlayerInfo.Controls.Add(this.labelHitCountTitle);
            this.panelPlayerInfo.Location = new System.Drawing.Point(12, 153);
            this.panelPlayerInfo.Name = "panelPlayerInfo";
            this.panelPlayerInfo.Size = new System.Drawing.Size(396, 128);
            this.panelPlayerInfo.TabIndex = 9;
            // 
            // labelPlayerAtk
            // 
            this.labelPlayerAtk.AutoSize = true;
            this.labelPlayerAtk.BackColor = System.Drawing.Color.Transparent;
            this.labelPlayerAtk.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelPlayerAtk.ForeColor = System.Drawing.Color.Lime;
            this.labelPlayerAtk.Location = new System.Drawing.Point(225, 80);
            this.labelPlayerAtk.Name = "labelPlayerAtk";
            this.labelPlayerAtk.Size = new System.Drawing.Size(73, 29);
            this.labelPlayerAtk.TabIndex = 14;
            this.labelPlayerAtk.Text = "30000";
            this.labelPlayerAtk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label21.ForeColor = System.Drawing.Color.Lime;
            this.label21.Location = new System.Drawing.Point(0, 80);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(171, 29);
            this.label21.TabIndex = 13;
            this.label21.Text = "Player Atk Value:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTimeValue1
            // 
            this.labelTimeValue1.AutoSize = true;
            this.labelTimeValue1.BackColor = System.Drawing.Color.Transparent;
            this.labelTimeValue1.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelTimeValue1.ForeColor = System.Drawing.Color.Lime;
            this.labelTimeValue1.Location = new System.Drawing.Point(225, 40);
            this.labelTimeValue1.Name = "labelTimeValue1";
            this.labelTimeValue1.Size = new System.Drawing.Size(73, 29);
            this.labelTimeValue1.TabIndex = 11;
            this.labelTimeValue1.Text = "30000";
            this.labelTimeValue1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTime1
            // 
            this.labelTime1.AutoSize = true;
            this.labelTime1.BackColor = System.Drawing.Color.Transparent;
            this.labelTime1.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelTime1.ForeColor = System.Drawing.Color.Lime;
            this.labelTime1.Location = new System.Drawing.Point(0, 39);
            this.labelTime1.Name = "labelTime1";
            this.labelTime1.Size = new System.Drawing.Size(165, 29);
            this.labelTime1.TabIndex = 10;
            this.labelTime1.Text = "Remaining Time:";
            this.labelTime1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelHP
            // 
            this.panelHP.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panelHP.Controls.Add(this.labelMonHP4);
            this.panelHP.Controls.Add(this.labelMonHP3);
            this.panelHP.Controls.Add(this.labelMonHP2);
            this.panelHP.Controls.Add(this.labelMonHP1);
            this.panelHP.Controls.Add(this.labelMonN4);
            this.panelHP.Controls.Add(this.labelMonN3);
            this.panelHP.Controls.Add(this.labelMonN2);
            this.panelHP.Controls.Add(this.labelMonN1);
            this.panelHP.Location = new System.Drawing.Point(12, 638);
            this.panelHP.Name = "panelHP";
            this.panelHP.Size = new System.Drawing.Size(396, 152);
            this.panelHP.TabIndex = 11;
            // 
            // labelMonHP4
            // 
            this.labelMonHP4.AutoSize = true;
            this.labelMonHP4.BackColor = System.Drawing.Color.Transparent;
            this.labelMonHP4.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelMonHP4.ForeColor = System.Drawing.Color.Lime;
            this.labelMonHP4.Location = new System.Drawing.Point(273, 102);
            this.labelMonHP4.Name = "labelMonHP4";
            this.labelMonHP4.Size = new System.Drawing.Size(85, 29);
            this.labelMonHP4.TabIndex = 24;
            this.labelMonHP4.Text = "300000";
            this.labelMonHP4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMonHP3
            // 
            this.labelMonHP3.AutoSize = true;
            this.labelMonHP3.BackColor = System.Drawing.Color.Transparent;
            this.labelMonHP3.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelMonHP3.ForeColor = System.Drawing.Color.Lime;
            this.labelMonHP3.Location = new System.Drawing.Point(273, 68);
            this.labelMonHP3.Name = "labelMonHP3";
            this.labelMonHP3.Size = new System.Drawing.Size(85, 29);
            this.labelMonHP3.TabIndex = 23;
            this.labelMonHP3.Text = "300000";
            this.labelMonHP3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMonHP2
            // 
            this.labelMonHP2.AutoSize = true;
            this.labelMonHP2.BackColor = System.Drawing.Color.Transparent;
            this.labelMonHP2.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelMonHP2.ForeColor = System.Drawing.Color.Lime;
            this.labelMonHP2.Location = new System.Drawing.Point(273, 34);
            this.labelMonHP2.Name = "labelMonHP2";
            this.labelMonHP2.Size = new System.Drawing.Size(85, 29);
            this.labelMonHP2.TabIndex = 22;
            this.labelMonHP2.Text = "300000";
            this.labelMonHP2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMonHP1
            // 
            this.labelMonHP1.AutoSize = true;
            this.labelMonHP1.BackColor = System.Drawing.Color.Transparent;
            this.labelMonHP1.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelMonHP1.ForeColor = System.Drawing.Color.Lime;
            this.labelMonHP1.Location = new System.Drawing.Point(273, 0);
            this.labelMonHP1.Name = "labelMonHP1";
            this.labelMonHP1.Size = new System.Drawing.Size(85, 29);
            this.labelMonHP1.TabIndex = 21;
            this.labelMonHP1.Text = "300000";
            this.labelMonHP1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMonN4
            // 
            this.labelMonN4.AutoSize = true;
            this.labelMonN4.BackColor = System.Drawing.Color.Transparent;
            this.labelMonN4.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelMonN4.ForeColor = System.Drawing.Color.Lime;
            this.labelMonN4.Location = new System.Drawing.Point(3, 102);
            this.labelMonN4.Name = "labelMonN4";
            this.labelMonN4.Size = new System.Drawing.Size(219, 29);
            this.labelMonN4.TabIndex = 20;
            this.labelMonN4.Text = "Lavasioth Subspecies:";
            this.labelMonN4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMonN3
            // 
            this.labelMonN3.AutoSize = true;
            this.labelMonN3.BackColor = System.Drawing.Color.Transparent;
            this.labelMonN3.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelMonN3.ForeColor = System.Drawing.Color.Lime;
            this.labelMonN3.Location = new System.Drawing.Point(3, 68);
            this.labelMonN3.Name = "labelMonN3";
            this.labelMonN3.Size = new System.Drawing.Size(219, 29);
            this.labelMonN3.TabIndex = 19;
            this.labelMonN3.Text = "Lavasioth Subspecies:";
            this.labelMonN3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMonN2
            // 
            this.labelMonN2.AutoSize = true;
            this.labelMonN2.BackColor = System.Drawing.Color.Transparent;
            this.labelMonN2.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelMonN2.ForeColor = System.Drawing.Color.Lime;
            this.labelMonN2.Location = new System.Drawing.Point(3, 34);
            this.labelMonN2.Name = "labelMonN2";
            this.labelMonN2.Size = new System.Drawing.Size(219, 29);
            this.labelMonN2.TabIndex = 18;
            this.labelMonN2.Text = "Lavasioth Subspecies:";
            this.labelMonN2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMonN1
            // 
            this.labelMonN1.AutoSize = true;
            this.labelMonN1.BackColor = System.Drawing.Color.Transparent;
            this.labelMonN1.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelMonN1.ForeColor = System.Drawing.Color.Lime;
            this.labelMonN1.Location = new System.Drawing.Point(3, 0);
            this.labelMonN1.Name = "labelMonN1";
            this.labelMonN1.Size = new System.Drawing.Size(219, 29);
            this.labelMonN1.TabIndex = 3;
            this.labelMonN1.Text = "Lavasioth Subspecies:";
            this.labelMonN1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelMonsInfo
            // 
            this.panelMonsInfo.AutoSize = true;
            this.panelMonsInfo.BackColor = System.Drawing.Color.DarkKhaki;
            this.panelMonsInfo.Controls.Add(this.labelSize);
            this.panelMonsInfo.Controls.Add(this.label34);
            this.panelMonsInfo.Controls.Add(this.labelStun);
            this.panelMonsInfo.Controls.Add(this.labelBlast);
            this.panelMonsInfo.Controls.Add(this.labelPara);
            this.panelMonsInfo.Controls.Add(this.labelSleep);
            this.panelMonsInfo.Controls.Add(this.labelPoison);
            this.panelMonsInfo.Controls.Add(this.labelDefValue);
            this.panelMonsInfo.Controls.Add(this.label26);
            this.panelMonsInfo.Controls.Add(this.label25);
            this.panelMonsInfo.Controls.Add(this.label24);
            this.panelMonsInfo.Controls.Add(this.label23);
            this.panelMonsInfo.Controls.Add(this.label22);
            this.panelMonsInfo.Controls.Add(this.labelAtkTitle);
            this.panelMonsInfo.Controls.Add(this.AtkDefTitle);
            this.panelMonsInfo.Controls.Add(this.labelAtkValue);
            this.panelMonsInfo.Location = new System.Drawing.Point(12, 287);
            this.panelMonsInfo.Name = "panelMonsInfo";
            this.panelMonsInfo.Size = new System.Drawing.Size(345, 281);
            this.panelMonsInfo.TabIndex = 12;
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.BackColor = System.Drawing.Color.Transparent;
            this.labelSize.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelSize.ForeColor = System.Drawing.Color.Lime;
            this.labelSize.Location = new System.Drawing.Point(156, 68);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(62, 29);
            this.labelSize.TabIndex = 20;
            this.labelSize.Text = "100%";
            this.labelSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label34.ForeColor = System.Drawing.Color.Lime;
            this.label34.Location = new System.Drawing.Point(0, 68);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(61, 29);
            this.label34.TabIndex = 19;
            this.label34.Text = "Size:";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelStun
            // 
            this.labelStun.AutoSize = true;
            this.labelStun.BackColor = System.Drawing.Color.Transparent;
            this.labelStun.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelStun.ForeColor = System.Drawing.Color.Lime;
            this.labelStun.Location = new System.Drawing.Point(156, 238);
            this.labelStun.Name = "labelStun";
            this.labelStun.Size = new System.Drawing.Size(59, 29);
            this.labelStun.TabIndex = 18;
            this.labelStun.Text = "0 / 0";
            this.labelStun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBlast
            // 
            this.labelBlast.AutoSize = true;
            this.labelBlast.BackColor = System.Drawing.Color.Transparent;
            this.labelBlast.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelBlast.ForeColor = System.Drawing.Color.Lime;
            this.labelBlast.Location = new System.Drawing.Point(156, 204);
            this.labelBlast.Name = "labelBlast";
            this.labelBlast.Size = new System.Drawing.Size(59, 29);
            this.labelBlast.TabIndex = 17;
            this.labelBlast.Text = "0 / 0";
            this.labelBlast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPara
            // 
            this.labelPara.AutoSize = true;
            this.labelPara.BackColor = System.Drawing.Color.Transparent;
            this.labelPara.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelPara.ForeColor = System.Drawing.Color.Lime;
            this.labelPara.Location = new System.Drawing.Point(156, 170);
            this.labelPara.Name = "labelPara";
            this.labelPara.Size = new System.Drawing.Size(59, 29);
            this.labelPara.TabIndex = 16;
            this.labelPara.Text = "0 / 0";
            this.labelPara.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSleep
            // 
            this.labelSleep.AutoSize = true;
            this.labelSleep.BackColor = System.Drawing.Color.Transparent;
            this.labelSleep.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelSleep.ForeColor = System.Drawing.Color.Lime;
            this.labelSleep.Location = new System.Drawing.Point(156, 136);
            this.labelSleep.Name = "labelSleep";
            this.labelSleep.Size = new System.Drawing.Size(59, 29);
            this.labelSleep.TabIndex = 15;
            this.labelSleep.Text = "0 / 0";
            this.labelSleep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPoison
            // 
            this.labelPoison.AutoSize = true;
            this.labelPoison.BackColor = System.Drawing.Color.Transparent;
            this.labelPoison.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelPoison.ForeColor = System.Drawing.Color.Lime;
            this.labelPoison.Location = new System.Drawing.Point(156, 102);
            this.labelPoison.Name = "labelPoison";
            this.labelPoison.Size = new System.Drawing.Size(59, 29);
            this.labelPoison.TabIndex = 14;
            this.labelPoison.Text = "0 / 0";
            this.labelPoison.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDefValue
            // 
            this.labelDefValue.AutoSize = true;
            this.labelDefValue.BackColor = System.Drawing.Color.Transparent;
            this.labelDefValue.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelDefValue.ForeColor = System.Drawing.Color.Lime;
            this.labelDefValue.Location = new System.Drawing.Point(156, 34);
            this.labelDefValue.Name = "labelDefValue";
            this.labelDefValue.Size = new System.Drawing.Size(25, 29);
            this.labelDefValue.TabIndex = 13;
            this.labelDefValue.Text = "0";
            this.labelDefValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label26.ForeColor = System.Drawing.Color.Lime;
            this.label26.Location = new System.Drawing.Point(0, 238);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(62, 29);
            this.label26.TabIndex = 12;
            this.label26.Text = "Stun:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label25.ForeColor = System.Drawing.Color.Lime;
            this.label25.Location = new System.Drawing.Point(0, 204);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(121, 29);
            this.label25.TabIndex = 11;
            this.label25.Text = "Blastblight:";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label24.ForeColor = System.Drawing.Color.Lime;
            this.label24.Location = new System.Drawing.Point(0, 136);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(71, 29);
            this.label24.TabIndex = 10;
            this.label24.Text = "Sleep:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label23.ForeColor = System.Drawing.Color.Lime;
            this.label23.Location = new System.Drawing.Point(0, 171);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(100, 29);
            this.label23.TabIndex = 9;
            this.label23.Text = "Paralysis:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label22.ForeColor = System.Drawing.Color.Lime;
            this.label22.Location = new System.Drawing.Point(0, 102);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(77, 29);
            this.label22.TabIndex = 8;
            this.label22.Text = "Poison:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAtkTitle
            // 
            this.labelAtkTitle.AutoSize = true;
            this.labelAtkTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelAtkTitle.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelAtkTitle.ForeColor = System.Drawing.Color.Lime;
            this.labelAtkTitle.Location = new System.Drawing.Point(0, 0);
            this.labelAtkTitle.Name = "labelAtkTitle";
            this.labelAtkTitle.Size = new System.Drawing.Size(54, 29);
            this.labelAtkTitle.TabIndex = 3;
            this.labelAtkTitle.Text = "Atk:";
            this.labelAtkTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AtkDefTitle
            // 
            this.AtkDefTitle.AutoSize = true;
            this.AtkDefTitle.BackColor = System.Drawing.Color.Transparent;
            this.AtkDefTitle.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.AtkDefTitle.ForeColor = System.Drawing.Color.Lime;
            this.AtkDefTitle.Location = new System.Drawing.Point(0, 34);
            this.AtkDefTitle.Name = "AtkDefTitle";
            this.AtkDefTitle.Size = new System.Drawing.Size(54, 29);
            this.AtkDefTitle.TabIndex = 4;
            this.AtkDefTitle.Text = "Def:";
            this.AtkDefTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAtkValue
            // 
            this.labelAtkValue.AutoSize = true;
            this.labelAtkValue.BackColor = System.Drawing.Color.Transparent;
            this.labelAtkValue.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelAtkValue.ForeColor = System.Drawing.Color.Lime;
            this.labelAtkValue.Location = new System.Drawing.Point(156, 0);
            this.labelAtkValue.Name = "labelAtkValue";
            this.labelAtkValue.Size = new System.Drawing.Size(25, 29);
            this.labelAtkValue.TabIndex = 6;
            this.labelAtkValue.Text = "0";
            this.labelAtkValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelSample
            // 
            this.panelSample.BackColor = System.Drawing.Color.LightGray;
            this.panelSample.Controls.Add(this.labelSampleDmg3);
            this.panelSample.Controls.Add(this.labelSampleDmg2);
            this.panelSample.Controls.Add(this.labelSampleDmg1);
            this.panelSample.Location = new System.Drawing.Point(433, 47);
            this.panelSample.Name = "panelSample";
            this.panelSample.Size = new System.Drawing.Size(286, 135);
            this.panelSample.TabIndex = 13;
            // 
            // labelSampleDmg3
            // 
            this.labelSampleDmg3.AutoSize = true;
            this.labelSampleDmg3.ForeColor = System.Drawing.Color.Black;
            this.labelSampleDmg3.Location = new System.Drawing.Point(232, 95);
            this.labelSampleDmg3.Name = "labelSampleDmg3";
            this.labelSampleDmg3.Size = new System.Drawing.Size(25, 15);
            this.labelSampleDmg3.TabIndex = 2;
            this.labelSampleDmg3.Text = "110";
            // 
            // labelSampleDmg2
            // 
            this.labelSampleDmg2.AutoSize = true;
            this.labelSampleDmg2.ForeColor = System.Drawing.Color.Black;
            this.labelSampleDmg2.Location = new System.Drawing.Point(135, 46);
            this.labelSampleDmg2.Name = "labelSampleDmg2";
            this.labelSampleDmg2.Size = new System.Drawing.Size(25, 15);
            this.labelSampleDmg2.TabIndex = 1;
            this.labelSampleDmg2.Text = "110";
            // 
            // labelSampleDmg1
            // 
            this.labelSampleDmg1.AutoSize = true;
            this.labelSampleDmg1.ForeColor = System.Drawing.Color.Black;
            this.labelSampleDmg1.Location = new System.Drawing.Point(50, 32);
            this.labelSampleDmg1.Name = "labelSampleDmg1";
            this.labelSampleDmg1.Size = new System.Drawing.Size(25, 15);
            this.labelSampleDmg1.TabIndex = 0;
            this.labelSampleDmg1.Text = "110";
            // 
            // panelBodyParts
            // 
            this.panelBodyParts.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panelBodyParts.Controls.Add(this.labelBP10);
            this.panelBodyParts.Controls.Add(this.labelBP9);
            this.panelBodyParts.Controls.Add(this.labelBP8);
            this.panelBodyParts.Controls.Add(this.labelBP7);
            this.panelBodyParts.Controls.Add(this.labelBP6);
            this.panelBodyParts.Controls.Add(this.labelBP5);
            this.panelBodyParts.Controls.Add(this.labelBP4);
            this.panelBodyParts.Controls.Add(this.labelBP3);
            this.panelBodyParts.Controls.Add(this.labelBP2);
            this.panelBodyParts.Controls.Add(this.labelBP1);
            this.panelBodyParts.Location = new System.Drawing.Point(12, 796);
            this.panelBodyParts.Name = "panelBodyParts";
            this.panelBodyParts.Size = new System.Drawing.Size(554, 77);
            this.panelBodyParts.TabIndex = 14;
            // 
            // labelBP10
            // 
            this.labelBP10.AutoSize = true;
            this.labelBP10.BackColor = System.Drawing.Color.Transparent;
            this.labelBP10.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelBP10.ForeColor = System.Drawing.Color.Lime;
            this.labelBP10.Location = new System.Drawing.Point(435, 34);
            this.labelBP10.Name = "labelBP10";
            this.labelBP10.Size = new System.Drawing.Size(25, 29);
            this.labelBP10.TabIndex = 30;
            this.labelBP10.Text = "0";
            this.labelBP10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBP9
            // 
            this.labelBP9.AutoSize = true;
            this.labelBP9.BackColor = System.Drawing.Color.Transparent;
            this.labelBP9.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelBP9.ForeColor = System.Drawing.Color.Lime;
            this.labelBP9.Location = new System.Drawing.Point(327, 34);
            this.labelBP9.Name = "labelBP9";
            this.labelBP9.Size = new System.Drawing.Size(25, 29);
            this.labelBP9.TabIndex = 29;
            this.labelBP9.Text = "0";
            this.labelBP9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBP8
            // 
            this.labelBP8.AutoSize = true;
            this.labelBP8.BackColor = System.Drawing.Color.Transparent;
            this.labelBP8.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelBP8.ForeColor = System.Drawing.Color.Lime;
            this.labelBP8.Location = new System.Drawing.Point(219, 34);
            this.labelBP8.Name = "labelBP8";
            this.labelBP8.Size = new System.Drawing.Size(25, 29);
            this.labelBP8.TabIndex = 28;
            this.labelBP8.Text = "0";
            this.labelBP8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBP7
            // 
            this.labelBP7.AutoSize = true;
            this.labelBP7.BackColor = System.Drawing.Color.Transparent;
            this.labelBP7.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelBP7.ForeColor = System.Drawing.Color.Lime;
            this.labelBP7.Location = new System.Drawing.Point(111, 34);
            this.labelBP7.Name = "labelBP7";
            this.labelBP7.Size = new System.Drawing.Size(25, 29);
            this.labelBP7.TabIndex = 27;
            this.labelBP7.Text = "0";
            this.labelBP7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBP6
            // 
            this.labelBP6.AutoSize = true;
            this.labelBP6.BackColor = System.Drawing.Color.Transparent;
            this.labelBP6.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelBP6.ForeColor = System.Drawing.Color.Lime;
            this.labelBP6.Location = new System.Drawing.Point(3, 34);
            this.labelBP6.Name = "labelBP6";
            this.labelBP6.Size = new System.Drawing.Size(25, 29);
            this.labelBP6.TabIndex = 26;
            this.labelBP6.Text = "0";
            this.labelBP6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBP5
            // 
            this.labelBP5.AutoSize = true;
            this.labelBP5.BackColor = System.Drawing.Color.Transparent;
            this.labelBP5.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelBP5.ForeColor = System.Drawing.Color.Lime;
            this.labelBP5.Location = new System.Drawing.Point(435, 0);
            this.labelBP5.Name = "labelBP5";
            this.labelBP5.Size = new System.Drawing.Size(25, 29);
            this.labelBP5.TabIndex = 25;
            this.labelBP5.Text = "0";
            this.labelBP5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBP4
            // 
            this.labelBP4.AutoSize = true;
            this.labelBP4.BackColor = System.Drawing.Color.Transparent;
            this.labelBP4.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelBP4.ForeColor = System.Drawing.Color.Lime;
            this.labelBP4.Location = new System.Drawing.Point(327, 0);
            this.labelBP4.Name = "labelBP4";
            this.labelBP4.Size = new System.Drawing.Size(25, 29);
            this.labelBP4.TabIndex = 24;
            this.labelBP4.Text = "0";
            this.labelBP4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBP3
            // 
            this.labelBP3.AutoSize = true;
            this.labelBP3.BackColor = System.Drawing.Color.Transparent;
            this.labelBP3.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelBP3.ForeColor = System.Drawing.Color.Lime;
            this.labelBP3.Location = new System.Drawing.Point(219, 0);
            this.labelBP3.Name = "labelBP3";
            this.labelBP3.Size = new System.Drawing.Size(25, 29);
            this.labelBP3.TabIndex = 23;
            this.labelBP3.Text = "0";
            this.labelBP3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBP2
            // 
            this.labelBP2.AutoSize = true;
            this.labelBP2.BackColor = System.Drawing.Color.Transparent;
            this.labelBP2.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelBP2.ForeColor = System.Drawing.Color.Lime;
            this.labelBP2.Location = new System.Drawing.Point(111, 0);
            this.labelBP2.Name = "labelBP2";
            this.labelBP2.Size = new System.Drawing.Size(25, 29);
            this.labelBP2.TabIndex = 22;
            this.labelBP2.Text = "0";
            this.labelBP2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBP1
            // 
            this.labelBP1.AutoSize = true;
            this.labelBP1.BackColor = System.Drawing.Color.Transparent;
            this.labelBP1.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelBP1.ForeColor = System.Drawing.Color.Lime;
            this.labelBP1.Location = new System.Drawing.Point(3, 0);
            this.labelBP1.Name = "labelBP1";
            this.labelBP1.Size = new System.Drawing.Size(25, 29);
            this.labelBP1.TabIndex = 21;
            this.labelBP1.Text = "0";
            this.labelBP1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openConfigToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(176, 48);
            // 
            // openConfigToolStripMenuItem
            // 
            this.openConfigToolStripMenuItem.Name = "openConfigToolStripMenuItem";
            this.openConfigToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.openConfigToolStripMenuItem.Text = "Open Config Menu";
            this.openConfigToolStripMenuItem.Click += new System.EventHandler(this.openConfigToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.ControlBox = false;
            this.Controls.Add(this.panelBodyParts);
            this.Controls.Add(this.panelSample);
            this.Controls.Add(this.panelMonsInfo);
            this.Controls.Add(this.panelHP);
            this.Controls.Add(this.panelPlayerInfo);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.WindowText;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelPlayerInfo.ResumeLayout(false);
            this.panelPlayerInfo.PerformLayout();
            this.panelHP.ResumeLayout(false);
            this.panelHP.PerformLayout();
            this.panelMonsInfo.ResumeLayout(false);
            this.panelMonsInfo.PerformLayout();
            this.panelSample.ResumeLayout(false);
            this.panelSample.PerformLayout();
            this.panelBodyParts.ResumeLayout(false);
            this.panelBodyParts.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Label labelHitCountTitle;
        private Label labelHitCountsValue;
        private Panel panelPlayerInfo;
        private Label labelTimeValue1;
        private Label labelTime1;
        private Label labelPlayerAtk;
        private Label label21;
        private Panel panelHP;
        private Label labelMonHP4;
        private Label labelMonHP3;
        private Label labelMonHP2;
        private Label labelMonHP1;
        private Label labelMonN4;
        private Label labelMonN3;
        private Label labelMonN2;
        private Label labelMonN1;
        private Panel panelMonsInfo;
        private Label labelAtkTitle;
        private Label AtkDefTitle;
        private Label labelAtkValue;
        private Label label26;
        private Label label25;
        private Label label24;
        private Label label23;
        private Label label22;
        private Label labelStun;
        private Label labelBlast;
        private Label labelPara;
        private Label labelSleep;
        private Label labelPoison;
        private Label labelDefValue;
        private Panel panelSample;
        private Panel panelBodyParts;
        private Label labelBP10;
        private Label labelBP9;
        private Label labelBP8;
        private Label labelBP7;
        private Label labelBP6;
        private Label labelBP5;
        private Label labelBP4;
        private Label labelBP3;
        private Label labelBP2;
        private Label labelBP1;
        private Label labelSize;
        private Label label34;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem openConfigToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Label labelSampleDmg3;
        private Label labelSampleDmg2;
        private Label labelSampleDmg1;
    }
}