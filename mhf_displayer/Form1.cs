using Memory;
using Dictionary;
using System.Diagnostics;

namespace mhf_displayer
{
	public partial class Form1 : Form
	{
        public Form1()
		{
			InitializeComponent();
		}

        Mem m = new Mem();

        long adrf;
        UIntPtr adr4;
        bool alreadyExist = false;
        int monsterHPValue;
        string cfgFileName = "mhf_displayer.cfg";
        int timeType2;
        int timeFormat2;
        string moduleName;
        int curNum = 0;
        int prevNum = 0;
        bool isFirstAttack = false;
        int showDamage;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
			this.BackColor = Color.LimeGreen;
            this.Location = new Point(0, 0);
            panel1.BackColor = Color.LimeGreen;

            string cfgPos = File.ReadLines(cfgFileName).ElementAt(5);
            string cfgPos1 = "position=";
            string cfgPos2 = cfgPos.Substring(cfgPos.IndexOf(cfgPos1) + cfgPos1.Length);

            switch(cfgPos2)
            {
                case "1":
                    {
                        panel1.Location = new Point(265, 90);
                        break;
                    }
                case "2":
                    {
                        panel1.Location = new Point(10, 240);
                        break;
                    }
                case "3":
                    {
                        panel1.Location = new Point(1550, 700);
                        break;
                    }
                case "4":
                    {
                        string posX = File.ReadLines(cfgFileName).ElementAt(7);
                        string posX1 = "x=";
                        int posX2 = Convert.ToInt16(posX.Substring(posX.IndexOf(posX1) + posX1.Length));
                        string posY = File.ReadLines(cfgFileName).ElementAt(8);
                        string posY1 = "y=";
                        int posY2 = Convert.ToInt16(posY.Substring(posY.IndexOf(posY1) + posY1.Length));
                        panel1.Location = new Point(posX2, posY2);
                        break;
                    }
                    default:
                    {
                        MessageBox.Show("Could not load config file.");
                        this.Close();
                        break;
                    }
            }

            string timeType = File.ReadLines(cfgFileName).ElementAt(12);
            string timeType1 = "type=";
            timeType2 = Convert.ToInt16(timeType.Substring(timeType.IndexOf(timeType1) + timeType1.Length));

            string timeFormat = File.ReadLines(cfgFileName).ElementAt(14);
            string timeFormat1 = "format=";
            timeFormat2 = Convert.ToInt16(timeFormat.Substring(timeFormat.IndexOf(timeFormat1) + timeFormat1.Length));

            string isShowDamage = File.ReadLines(cfgFileName).ElementAt(18);
            string isShowDamage1 = "show=";
            int showDamage = Convert.ToInt16(isShowDamage.Substring(isShowDamage.IndexOf(isShowDamage1) + isShowDamage1.Length));



            int PID = m.GetProcIdFromName("mhf");
			if (PID > 0)
			{
				m.OpenProcess(PID);

                adrf = m.AoBScan("0F BF D1 31 D0 A3 ?? ?? ?? ?? E9 ?? ?? ?? ??").Result.FirstOrDefault();
                string adr = adrf.ToString("X8");

                if (adr == "00000000")
                {
                    long adr1 = m.AoBScan("0F B7 8a 24 06 00 00 0f b7 ?? ?? ?? c1 c1 e1 0b").Result.FirstOrDefault();
                    adr1 = adr1 + 58;
                    long adr2 = adr1 + 5;

                    UIntPtr adr3 = m.CreateCodeCave(adr1.ToString("X8"), new byte[] { 0x0F, 0xBF, 0xD1, 0x31, 0xD0, 0xA3, 0x2A, 0x00, 0x80, 0x00 }, 5, 0x100);
                    m.WriteMemory(adr2.ToString("X8"), "bytes", "C3");

                    adr4 = adr3 + 20;
                    string str = adr4.ToString("X8");
                    byte[] data = Enumerable.Range(0, str.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(str.Substring(x, 2), 16)).ToArray();
                    Array.Reverse(data, 0, data.Length);
                    UIntPtr adr5 = adr3 + 6;
                    m.WriteBytes(adr5, data);
                }
                else
                {
                    //prevent from creating another codecave
                    alreadyExist = true;
                    adrf = adrf + 20;
                }

                timer1.Start();

                Process proc = Process.GetProcessById(PID);
                var list = new List<string>();
                foreach (ProcessModule md in proc.Modules)
                {
                    list.Add(md.ModuleName);
                }

                if (list.Contains("mhfo.dll"))
                {
                    moduleName = "mhfo.dll";
                }
                else
                {
                    moduleName = "mhfo-hd.dll";
                }


            }
            else
            {
				MessageBox.Show("Launch game first");
                this.Close();
            }

		}

        void FadeOut(Label label)
        {
            var t = new System.Windows.Forms.Timer();
            t.Interval = 2000; // it will Tick in 3 seconds
            t.Tick += (s, e) =>
            {
                label.Hide();
                t.Stop();
            };
            t.Start();
        }

        void CreateLabel(int damage)
        {
            Label namelabel = new Label();
            Random rnd = new Random();
            int x = rnd.Next(960 - 250, 960 + 250);
            int y = rnd.Next(540 - 150, 540 + 50);
            namelabel.Location = new Point(x, y);
            namelabel.BringToFront();
            namelabel.Text = damage.ToString();
            namelabel.Font = new Font("Comic Sans MS", 17);
            namelabel.ForeColor = Color.Lime;
            namelabel.BackColor = Color.Transparent;
            namelabel.AutoSize = true;
            this.Controls.Add(namelabel);
            FadeOut(namelabel);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //HP
            if (alreadyExist)
            {
                monsterHPValue = m.Read2Byte(adrf.ToString("X8"));
            }
            else
            {
                monsterHPValue = m.Read2Byte(adr4.ToString("X8"));
            }
            labelHPValue.Text = monsterHPValue.ToString();

            //Atk and Def
            float atk = m.ReadFloat("mhfo-hd.dll+0E37DD38,898");
            float def = m.ReadFloat("mhfo-hd.dll+0E37DD38,89C");
            labelAtkValue.Text = atk.ToString();
            labelDefValue.Text = def.ToString();

            //Moster name
            int monsterID = m.ReadByte("mhfo-hd.dll+0E37DD38,3");
            List.MonsterID.TryGetValue(monsterID, out string monsterName);
            if (atk == 0)
            {
                monsterName = "None";
            }
            labelMonName.Text = monsterName + ":";

            //HitCounts
            int hitCounts = m.Read2Byte("mhfo-hd.dll+ECB2DC6");
            labelHitCountsValue.Text = hitCounts.ToString();


            //Time
            int timeDef = m.ReadInt("mhfo-hd.dll+2AFA820");
            int time = m.ReadInt("mhfo-hd.dll+E7FE170");
            switch (timeType2)
            {
                case 1:
                    labelTime1.Text = "Remaining Time:";
                    switch (timeFormat2)
                    {
                        case 1:
                            int seconds = (time / 30) % 60;
                            int minutes = (time / 30) / 60;
                            string time1 = minutes + ":" + seconds;
                            labelTimeValue1.Text = time1;
                            break;

                        case 2:
                            labelTimeValue1.Text = (time / 30).ToString();
                            break;

                        case 3:
                            labelTimeValue1.Text = time.ToString();
                            break;
                    }
                    break;

                case 2:
                    labelTime1.Text = "Elapsed Time";
                    switch (timeFormat2)
                    {
                        case 1:
                            int timeEla = timeDef - time;
                            int seconds1 = (timeEla / 30) % 60;
                            int minutes1 = (timeEla / 30) / 60;
                            string time2 = minutes1 + ":" + seconds1;
                            labelTimeValue1.Text = time2;
                            break;

                        case 2:
                            labelTimeValue1.Text = ((timeDef - time) / 30).ToString();
                            break;

                        case 3:
                            labelTimeValue1.Text = (timeDef - time).ToString();
                            break;
                    }
                    break;
            }


            //Damage
            if (showDamage == 1)
            {
                int damage = 0;
                if (hitCounts == 0)
                {
                    curNum = 0;
                    prevNum = 0;
                    isFirstAttack = true;
                }
                else
                {
                    damage = m.Read2Byte("mhfo-hd.dll+E8DCF18");
                }

                if (prevNum != damage)
                {
                    curNum = damage - prevNum;
                    if (isFirstAttack)
                    {
                        isFirstAttack = false;
                        CreateLabel(damage);
                    }
                    else if (curNum < 0)
                    {
                        curNum = 1000 + curNum;
                        CreateLabel(curNum);
                    }
                    else
                    {
                        if (curNum != damage)
                        {
                            CreateLabel(curNum);
                        }
                    }
                }
                prevNum = damage;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}