using Dictionary;
using Memory;
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

        int curNum = 0;
        int prevNum = 0;
        bool isFirstAttack = false;
        int hitCounts = 0;
        bool isHGE = false;
        int index = 0;
        int PID = 0;
        Process proc;
        int selectedMonsterNo = 1;   //1,2,3,4
        bool isRoad = false;
        int xPos;
        int yPos;
        string cfgFileName = "mhf_displayer.cfg";

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
        int damageTextSize  = 9;
        int ShowBP;
        int BPPanelx;
        int BPPanely;
        int showatk;
        string textfont = "";
        int textsize = 9;
        string textcolor = "Black";
        int showSample = 1;
        int isHide;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.Location = new Point(0, 0);
            ShowInTaskbar = false;

            panelPlayerInfo.BackColor = Color.Transparent;
            panelPlayerInfo.Location = new Point(1000, 150);
            panelPlayerInfo.MouseDown += new MouseEventHandler(panel_MouseDown);
            panelPlayerInfo.MouseMove += new MouseEventHandler(panel_MouseMove);

            panelHP.BackColor = Color.Transparent;
            panelHP.Location = new Point(0, 0);
            panelHP.MouseDown += new MouseEventHandler(panel_MouseDown);
            panelHP.MouseMove += new MouseEventHandler(panel_MouseMove);

            panelMonsInfo.Location = new Point(0, 0);
            panelMonsInfo.BackColor = Color.Transparent;
            panelMonsInfo.MouseDown += new MouseEventHandler(panel_MouseDown);
            panelMonsInfo.MouseMove += new MouseEventHandler(panel_MouseMove);

            panelSample.Visible = false;

            panelBodyParts.BackColor = Color.Transparent;
            panelBodyParts.Location = new Point(0, 0);
            panelBodyParts.MouseDown += new MouseEventHandler(panel_MouseDown);
            panelBodyParts.MouseMove += new MouseEventHandler(panel_MouseMove);

            panelConfig.Visible = false;
            panelConfig.MouseDown += new MouseEventHandler(panel_MouseDown);
            panelConfig.MouseMove += new MouseEventHandler(panel_MouseMove);

            labelMonN1.Visible = false;
            labelMonHP1.Visible = false;
            labelMonN2.Visible = false;
            labelMonHP2.Visible = false;
            labelMonN3.Visible = false;
            labelMonHP3.Visible = false;
            labelMonN4.Visible = false;
            labelMonHP4.Visible = false;

            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                comTextFont.Items.Add(font.Name);
            }

            foreach (System.Reflection.PropertyInfo prop in typeof(Color).GetProperties())
            {
                if (prop.PropertyType.FullName == "System.Drawing.Color")
                    comboBox11.Items.Add(prop.Name);
            }

            PID = m.GetProcIdFromName("mhf");
            if (PID > 0)
            {
                GetDllInfo();

                m.OpenProcess(PID);
                long searchAddress = m.AoBScan("89 04 8D 00 C6 43 00 61 E9").Result.FirstOrDefault();
                if (searchAddress.ToString("X8") == "00000000")
                {
                    //Create codecave and get its address
                    long baseScanAddress = m.AoBScan("0F B7 8a 24 06 00 00 0f b7 ?? ?? ?? c1 c1 e1 0b").Result.FirstOrDefault();
                    UIntPtr codecaveAddress = m.CreateCodeCave(baseScanAddress.ToString("X8"), new byte[] { 0x0F, 0xB7, 0x8A, 0x24, 0x06, 0x00, 0x00, 0x0F, 0xB7, 0x52, 0x0C, 0x88, 0x15, 0x21, 0x00, 0x0F, 0x15, 0x8B, 0xC1, 0xC1, 0xE1, 0x0B, 0x0F, 0xBF, 0xC9, 0xC1, 0xE8, 0x05, 0x09, 0xC8, 0x01, 0xD2, 0xB9, 0x8E, 0x76, 0x21, 0x25, 0x29, 0xD1, 0x66, 0x8B, 0x11, 0x66, 0xF7, 0xD2, 0x0F, 0xBF, 0xCA, 0x0F, 0xBF, 0x15, 0xC4, 0x22, 0xEA, 0x17, 0x31, 0xC8, 0x31, 0xD0, 0xB9, 0xC0, 0x5E, 0x73, 0x16, 0x0F, 0xBF, 0xD1, 0x31, 0xD0, 0x60, 0x8B, 0x0D, 0x21, 0x00, 0x0F, 0x15, 0x89, 0x04, 0x8D, 0x00, 0xC6, 0x43, 0x00, 0x61 }, 63, 0x100);

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

                    ProcessModule myModule;
                    ProcessModuleCollection myProcessModuleCollection = proc.Modules;
                    myModule = myProcessModuleCollection[index];
                    IntPtr baseAddressIntPtr = myModule.BaseAddress;
                    int baseAddressInt = (int)baseAddressIntPtr;
                    long baseAddress = baseAddressInt;

                    long address = 0;
                    long address2 = 0;
                    long address3 = 0;

                    if (isHGE)
                    {
                        address = baseAddress + 249263758;
                        address2 = baseAddress + 27534020;
                        address3 = baseAddress + 2973376;
                    }
                    else
                    {
                        address = baseAddress + 102223598;
                        address2 = baseAddress + 27601756;
                        address3 = baseAddress + 2865056;
                    }

                    string addressString = address.ToString("X8");
                    byte[] addressByte = Enumerable.Range(0, addressString.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(addressString.Substring(x, 2), 16)).ToArray();
                    Array.Reverse(addressByte, 0, addressByte.Length);
                    m.WriteBytes(codecaveAddress + 33, addressByte);  //3

                    addressString = address2.ToString("X8");
                    addressByte = Enumerable.Range(0, addressString.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(addressString.Substring(x, 2), 16)).ToArray();
                    Array.Reverse(addressByte, 0, addressByte.Length);
                    m.WriteBytes(codecaveAddress + 51, addressByte);  //4

                    addressString = address3.ToString("X8");
                    addressByte = Enumerable.Range(0, addressString.Length).Where(x => x % 2 == 0).Select(x => Convert.ToByte(addressString.Substring(x, 2), 16)).ToArray();
                    Array.Reverse(addressByte, 0, addressByte.Length);
                    m.WriteBytes(codecaveAddress + 60, addressByte);  //5
                }
                else
                {
                    GetDllInfo();
                }

                InitConfig();      //open config menu to load settings then close immediately
                if (!isHGE)
                {
                    timerNonHGE.Start();
                }
                else
                {
                    timerHGE.Start();
                }
            }
            else
            {
                MessageBox.Show("Launch game first");
                this.Close();
            }
        }

        int largeMonsterID1 = 0;
        int largeMonsterID2 = 0;
        int largeMonsterID3 = 0;
        int largeMonsterID4 = 0;
        bool isNormalQuest = true;
        int pattern = 0;

        private void timerNonHGE_Tick(object sender, EventArgs e)
        {
            //normal
            //int randomVal = m.ReadByte("mhfo.dll+60A3E58"); //0 if not in quest
            //int randomVal2 = m.ReadByte("mhfo.dll+5CA338C");
            int questID = m.Read2Byte("mhfo.dll+28C2C7E");      //0 if in lobby

            if (questID != 23527 && questID != 23628)
            {
                //Normal Quest
                largeMonsterID1 = m.ReadByte("mhfo.dll+4FD365F");
                largeMonsterID2 = m.ReadByte("mhfo.dll+4FD3660");
                largeMonsterID3 = m.ReadByte("mhfo.dll+4FD3661");
                largeMonsterID4 = m.ReadByte("mhfo.dll+4FD3662");
                labelHitCountTitle.Text = "normal";
                labelHitCountsValue.Text = largeMonsterID1.ToString();
                isNormalQuest = true;
            }
            else
            {
                //Hunter's Road
                largeMonsterID1 = m.ReadByte("mhfo.dll+1A98FC0");
                largeMonsterID2 = m.ReadByte("mhfo.dll+1A98FC4");
                largeMonsterID3 = 0;
                largeMonsterID4 = 0;
                labelHitCountTitle.Text = "road";
                labelHitCountsValue.Text = largeMonsterID1.ToString();
                isNormalQuest = false;
            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            int monsterHPValue = 0;
            if (largeMonsterID1 != 0 & largeMonsterID1 != 18)// && largeMonsterID1 != 18 && largeMonsterID1 != 10 && largeMonsterID1 != 255
            {
                labelMonN1.Visible = true;
                labelMonHP1.Visible = true;
                List.MonsterID.TryGetValue(largeMonsterID1, out string name);
                labelMonN1.Text = name + ":";
                monsterHPValue = m.Read2Byte("0043C600");
                labelMonHP1.Text = monsterHPValue.ToString();
            }
            //else
            //{
            //    labelMonN1.Visible = false;
            //    labelMonHP1.Visible = false;
            //}

            if (largeMonsterID2 != 0 & largeMonsterID2 != 18)// && largeMonsterID2 != 18 && largeMonsterID2 != 10 && largeMonsterID2 != 255
            {
                labelMonN2.Visible = true;
                labelMonHP2.Visible = true;
                List.MonsterID.TryGetValue(largeMonsterID2, out string name);
                labelMonN2.Text = name + ":";
                monsterHPValue = m.Read2Byte("0043C604");
                labelMonHP2.Text = monsterHPValue.ToString();
            }
            //else
            //{
            //    labelMonN2.Visible = false;
            //    labelMonHP2.Visible = false;
            //}

            if (largeMonsterID3 != 0 & largeMonsterID3 != 18)
            {
                labelMonN3.Visible = true;
                labelMonHP3.Visible = true;
                List.MonsterID.TryGetValue(largeMonsterID3, out string name);
                labelMonN3.Text = name + ":";
                monsterHPValue = m.Read2Byte("0043C608");
                labelMonHP3.Text = monsterHPValue.ToString();
            }
            //else
            //{
            //    labelMonN3.Visible = false;
            //    labelMonHP3.Visible = false;
            //}

            if (largeMonsterID4 != 0 & largeMonsterID4 != 18)
            {
                labelMonN4.Visible = true;
                labelMonHP4.Visible = true;
                List.MonsterID.TryGetValue(largeMonsterID4, out string name);
                labelMonN4.Text = name + ":";
                monsterHPValue = m.Read2Byte("0043C60C");
                labelMonHP4.Text = monsterHPValue.ToString();
            }
            //else
            //{
            //    labelMonN4.Visible = false;
            //    labelMonHP4.Visible = false;
            //}
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////
            int targetSelectionIndex = m.ReadByte("mhfo.dll+5BD5F20,18");
            switch (targetSelectionIndex)
            {
                case 0:
                    labelAtkValue.Text = m.ReadFloat("mhfo.dll+60A3E58,898").ToString();
                    labelDefValue.Text = m.ReadFloat("mhfo.dll+60A3E58,89C").ToString();
                    labelPoison.Text = m.Read2Byte("mhfo.dll+60A3E58,88A").ToString() + "/" + m.Read2Byte("mhfo.dll+60A3E58,888").ToString();
                    labelSleep.Text = m.Read2Byte("mhfo.dll+60A3E58,86C").ToString() + "/" + m.Read2Byte("mhfo.dll+60A3E58,86A").ToString();
                    labelPara.Text = m.Read2Byte("mhfo.dll+60A3E58,886").ToString() + "/" + m.Read2Byte("mhfo.dll+60A3E58,880").ToString();
                    labelBlast.Text = m.Read2Byte("mhfo.dll+60A3E58,D4A").ToString() + "/" + m.Read2Byte("mhfo.dll+60A3E58,D48").ToString();
                    labelStun.Text = m.Read2Byte("mhfo.dll+60A3E58,872").ToString() + "/" + m.Read2Byte("mhfo.dll+60A3E58,A74").ToString();
                    labelSize.Text = m.Read2Byte("mhfo.dll+28C2BD4").ToString() + "%";

                    labelBP1.Text = m.Read2Byte("mhfo.dll+60A3E58,348").ToString();
                    labelBP2.Text = m.Read2Byte("mhfo.dll+60A3E58,350").ToString();
                    labelBP3.Text = m.Read2Byte("mhfo.dll+60A3E58,358").ToString();
                    labelBP4.Text = m.Read2Byte("mhfo.dll+60A3E58,360").ToString();
                    labelBP5.Text = m.Read2Byte("mhfo.dll+60A3E58,368").ToString();
                    labelBP6.Text = m.Read2Byte("mhfo.dll+60A3E58,370").ToString();
                    labelBP7.Text = m.Read2Byte("mhfo.dll+60A3E58,378").ToString();
                    labelBP8.Text = m.Read2Byte("mhfo.dll+60A3E58,380").ToString();
                    labelBP9.Text = m.Read2Byte("mhfo.dll+60A3E58,388").ToString();
                    labelBP10.Text = m.Read2Byte("mhfo.dll+60A3E58,390").ToString();
                    break;
                case 1:
                    labelAtkValue.Text = m.ReadFloat("mhfo.dll+60A3E58,1788").ToString();
                    labelDefValue.Text = m.ReadFloat("mhfo.dll+60A3E58,178C").ToString();
                    labelPoison.Text = m.Read2Byte("mhfo.dll+60A3E58,177A").ToString() + "/" + m.Read2Byte("mhfo.dll+60A3E58,1778").ToString();
                    labelSleep.Text = m.Read2Byte("mhfo.dll+60A3E58,175C").ToString() + "/" + m.Read2Byte("mhfo.dll+60A3E58,175A").ToString();
                    labelPara.Text = m.Read2Byte("mhfo.dll+60A3E58,1776").ToString() + "/" + m.Read2Byte("mhfo.dll+60A3E58,1770").ToString();
                    labelBlast.Text = m.Read2Byte("mhfo.dll+60A3E58,1C3A").ToString() + "/" + m.Read2Byte("mhfo.dll+60A3E58,1C38").ToString();
                    labelStun.Text = m.Read2Byte("mhfo.dll+60A3E58,1762").ToString() + "/" + m.Read2Byte("mhfo.dll+60A3E58,1964").ToString();
                    labelSize.Text = m.Read2Byte("mhfo.dll+28C2BD4").ToString() + "%";

                    labelBP1.Text = m.Read2Byte("mhfo.dll+60A3E58,1238").ToString();
                    labelBP2.Text = m.Read2Byte("mhfo.dll+60A3E58,1240").ToString();
                    labelBP3.Text = m.Read2Byte("mhfo.dll+60A3E58,1248").ToString();
                    labelBP4.Text = m.Read2Byte("mhfo.dll+60A3E58,1250").ToString();
                    labelBP5.Text = m.Read2Byte("mhfo.dll+60A3E58,1258").ToString();
                    labelBP6.Text = m.Read2Byte("mhfo.dll+60A3E58,1260").ToString();
                    labelBP7.Text = m.Read2Byte("mhfo.dll+60A3E58,1268").ToString();
                    labelBP8.Text = m.Read2Byte("mhfo.dll+60A3E58,1270").ToString();
                    labelBP9.Text = m.Read2Byte("mhfo.dll+60A3E58,1278").ToString();
                    labelBP10.Text = m.Read2Byte("mhfo.dll+60A3E58,1280").ToString();
                    break;
                case 2:
                    panelMonsInfo.Visible = false;
                    break;
                case 3:
                    panelMonsInfo.Visible = false;
                    break;
                default:
                    panelMonsInfo.Visible = false;
                    break;
                    
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////
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
                    damage = m.Read2Byte("mhfo.dll+5CA3430");
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
            ///////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////
            panelSample.Size = new Size(width, height);
            panelSample.Location = new Point(centerx, centery);

            Font font = new Font(textfont, damageTextSize, FontStyle.Regular);
            labelSampleDmg1.Font = font;
            labelSampleDmg2.Font = font;
            labelSampleDmg3.Font = font;
            ///////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////
            //HitCounts
            hitCounts = m.Read2Byte("mhfo.dll+5CA3430");
            labelHitCountsValue.Text = hitCounts.ToString();

            //Time
            int timeDef;
            int time;
            timeDef = m.ReadInt("mhfo.dll+1B97780");
            time = m.ReadInt("mhfo.dll+5BC6540");
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
            int raw;
            int wepType;
            raw = m.Read2Byte("mhfo.dll+503433A");
            wepType = m.ReadByte("mhfo.dll+60FFCC6");
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            //HGE
            int randomVal = m.ReadByte("mhfo-hd.dll+E37DD38");
            int randomVal2 = m.ReadByte("mhfo-hd.dll+ECDE5F8");

            if (randomVal != 0)
            {
                pattern = 0;
            }
            else if (randomVal2 != 0)
            {
                pattern = 1;
            }

            int questID = m.Read2Byte("mhfo-hd.dll+2AFA82E");

            if (questID != 23527 && questID != 23628)
            {
                //Normal Quest
                largeMonsterID1 = m.ReadByte("mhfo-hd.dll+DC0B21F");
                largeMonsterID2 = m.ReadByte("mhfo-hd.dll+DC0B220");
                largeMonsterID3 = m.ReadByte("mhfo-hd.dll+DC0B221");
                largeMonsterID4 = m.ReadByte("mhfo-hd.dll+DC0B222");
                isNormalQuest = true;
            }
            else
            {
                //Hunter's Road
                largeMonsterID1 = m.ReadByte("mhfo-hd.dll+1A8872C");
                largeMonsterID2 = m.ReadByte("mhfo-hd.dll+1A88730");
                largeMonsterID3 = 0;
                largeMonsterID4 = 0;
                isNormalQuest = false;
            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (largeMonsterID1 != 0 & largeMonsterID1 != 18)
            {
                labelMonN1.Visible = true;
                labelMonHP1.Visible = true;
                List.MonsterID.TryGetValue(largeMonsterID1, out string name);
                labelMonN1.Text = name + ":";
                int monsterHPValue = m.Read2Byte("0043C600");
                labelMonHP1.Text = monsterHPValue.ToString();
            }

            if (largeMonsterID2 != 0 & largeMonsterID2 != 18)
            {
                labelMonN2.Visible = true;
                labelMonHP2.Visible = true;
                List.MonsterID.TryGetValue(largeMonsterID2, out string name);
                labelMonN2.Text = name + ":";
                int monsterHPValue = m.Read2Byte("0043C604");
                labelMonHP2.Text = monsterHPValue.ToString();
            }

            if (largeMonsterID3 != 0 & largeMonsterID3 != 18)
            {
                labelMonN3.Visible = true;
                labelMonHP3.Visible = true;
                List.MonsterID.TryGetValue(largeMonsterID3, out string name);
                labelMonN3.Text = name + ":";
                int monsterHPValue = m.Read2Byte("0043C608");
                labelMonHP3.Text = monsterHPValue.ToString();
            }

            if (largeMonsterID4 != 0 & largeMonsterID4 != 18)
            {
                labelMonN4.Visible = true;
                labelMonHP4.Visible = true;
                List.MonsterID.TryGetValue(largeMonsterID4, out string name);
                labelMonN4.Text = name + ":";
                int monsterHPValue = m.Read2Byte("0043C60C");
                labelMonHP4.Text = monsterHPValue.ToString();
            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            int targetSelectionIndex = m.ReadByte("mhfo-hd.dll+E80DB50,18");        //0 based
            switch (targetSelectionIndex)
            {
                case 0:
                    if (isNormalQuest)
                    {
                        if (pattern == 0)
                        {
                            labelAtkValue.Text = m.ReadFloat("mhfo-hd.dll+0E37DD38,898").ToString();
                            labelDefValue.Text = m.ReadFloat("mhfo-hd.dll+0E37DD38,89C").ToString();
                            labelPoison.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,88A").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+0E37DD38,888").ToString();
                            labelSleep.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,86C").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+0E37DD38,86A").ToString();
                            labelPara.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,886").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+0E37DD38,880").ToString();
                            labelBlast.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,D4A").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+0E37DD38,D48").ToString();
                            labelStun.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,872").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+0E37DD38,A74").ToString();
                            labelSize.Text = m.Read2Byte("mhfo-hd.dll+2AFA784").ToString() + "%";

                            labelBP1.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,348").ToString();
                            labelBP2.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,350").ToString();
                            labelBP3.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,358").ToString();
                            labelBP4.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,360").ToString();
                            labelBP5.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,368").ToString();
                            labelBP6.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,370").ToString();
                            labelBP7.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,378").ToString();
                            labelBP8.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,380").ToString();
                            labelBP9.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,388").ToString();
                            labelBP10.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,390").ToString();

                        }
                        else
                        {
                            labelAtkValue.Text = m.ReadFloat("mhfo-hd.dll+ECDE5F8,898").ToString();
                            labelDefValue.Text = m.ReadFloat("mhfo-hd.dll+ECDE5F8,89C").ToString();
                            labelPoison.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,88A").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,888").ToString();
                            labelSleep.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,86C").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,86A").ToString();
                            labelPara.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,886").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,880").ToString();
                            labelBlast.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,D4A").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,D48").ToString();
                            labelStun.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,872").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,A74").ToString();
                            labelSize.Text = m.Read2Byte("mhfo-hd.dll+2AFA784").ToString() + "%";

                            labelBP1.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,348").ToString();
                            labelBP2.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,350").ToString();
                            labelBP3.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,358").ToString();
                            labelBP4.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,360").ToString();
                            labelBP5.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,368").ToString();
                            labelBP6.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,370").ToString();
                            labelBP7.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,378").ToString();
                            labelBP8.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,380").ToString();
                            labelBP9.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,388").ToString();
                            labelBP10.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,390").ToString();
                        }
                    }
                    else
                    {
                        labelAtkValue.Text = m.ReadFloat("mhfo-hd.dll+ECDE5F8,898").ToString();
                        labelDefValue.Text = m.ReadFloat("mhfo-hd.dll+ECDE5F8,89C").ToString();
                        labelPoison.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,88A").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,888").ToString();
                        labelSleep.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,86C").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,86A").ToString();
                        labelPara.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,886").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,880").ToString();
                        labelBlast.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,D4A").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,D48").ToString();
                        labelStun.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,872").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,A74").ToString();
                        labelSize.Text = m.Read2Byte("mhfo-hd.dll+2AFA784").ToString() + "%";

                        labelBP1.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,348").ToString();
                        labelBP2.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,350").ToString();
                        labelBP3.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,358").ToString();
                        labelBP4.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,360").ToString();
                        labelBP5.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,368").ToString();
                        labelBP6.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,370").ToString();
                        labelBP7.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,378").ToString();
                        labelBP8.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,380").ToString();
                        labelBP9.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,388").ToString();
                        labelBP10.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,390").ToString();
                    }
                    break;
                case 1:
                    if (isNormalQuest)
                    {
                        if (pattern == 0)
                        {
                            labelAtkValue.Text = m.ReadFloat("mhfo-hd.dll+0E37DD38,1788").ToString();
                            labelDefValue.Text = m.ReadFloat("mhfo-hd.dll+0E37DD38,178C").ToString();
                            labelPoison.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,177A").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+0E37DD38,1778").ToString();
                            labelSleep.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,175C").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+0E37DD38,175A").ToString();
                            labelPara.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,1776").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+0E37DD38,1770").ToString();
                            labelBlast.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,1C3A").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+0E37DD38,1C38").ToString();
                            labelStun.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,1762").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+0E37DD38,1964").ToString();
                            labelSize.Text = m.Read2Byte("mhfo-hd.dll+2AFA784").ToString() + "%";

                            labelBP1.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,1238").ToString();
                            labelBP2.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,1240").ToString();
                            labelBP3.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,1248").ToString();
                            labelBP4.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,1250").ToString();
                            labelBP5.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,1258").ToString();
                            labelBP6.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,1260").ToString();
                            labelBP7.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,1268").ToString();
                            labelBP8.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,1270").ToString();
                            labelBP9.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,1278").ToString();
                            labelBP10.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,1280").ToString();
                        }
                        else
                        {
                            labelAtkValue.Text = m.ReadFloat("mhfo-hd.dll+ECDE5F8,1788").ToString();
                            labelDefValue.Text = m.ReadFloat("mhfo-hd.dll+ECDE5F8,178C").ToString();
                            labelPoison.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,177A").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,1778").ToString();
                            labelSleep.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,175C").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,175A").ToString();
                            labelPara.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1776").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,1770").ToString();
                            labelBlast.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1C3A").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,1C38").ToString();
                            labelStun.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1762").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,1964").ToString();
                            labelSize.Text = m.Read2Byte("mhfo-hd.dll+2AFA784").ToString() + "%";

                            labelBP1.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1238").ToString();
                            labelBP2.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1240").ToString();
                            labelBP3.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1248").ToString();
                            labelBP4.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1250").ToString();
                            labelBP5.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1258").ToString();
                            labelBP6.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1260").ToString();
                            labelBP7.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1268").ToString();
                            labelBP8.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1270").ToString();
                            labelBP9.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1278").ToString();
                            labelBP10.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1280").ToString();
                        }
                    }
                    else
                    {
                        labelAtkValue.Text = m.ReadFloat("mhfo-hd.dll+ECDE5F8,1788").ToString();
                        labelDefValue.Text = m.ReadFloat("mhfo-hd.dll+ECDE5F8,178C").ToString();
                        labelPoison.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,177A").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,1778").ToString();
                        labelSleep.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,175C").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,175A").ToString();
                        labelPara.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1776").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,1770").ToString();
                        labelBlast.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1C3A").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,1C38").ToString();
                        labelStun.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1762").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,1964").ToString();
                        labelSize.Text = m.Read2Byte("mhfo-hd.dll+2AFA784").ToString() + "%";

                        labelBP1.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1238").ToString();
                        labelBP2.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1240").ToString();
                        labelBP3.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1248").ToString();
                        labelBP4.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1250").ToString();
                        labelBP5.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1258").ToString();
                        labelBP6.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1260").ToString();
                        labelBP7.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1268").ToString();
                        labelBP8.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1270").ToString();
                        labelBP9.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1278").ToString();
                        labelBP10.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1280").ToString();
                    }
                    break;
                case 2:
                    panelMonsInfo.Visible = false;
                    break;
                case 3:
                    panelMonsInfo.Visible = false;
                    break;
                default:
                    panelMonsInfo.Visible = false;
                    break;
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
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
            //////////////////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            //HitCounts
            hitCounts = m.Read2Byte("mhfo-hd.dll+ECB2DC6");
            labelHitCountsValue.Text = hitCounts.ToString();

            //Time
            int timeDef;
            int time;
            timeDef = m.ReadInt("mhfo-hd.dll+2AFA820");
            time = m.ReadInt("mhfo-hd.dll+E7FE170");
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
            int raw;
            int wepType;
            raw = m.Read2Byte("mhfo-hd.dll+DC6BEFA");
            wepType = m.ReadByte("mhfo-hd.dll+ED3A466");
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

        void GetDllInfo()
        {
            //Search and get mhfo-hd.dll module base address
            proc = Process.GetProcessById(PID);
            var ModuleList = new List<string>();
            foreach (ProcessModule md in proc.Modules)
            {
                ModuleList.Add(md.ModuleName);
            }

            if (ModuleList.Contains("mhfo-hd.dll"))
            {
                index = ModuleList.IndexOf("mhfo-hd.dll");
                isHGE = true;
            }
            else if (ModuleList.Contains("mhfo.dll"))
            {
                index = ModuleList.IndexOf("mhfo.dll");
                isHGE = false;
            }
        }

        private void openConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelBodyParts.BackColor = Color.Silver;
            panelMonsInfo.BackColor = Color.Silver;
            panelHP.BackColor = Color.Silver;
            panelPlayerInfo.BackColor = Color.Silver;
            panelConfig.Visible = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                xPos = e.X;
                yPos = e.Y;
            }
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            var con = sender as Control;

            if (con != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    con.Top += (e.Y - yPos);
                    con.Left += (e.X - xPos);
                }
            }
        }

        void InitConfig()
        {
            //playerinfo
            string line = File.ReadLines(cfgFileName).ElementAt(1);
            string text = "show=";
            string value = line.Substring(line.IndexOf(text) + text.Length);
            comPlayerStatus.SelectedIndex = Convert.ToInt16(value);
            showPlayerInfo = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(2);
            text = "x=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            playerInfoPanelx = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(3);
            text = "y=";
            value = line.Substring(line.IndexOf(text) + text.Length);
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
            text = "showatk=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            comboBox10.SelectedIndex = Convert.ToInt16(value);
            showatk = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(7);
            text = "atk=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            comboBox5.SelectedIndex = Convert.ToInt16(value);
            atkFormat = Convert.ToInt16(value);


            //hp
            line = File.ReadLines(cfgFileName).ElementAt(8);
            text = "showhp=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            comMonsterHPInfo.SelectedIndex = Convert.ToInt16(value);
            showHP = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(9);
            text = "x=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            HPPanelx = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(10);
            text = "y=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            HPPanely = Convert.ToInt16(value);


            //monsterinfo
            line = File.ReadLines(cfgFileName).ElementAt(11);
            text = "showmonsterInfo=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            comMonsterStatus.SelectedIndex = Convert.ToInt16(value);
            showMonsterInfo = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(12);
            text = "x=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            monsterInfoPanelx = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(13);
            text = "y=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            monsterInfoPanely = Convert.ToInt16(value);


            //damage
            line = File.ReadLines(cfgFileName).ElementAt(14);
            text = "showdamage=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            comboBox7.SelectedIndex = Convert.ToInt16(value);
            showDamage = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(15);
            text = "centerx=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            numericUpDown13.Value = Convert.ToInt16(value);
            centerx = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(16);
            text = "centery=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            numericUpDown12.Value = Convert.ToInt16(value);
            centery = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(17);
            text = "height-=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            numericUpDown14.Value = Convert.ToInt16(value);
            height = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(18);
            text = "width+=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            numericUpDown15.Value = Convert.ToInt16(value);
            width = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(19);
            text = "size=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            numericUpDown18.Value = Convert.ToInt16(value);
            damageTextSize = Convert.ToInt16(value);


            //Body parts
            line = File.ReadLines(cfgFileName).ElementAt(20);
            text = "showbp=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            comBodyParts.SelectedIndex = Convert.ToInt16(value);
            ShowBP = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(21);
            text = "x=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            BPPanelx = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(22);
            text = "y=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            BPPanely = Convert.ToInt16(value);


            //overall
            line = File.ReadLines(cfgFileName).ElementAt(23);
            text = "font=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            textfont = value;
            comTextFont.Text = textfont;

            line = File.ReadLines(cfgFileName).ElementAt(24);
            text = "size=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            textsize = Convert.ToInt16(value);
            numTextSize.Value = (decimal)textsize;

            line = File.ReadLines(cfgFileName).ElementAt(25);
            text = "color=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            textcolor = value;
            comboBox11.Text = textcolor;

            //line = File.ReadLines(cfgFileName).ElementAt(26);
            //text = "hide=";
            //value = line.Substring(line.IndexOf(text) + text.Length);
            //isHide = Convert.ToInt16(value);
            //comHide.SelectedIndex = isHide;

            comboBox8.SelectedIndex = 1;

            panelPlayerInfo.Location = new Point(playerInfoPanelx, playerInfoPanely);
            panelHP.Location = new Point(HPPanelx, HPPanely);
            panelMonsInfo.Location = new Point(monsterInfoPanelx, monsterInfoPanely);
            panelBodyParts.Location = new Point(BPPanelx, BPPanely);
            panelSample.Size = new Size(width, height);
            panelSample.Location = new Point(centerx, centery);

            foreach (Panel pnl in this.Controls)
            {
                if (pnl.Name != "panelConfig")
                {
                    foreach (Control lbl in pnl.Controls)
                    {
                        Font font = new Font(textfont, textsize, FontStyle.Regular);
                        lbl.ForeColor = Color.FromName(textcolor);
                        lbl.Font = font;
                        lbl.BackColor = Color.Transparent;
                    }
                }
            }
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
            int x = rnd.Next(centerx, centerx + width);
            int y = rnd.Next(centery, centery + height);
            namelabel.Location = new Point(x, y);
            namelabel.BringToFront();
            namelabel.Text = damage.ToString();
            namelabel.Font = new Font(textfont, damageTextSize);
            namelabel.ForeColor = Color.FromName(textcolor);
            namelabel.BackColor = Color.Transparent;
            namelabel.AutoSize = true;
            this.Controls.Add(namelabel);
            DeleteLabel(namelabel);
        }

        void LineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit] = newText;
            File.WriteAllLines(fileName, arrLine);
        }

        private void buttonCloseConfig_Click(object sender, EventArgs e)
        {
            playerInfoPanelx = panelPlayerInfo.Location.X;
            playerInfoPanely = panelPlayerInfo.Location.Y;
            LineChanger("show=" + showPlayerInfo.ToString(), cfgFileName, 1);
            LineChanger("x=" + playerInfoPanelx.ToString(), cfgFileName, 2);
            LineChanger("y=" + playerInfoPanely.ToString(), cfgFileName, 3);
            LineChanger("type=" + timetype.ToString(), cfgFileName, 4);
            LineChanger("format=" + timeformat.ToString(), cfgFileName, 5);
            LineChanger("showatk=" + showatk.ToString(), cfgFileName, 6);
            LineChanger("atk=" + atkFormat.ToString(), cfgFileName, 7);

            HPPanelx = panelHP.Location.X;
            HPPanely = panelHP.Location.Y;
            LineChanger("showhp=" + showHP.ToString(), cfgFileName, 8);
            LineChanger("x=" + HPPanelx.ToString(), cfgFileName, 9);
            LineChanger("y=" + HPPanely.ToString(), cfgFileName, 10);

            monsterInfoPanelx = panelMonsInfo.Location.X;
            monsterInfoPanely = panelMonsInfo.Location.Y;
            LineChanger("showmonsterInfo=" + showMonsterInfo.ToString(), cfgFileName, 11);
            LineChanger("x=" + monsterInfoPanelx.ToString(), cfgFileName, 12);
            LineChanger("y=" + monsterInfoPanely.ToString(), cfgFileName, 13);

            LineChanger("showdamage=" + showDamage.ToString(), cfgFileName, 14);
            LineChanger("centerx=" + centerx.ToString(), cfgFileName, 15);
            LineChanger("centery=" + centery.ToString(), cfgFileName, 16);
            LineChanger("height=" + height.ToString(), cfgFileName, 17);
            LineChanger("width=" + width.ToString(), cfgFileName, 18);
            LineChanger("size=" + damageTextSize.ToString(), cfgFileName, 19);

            BPPanelx = panelBodyParts.Location.X;
            BPPanely = panelBodyParts.Location.Y;
            LineChanger("showbp=" + ShowBP.ToString(), cfgFileName, 20);
            LineChanger("x=" + BPPanelx.ToString(), cfgFileName, 21);
            LineChanger("y=" + BPPanely.ToString(), cfgFileName, 22);

            LineChanger("font=" + comTextFont.Text.ToString(), cfgFileName, 23);
            LineChanger("size=" + numTextSize.Value.ToString(), cfgFileName, 24);
            LineChanger("color=" + comboBox11.Text.ToString(), cfgFileName, 25);

            //LineChanger("hide=" + comHide.SelectedIndex, cfgFileName, 26);

            panelConfig.Visible = false;
            panelSample.Visible = false;

            panelPlayerInfo.BackColor = Color.Transparent;
            panelHP.BackColor = Color.Transparent;
            panelMonsInfo.BackColor = Color.Transparent;
            panelBodyParts.BackColor = Color.Transparent;

        }

        void ReloadUI()
        {
            showMonsterInfo = comMonsterStatus.SelectedIndex;
            if (showMonsterInfo == 0)
            {
                panelMonsInfo.Visible = true;
            }
            else
            {
                panelMonsInfo.Visible = false;
            }

            showPlayerInfo = comPlayerStatus.SelectedIndex;
            if (showPlayerInfo == 0)
            {
                panelPlayerInfo.Visible = true;
            }
            else
            {
                panelPlayerInfo.Visible = false;
            }

            showHP = comMonsterHPInfo.SelectedIndex;
            if (showHP == 0)
            {
                panelHP.Visible = true;
            }
            else
            {
                panelHP.Visible = false;
            }

            ShowBP = comBodyParts.SelectedIndex;
            if (ShowBP == 0)
            {
                panelBodyParts.Visible = true;
            }
            else
            {
                panelBodyParts.Visible = false;
            }

            showSample = comboBox8.SelectedIndex;
            if (showSample == 0)
            {
                panelSample.Visible = true;
            }
            else
            {
                panelSample.Visible = false;
            }

            textfont = comTextFont.Text;
            textsize = (int)numTextSize.Value;
            textcolor = comboBox11.Text;

            timetype = comboBox4.SelectedIndex;
            timeformat = comboBox6.SelectedIndex;
            showatk = comboBox10.SelectedIndex;
            atkFormat = comboBox5.SelectedIndex;

            showDamage = comboBox7.SelectedIndex;
            damageTextSize = (int)numericUpDown18.Value;
            centerx = (int)numericUpDown13.Value;
            centery = (int)numericUpDown12.Value;
            height = (int)numericUpDown14.Value;
            width = (int)numericUpDown15.Value;

            foreach (Panel pnl in this.Controls)
            {
                if (pnl.Name != "panelConfig")
                {
                    foreach (Control lbl in pnl.Controls)
                    {
                        Font font = new Font(textfont, textsize, FontStyle.Regular);
                        lbl.ForeColor = Color.FromName(textcolor);
                        lbl.Font = font;
                        lbl.BackColor = Color.Transparent;
                    }
                }
            }
        }

        private void comTextFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void numTextSize_ValueChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
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

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadUI();
        }

        private void numericUpDown18_ValueChanged(object sender, EventArgs e)
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

        private void comHide_SelectedIndexChanged(object sender, EventArgs e)
        {
            //isHide = comHide.SelectedIndex;
        }

    }
}