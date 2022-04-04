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

        string cfgFileName = "mhf_displayer.cfg";
        int curNum = 0;
        int prevNum = 0;
        bool isFirstAttack = false;
        int hitCounts = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            panelConfig.Visible = false;
            this.TopMost = true;
            this.BackColor = Color.LimeGreen;
            this.Location = new Point(0, 0);
            panelPlayerInfo.BackColor = Color.LimeGreen;
            panelHP.BackColor = Color.LimeGreen;
            panelMonsInfo.BackColor = Color.LimeGreen;
            panelPlayerInfo.Location = new Point(0, 0);
            panelHP.Location = new Point(0, 0);
            panelMonsInfo.Location = new Point(0, 0);
            panelSample.Visible = false;

            LoadConfig();
            int PID = m.GetProcIdFromName("mhf");
            if (PID > 0)
            {
                m.OpenProcess(PID);
                long searchAddress = m.AoBScan("89 04 8D 00 C6 43 00 61 E9").Result.FirstOrDefault();
                if (searchAddress.ToString("X8") == "00000000")
                {
                    //long adr1 = m.AoBScan("0F B7 8a 24 06 00 00 0f b7 ?? ?? ?? c1 c1 e1 0b").Result.FirstOrDefault();
                    //adr1 = adr1 + 58;
                    //long adr2 = adr1 + 5;

                    //UIntPtr adr3 = m.CreateCodeCave(adr1.ToString("X8"), new byte[] { 0x0F, 0xBF, 0xD1, 0x31, 0xD0, 0xA3, 0x2A, 0x00, 0x80, 0x00 }, 5, 0x100);
                    //m.WriteMemory(adr2.ToString("X8"), "bytes", "C3");      //write ret

                    //adr4 = adr3 + 20;       //stored hp location
                    //string str = adr4.ToString("X8");
                    //byte[] data = Enumerable.Range(0, str.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(str.Substring(x, 2), 16)).ToArray();
                    //Array.Reverse(data, 0, data.Length);
                    //UIntPtr adr5 = adr3 + 6;
                    //m.WriteBytes(adr5, data);

                    //Create codecave and get its address
                    long baseScanAddress = m.AoBScan("0F B7 8a 24 06 00 00 0f b7 ?? ?? ?? c1 c1 e1 0b").Result.FirstOrDefault();
                    UIntPtr codecaveAddress = m.CreateCodeCave(baseScanAddress.ToString("X8"), new byte[] { 0x0F, 0xB7, 0x8A, 0x24, 0x06, 0x00, 0x00, 0x0F, 0xB7, 0x52, 0x0C, 0x88, 0x15, 0x21, 0x00, 0x0F, 0x15, 0x8B, 0xC1, 0xC1, 0xE1, 0x0B, 0x0F, 0xBF, 0xC9, 0xC1, 0xE8, 0x05, 0x09, 0xC8, 0x01, 0xD2, 0xB9, 0x8E, 0x76, 0x21, 0x25, 0x29, 0xD1, 0x66, 0x8B, 0x11, 0x66, 0xF7, 0xD2, 0x0F, 0xBF, 0xCA, 0x0F, 0xBF, 0x15, 0xC4, 0x22, 0xEA, 0x17, 0x31, 0xC8, 0x31, 0xD0, 0xB9, 0xC0, 0x5E, 0x73, 0x16, 0x0F, 0xBF, 0xD1, 0x31, 0xD0, 0x60, 0x8B, 0x0D, 0x21, 0x00, 0x0F, 0x15, 0x89, 0x04, 0x8D, 0x00, 0xC6, 0x43, 0x00, 0x61 }, 63, 0x100);

                    //Search and get mhfo-hd.dll module base address
                    int index = 0;
                    Process proc = Process.GetProcessById(PID);
                    var ModuleList = new List<string>();
                    foreach (ProcessModule md in proc.Modules)
                    {
                        ModuleList.Add(md.ModuleName);
                    }
                    if (ModuleList.Contains("mhfo-hd.dll"))
                    {
                        index = ModuleList.IndexOf("mhfo-hd.dll");
                    }
                    ProcessModule myModule;
                    ProcessModuleCollection myProcessModuleCollection = proc.Modules;
                    myModule = myProcessModuleCollection[index];
                    IntPtr baseAddressIntPtr = myModule.BaseAddress;
                    int baseAddressInt = (int)baseAddressIntPtr;
                    long baseAddress = baseAddressInt;

                    //m.WriteBytes(アドレス(string), 書き込むバイト配列);
                    //Change addresses
                    UIntPtr storeValueAddress = codecaveAddress + 125;                  //address where store some value?
                    string storeValueAddressString = storeValueAddress.ToString("X8");
                    byte[] storeValueAddressByte = Enumerable.Range(0, storeValueAddressString.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(storeValueAddressString.Substring(x, 2), 16)).ToArray();
                    Array.Reverse(storeValueAddressByte, 0, storeValueAddressByte.Length);
                    byte[] by15 = { 136, 21 };
                    m.WriteBytes(codecaveAddress + 11, by15);
                    m.WriteBytes(codecaveAddress + 13, storeValueAddressByte);  //1
                    m.WriteBytes(codecaveAddress + 72, storeValueAddressByte);  //2

                    long address = baseAddress + 249263758;
                    string addressString = address.ToString("X8");
                    byte[] addressByte = Enumerable.Range(0, addressString.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(addressString.Substring(x, 2), 16)).ToArray();
                    Array.Reverse(addressByte, 0, addressByte.Length);
                    m.WriteBytes(codecaveAddress + 33, addressByte);  //3

                    long address2 = baseAddress + 27534020;
                    addressString = address2.ToString("X8");
                    addressByte = Enumerable.Range(0, addressString.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(addressString.Substring(x, 2), 16)).ToArray();
                    Array.Reverse(addressByte, 0, addressByte.Length);
                    m.WriteBytes(codecaveAddress + 51, addressByte);  //4

                    long address3 = baseAddress + 2973376;
                    addressString = address3.ToString("X8");
                    addressByte = Enumerable.Range(0, addressString.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(addressString.Substring(x, 2), 16)).ToArray();
                    Array.Reverse(addressByte, 0, addressByte.Length);
                    m.WriteBytes(codecaveAddress + 60, addressByte);  //5
                }
                timer1.Start();
            }
            else
            {
                MessageBox.Show("Launch game first");
                this.Close();
            }
        }

        int showPlayerInfo;
        int playerInfoPanelx;
        int playerInfoPanely;
        int timetype;
        int timeformat;
        int atkFormat;
        int showHP;
        int HPPanelx;
        int HPPanely;
        int showMonsterInfo;
        int monsterInfoPanelx;
        int monsterInfoPanely;
        int configPanelx;
        int configPanely;
        int showDamage;
        int centerx;
        int centery;
        int height;
        int width;
        int damageTextSize;


        void LoadConfig()
        {
            //playerinfo
            string line = File.ReadLines(cfgFileName).ElementAt(1);
            string text = "show=";
            string value = line.Substring(line.IndexOf(text) + text.Length);
            comboBox1.SelectedIndex = Convert.ToInt16(value);
            showPlayerInfo = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(2);
            text = "x=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            numericUpDown1.Value = Convert.ToInt16(value);
            playerInfoPanelx = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(3);
            text = "y=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            numericUpDown2.Value = Convert.ToInt16(value);
            playerInfoPanely = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(4);
            text = "type=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            comboBox4.SelectedIndex = Convert.ToInt16(value);
            timetype = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(5);
            text = "format=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            comboBox6.SelectedIndex = Convert.ToInt16(value);
            timeformat = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(6);
            text = "atk=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            comboBox5.SelectedIndex = Convert.ToInt16(value);
            atkFormat = Convert.ToInt16(value);

            if (showPlayerInfo == 0)
            {
                panelPlayerInfo.Visible = true;
                panelPlayerInfo.Location = new Point(playerInfoPanelx, playerInfoPanely);
            }
            else
            {
                panelPlayerInfo.Visible = false;
            }

            //hp
            line = File.ReadLines(cfgFileName).ElementAt(8);
            text = "show=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            comboBox2.SelectedIndex = Convert.ToInt16(value);
            showHP = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(9);
            text = "x=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            numericUpDown4.Value = Convert.ToInt16(value);
            HPPanelx = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(10);
            text = "y=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            numericUpDown3.Value = Convert.ToInt16(value);
            HPPanely = Convert.ToInt16(value);

            if (showHP == 0)
            {
                panelHP.Visible = true;
                panelHP.Location = new Point(HPPanelx, HPPanely);
            }
            else
            {
                panelHP.Visible = false;
            }

            //monsterinfo
            line = File.ReadLines(cfgFileName).ElementAt(12);
            text = "show=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            comboBox3.SelectedIndex = Convert.ToInt16(value);
            showMonsterInfo = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(13);
            text = "x=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            numericUpDown6.Value = Convert.ToInt16(value);
            monsterInfoPanelx = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(14);
            text = "y=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            numericUpDown5.Value = Convert.ToInt16(value);
            monsterInfoPanely = Convert.ToInt16(value);

            if (showMonsterInfo == 0)
            {
                panelMonsInfo.Visible = true;
                panelHP.Location = new Point(monsterInfoPanelx, monsterInfoPanely);
            }
            else
            {
                panelMonsInfo.Visible = false;
            }

            //config menu
            line = File.ReadLines(cfgFileName).ElementAt(16);
            text = "x=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            numericUpDown8.Value = Convert.ToInt16(value);
            configPanelx = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(17);
            text = "y=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            numericUpDown7.Value = Convert.ToInt16(value);
            configPanely = Convert.ToInt16(value);

            panelConfig.Location = new Point(configPanelx, configPanely);

            //overall

            //damage
            line = File.ReadLines(cfgFileName).ElementAt(23);
            text = "show=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            comboBox7.SelectedIndex = Convert.ToInt16(value);
            showDamage = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(24);
            text = "centerx=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            numericUpDown13.Value = Convert.ToInt16(value);
            centerx = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(25);
            text = "centery=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            numericUpDown12.Value = Convert.ToInt16(value);
            centery = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(26);
            text = "height-=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            numericUpDown14.Value = Convert.ToInt16(value);
            height = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(27);
            text = "width+=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            numericUpDown15.Value = Convert.ToInt16(value);
            width = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(28);
            text = "size=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            numericUpDown18.Value = Convert.ToInt16(value);
            damageTextSize = Convert.ToInt16(value);
        }

        void ReloadUI()
        {
            showPlayerInfo = comboBox1.SelectedIndex;
            timetype = comboBox4.SelectedIndex;
            timeformat = comboBox6.SelectedIndex;
            atkFormat = comboBox5.SelectedIndex;
            panelPlayerInfo.Location = new Point((int)numericUpDown1.Value, (int)numericUpDown2.Value);

            showHP = comboBox2.SelectedIndex;
            if (showHP == 0)
            {
                panelHP.Visible = true;
            }
            else
            {
                panelHP.Visible = false;
            }
            panelHP.Location = new Point((int)numericUpDown4.Value, (int)numericUpDown3.Value);

            showMonsterInfo = comboBox3.SelectedIndex;
            if (showMonsterInfo == 0)
            {
                panelMonsInfo.Visible = true;
            }
            else
            {
                panelMonsInfo.Visible = false;
            }
            panelMonsInfo.Location = new Point((int)numericUpDown6.Value, (int)numericUpDown5.Value);

            panelConfig.Location = new Point((int)numericUpDown8.Value, (int)numericUpDown7.Value);

            centerx = (int)numericUpDown13.Value;
            centery = (int)numericUpDown12.Value;
            height = (int)numericUpDown14.Value;
            width = (int)numericUpDown15.Value;
            panelSample.Size = new Size(width, height);
            panelSample.Location = new Point(centerx, centery);
            if (comboBox8.SelectedIndex == 0)
            {
                panelSample.Visible = true;
            }
            else
            {
                panelSample.Visible = false;
            }

            damageTextSize = (int)numericUpDown18.Value;
        }

        void DeleteLabel(Label label)
        {
            var t = new System.Windows.Forms.Timer();
            t.Interval = 2000;  //1000=1sec
            t.Tick += (s, e) =>
            {
                this.Controls.Remove(label);
                t.Stop();
            };
            t.Start();
        }

        void CreateLabel(int damage)
        {
            Label namelabel = new Label();
            Random rnd = new Random();
            int x = rnd.Next(centerx , centerx + width );
            int y = rnd.Next(centery , centery + height);
            namelabel.Location = new Point(x, y);
            namelabel.BringToFront();
            namelabel.Text = damage.ToString();
            namelabel.Font = new Font("Comic Sans MS", damageTextSize);
            namelabel.ForeColor = Color.Lime;
            namelabel.BackColor = Color.Transparent;
            namelabel.AutoSize = true;
            this.Controls.Add(namelabel);
            DeleteLabel(namelabel);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            hitCounts = m.Read2Byte("mhfo-hd.dll+ECB2DC6");
            if (showPlayerInfo == 0)
            {
                labelHitCountTitle.Visible = true;
                labelTime1.Visible = true;
                labelPlayerAtk.Visible = true;
                labelHitCountsValue.Visible = true;
                labelTimeValue1.Visible = true;
                label21.Visible = true;
                //HitCounts
                labelHitCountsValue.Text = hitCounts.ToString();

                //Time
                int timeDef = m.ReadInt("mhfo-hd.dll+2AFA820");
                int time = m.ReadInt("mhfo-hd.dll+E7FE170");
                switch (timetype)
                {
                    case 0:
                        labelTime1.Text = "Remaining Time:";
                        switch (timeformat)
                        {
                            case 0:
                                int seconds = (time / 30) % 60;
                                int minutes = (time / 30) / 60;
                                string time1 = minutes + ":" + seconds;
                                labelTimeValue1.Text = time1;
                                break;

                            case 1:
                                labelTimeValue1.Text = (time / 30).ToString();
                                break;

                            case 2:
                                labelTimeValue1.Text = time.ToString();
                                break;
                        }
                        break;

                    case 1:
                        labelTime1.Text = "Elapsed Time";
                        switch (timeformat)
                        {
                            case 0:
                                int timeEla = timeDef - time;
                                int seconds1 = (timeEla / 30) % 60;
                                int minutes1 = (timeEla / 30) / 60;
                                string time2 = minutes1 + ":" + seconds1;
                                labelTimeValue1.Text = time2;
                                break;

                            case 1:
                                labelTimeValue1.Text = ((timeDef - time) / 30).ToString();
                                break;

                            case 2:
                                labelTimeValue1.Text = (timeDef - time).ToString();
                                break;
                        }
                        break;
                }

                //PlayerAtk
                int raw = m.Read2Byte("mhfo-hd.dll+DC6BEFA");
                int wepType = m.ReadByte("mhfo-hd.dll+ED3A466");
                float mul = 0f;
                switch (wepType)
                {
                    case 0:
                    case 1:
                        mul = 1.4f;
                        break;
                    case 2:
                    case 3:
                        mul = 4.8f;
                        break;
                    case 4:
                    case 5:
                        mul = 5.2f;
                        break;
                    case 6:
                    case 7:
                        mul = 2.3f;
                        break;
                    case 8:
                    case 9:
                    case 10:
                    case 22:
                        mul = 1.2f;
                        break;
                    case 34:
                    case 36:
                        mul = 5.4f;
                        break;
                    case 35:
                        mul = 1.8f;
                        break;
                    default:
                        mul = 1f;
                        break;
                }
                if (atkFormat == 0)
                {
                    label21.Visible = true;
                    labelPlayerAtk.Visible = true;
                    labelPlayerAtk.Text = Math.Floor((raw * mul)).ToString();
                }
                else if (atkFormat == 1)
                {
                    label21.Visible = true;
                    labelPlayerAtk.Visible = true;
                    labelPlayerAtk.Text = raw.ToString();
                }
                else
                {
                    label21.Visible = false;
                    labelPlayerAtk.Visible = false;
                }
            }
            else
            {
                labelHitCountTitle.Visible = false;
                labelTime1.Visible = false;
                labelPlayerAtk.Visible = false;
                labelHitCountsValue.Visible = false;
                labelTimeValue1.Visible = false;
                label21.Visible = false;
            }

            if (showHP == 0)
            {
                int largeMonster1 = m.ReadByte("mhfo-hd.dll+1BEF354");
                int largeMonster2 = m.ReadByte("mhfo-hd.dll+1BEF35C");
                int largeMonster3 = m.ReadByte("mhfo-hd.dll+1BEF364");
                int largeMonster4 = m.ReadByte("mhfo-hd.dll+1BEF36C");
                int monsterHPValue;

                if (largeMonster1 != 0)
                {
                    labelMonN1.Visible = true;
                    labelMonHP1.Visible = true;
                    List.MonsterID.TryGetValue(largeMonster1, out string monsterName1);
                    labelMonN1.Text = monsterName1 + ":";
                    monsterHPValue = m.Read2Byte("0043C600");
                    labelMonHP1.Text = monsterHPValue.ToString();
                }
                else
                {
                    labelMonN1.Visible = false;
                    labelMonHP1.Visible = false;
                }

                if (largeMonster2 != 0)
                {
                    labelMonN2.Visible = true;
                    labelMonHP2.Visible = true;
                    List.MonsterID.TryGetValue(largeMonster2, out string monsterName2);
                    labelMonN2.Text = monsterName2 + ":";
                    monsterHPValue = m.Read2Byte("0043C604");
                    labelMonHP2.Text = monsterHPValue.ToString();
                }
                else
                {
                    labelMonN2.Visible = false;
                    labelMonHP2.Visible = false;
                }

                if (largeMonster3 != 0)
                {
                    labelMonN3.Visible = true;
                    labelMonHP3.Visible = true;
                    List.MonsterID.TryGetValue(largeMonster3, out string monsterName3);
                    labelMonN3.Text = monsterName3 + ":";
                    monsterHPValue = m.Read2Byte("0043C608");
                    labelMonHP3.Text = monsterHPValue.ToString();
                }
                else
                {
                    labelMonN3.Visible = false;
                    labelMonHP3.Visible = false;
                }

                if (largeMonster4 != 0)
                {
                    labelMonN4.Visible = true;
                    labelMonHP4.Visible = true;
                    List.MonsterID.TryGetValue(largeMonster4, out string monsterName4);
                    labelMonN4.Text = monsterName4 + ":";
                    monsterHPValue = m.Read2Byte("0043C60C");
                    labelMonHP4.Text = monsterHPValue.ToString();
                }
                else
                {
                    labelMonN4.Visible = false;
                    labelMonHP4.Visible = false;
                }
            }

            if (showMonsterInfo == 0)
            {
                float atk = m.ReadFloat("mhfo-hd.dll+0E37DD38,898");
                float def = m.ReadFloat("mhfo-hd.dll+0E37DD38,89C");
                labelAtkValue.Text = atk.ToString();
                labelDefValue.Text = def.ToString();
                int poison = m.Read2Byte("mhfo-hd.dll+0E37DD38,88A");
                int poisonMax = m.Read2Byte("mhfo-hd.dll+0E37DD38,888");
                int sleep = m.Read2Byte("mhfo-hd.dll+0E37DD38,86C");
                int sleepMax = m.Read2Byte("mhfo-hd.dll+0E37DD38,86A");
                int para = m.Read2Byte("mhfo-hd.dll+0E37DD38,886");
                int paraMax = m.Read2Byte("mhfo-hd.dll+0E37DD38,880");
                int blast = m.Read2Byte("mhfo-hd.dll+0E37DD38,D4A");
                int blastMax = m.Read2Byte("mhfo-hd.dll+0E37DD38,D48");
                int stun = m.Read2Byte("mhfo-hd.dll+0E37DD38,872");
                int stunMax = m.Read2Byte("mhfo-hd.dll+0E37DD38,A74");
                labelPoison.Text = poison.ToString() + "/" + poisonMax.ToString();
                labelSleep.Text = sleep.ToString() + "/" + sleepMax.ToString();
                labelPara.Text = para.ToString() + "/" + paraMax.ToString();
                labelBlast.Text = blast.ToString() + "/" + blastMax.ToString();
                labelStun.Text = stun.ToString() + "/" + stunMax.ToString();
            }

            if (showDamage == 0)
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

        private void buttonShutdown_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonConfig_Click(object sender, EventArgs e)
        {
            panelConfig.Visible = true;
            //panelConfig.BringToFront();

            groupBox5.Visible = false;
            comboBox8.SelectedIndex = 1;
            ReloadUI();
        }

        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit] = newText;
            File.WriteAllLines(fileName, arrLine);
        }

        private void buttonCloseConfig_Click(object sender, EventArgs e)
        {
            panelConfig.Visible = false;
            comboBox8.SelectedIndex = 0;
            panelSample.Visible = false;

            lineChanger("show=" + comboBox1.SelectedIndex.ToString(), cfgFileName, 1);
            lineChanger("x=" + numericUpDown1.Value.ToString(), cfgFileName, 2);
            lineChanger("y=" + numericUpDown2.Value.ToString(), cfgFileName, 3);
            lineChanger("type=" + comboBox4.SelectedIndex.ToString(), cfgFileName, 4);
            lineChanger("format=" + comboBox6.SelectedIndex.ToString(), cfgFileName,5);
            lineChanger("atk=" + comboBox5.SelectedIndex.ToString(), cfgFileName, 6);

            lineChanger("show=" + comboBox2.SelectedIndex.ToString(), cfgFileName, 8);
            lineChanger("x=" + numericUpDown4.Value.ToString(), cfgFileName, 9);
            lineChanger("y=" + numericUpDown3.Value.ToString(), cfgFileName, 10);

            lineChanger("show=" + comboBox3.SelectedIndex.ToString(), cfgFileName, 12);
            lineChanger("x=" + numericUpDown6.Value.ToString(), cfgFileName, 13);
            lineChanger("y=" + numericUpDown5.Value.ToString(), cfgFileName, 14);

            lineChanger("x=" + numericUpDown8.Value.ToString(), cfgFileName, 16);
            lineChanger("y=" + numericUpDown7.Value.ToString(), cfgFileName, 17);

            lineChanger("show=" + comboBox7.SelectedIndex.ToString(), cfgFileName, 23);
            lineChanger("centerx=" + numericUpDown13.Value.ToString(), cfgFileName, 24);
            lineChanger("centery=" + numericUpDown12.Value.ToString(), cfgFileName, 25);
            lineChanger("height=" + numericUpDown14.Value.ToString(), cfgFileName, 26);
            lineChanger("width=" + numericUpDown15.Value.ToString(), cfgFileName, 27);
            lineChanger("size=" + numericUpDown18.Value.ToString(), cfgFileName, 28);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void numericUpDown13_ValueChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void numericUpDown12_ValueChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void numericUpDown14_ValueChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void numericUpDown15_ValueChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void numericUpDown18_ValueChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }
    }
}