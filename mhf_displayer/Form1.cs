using Memory;
using Dictionary;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace mhf_displayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        const int MYACTION_HOTKEY_ID = 1;       //alt



        Mem m = new Mem();

        int curNum = 0;
        int prevNum = 0;
        bool isFirstAttack = false;
        int hitCounts = 0;
        bool isHGE = false;
        int index = 0;
        int PID = 0;
        Process proc;
        int largeMonster1 = 0;
        int largeMonster2 = 0;
        int largeMonster3 = 0;
        int largeMonster4 = 0;
        int selectedMonsterNo = 1;   //1,2,3,4
        bool isRoad = false;
        int xPos;
        int yPos;
        public static string cfgFileName = "mhf_displayer.cfg";

        public static int showPlayerInfo;
        public static int playerInfoPanelx;
        public static int playerInfoPanely;
        public static int timetype;
        public static int timeformat;
        public static int atkFormat;
        public static int showHP;
        public static int HPPanelx;
        public static int HPPanely;
        public static int showMonsterInfo;
        public static int monsterInfoPanelx;
        public static int monsterInfoPanely;
        public static int configPanelx;
        public static int configPanely;
        public static int showDamage;
        public static int centerx;
        public static int centery;
        public static int height;
        public static int width;
        public static int damageTextSize  = 9;
        public static int ShowBP;
        public static int BPPanelx;
        public static int BPPanely;
        public static int showatk;
        public static string textfont = "";
        public static int textsize = 9;
        public static string textcolor = "Black";
        public static int showSample = 1;


        private void Form1_Load(object sender, EventArgs e)
        {
            RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID, 1, (int)Keys.F12);  //alt+f12

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

                OpenConfig(false);
                timer1.Start();
            }
            else
            {
                MessageBox.Show("Launch game first");
                this.Close();
                //OpenConfig(false);
                //timer1.Start();
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
            namelabel.ForeColor = Color.FromName(Form1.textcolor);
            namelabel.BackColor = Color.Transparent;
            namelabel.AutoSize = true;
            this.Controls.Add(namelabel);
            DeleteLabel(namelabel);
        }

        public void hoge()
        {

            // this.TransparencyKey = Color.Beige;
            // this.BackColor = Color.Beige;


            //Color cor = Color.FromName(textcolor);
            //cor = Color.FromArgb(cor.R + 1, cor.G, cor.B);

            //this.TransparencyKey = cor;
            //this.BackColor = cor;


            //this.TransparencyKey = Color.Beige;
            //this.BackColor = Color.Beige;



        }

        void test()
        {
                        HPPanelx = panelHP.Location.X;
            HPPanely = panelHP.Location.Y;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (isHGE)
            {
                //selectedMonsterNo = m.ReadByte("mhfo-hd.dll+E80DB50,24");
                //selectedMonsterNo = 2;


                if (showPlayerInfo == 0)
                {
                    labelHitCountTitle.Visible = true;
                    labelTime1.Visible = true;
                    labelPlayerAtk.Visible = true;
                    labelHitCountsValue.Visible = true;
                    labelTimeValue1.Visible = true;
                    label21.Visible = true;

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
                else
                {
                    labelHitCountTitle.Visible = false;
                    labelTime1.Visible = false;
                    labelPlayerAtk.Visible = false;
                    labelHitCountsValue.Visible = false;
                    labelTimeValue1.Visible = false;
                    label21.Visible = false;
                }

                bool normalQuest = true;
                int val = m.Read2Byte("mhfo-hd.dll+0E37DD38,348");
                if (val != 0)
                {
                    largeMonster1 = m.ReadByte("mhfo-hd.dll+1BEF3D9");
                    largeMonster2 = m.ReadByte("mhfo-hd.dll+1BEF3DA");
                    largeMonster3 = m.ReadByte("mhfo-hd.dll+1BEF3DB");
                    largeMonster4 = m.ReadByte("mhfo-hd.dll+1BEF3DC");
                    normalQuest = true;
                }
                else
                {
                    largeMonster1 = m.ReadByte("mhfo-hd.dll+1A8872C");
                    largeMonster2 = m.ReadByte("mhfo-hd.dll+1A88730");
                    largeMonster3 = 0;
                    largeMonster4 = 0;
                    normalQuest = false;
                }


                if (ShowBP == 0)
                {
                    if (normalQuest)
                    {
                        switch (selectedMonsterNo)
                        {
                            case 0:
                                if (largeMonster1 != 1)
                                {
                                    labelBP1.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,348").ToString();
                                    labelBP2.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,350").ToString();
                                    labelBP3.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,358").ToString();
                                    labelBP4.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,360").ToString();
                                    labelBP5.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,368").ToString();
                                    labelBP6.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,370").ToString();
                                    labelBP7.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,378").ToString();
                                    labelBP8.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,380").ToString();
                                    labelBP9.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,388").ToString();
                                    labelBP10.Text = selectedMonsterNo.ToString();
                                    //labelBP10.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,390").ToString();
                                }
                                break;
                            case 1:
                                if (largeMonster2 != 2)
                                {
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
                                break;
                            case 3:
                                //not impletemnted
                                labelBP1.Text = "0";
                                labelBP2.Text = "0";
                                labelBP3.Text = "0";
                                labelBP4.Text = "0";
                                labelBP5.Text = "0";
                                labelBP6.Text = "0";
                                labelBP7.Text = "0";
                                labelBP8.Text = "0";
                                labelBP9.Text = "0";
                                labelBP10.Text = "0";
                                break;
                            case 4:
                                //not impletemnted
                                if (true)
                                    labelBP1.Text = "0";
                                labelBP2.Text = "0";
                                labelBP3.Text = "0";
                                labelBP4.Text = "0";
                                labelBP5.Text = "0";
                                labelBP6.Text = "0";
                                labelBP7.Text = "0";
                                labelBP8.Text = "0";
                                labelBP9.Text = "0";
                                labelBP10.Text = "0";
                                break;
                        }
                    }
                    else
                    {
                        switch (selectedMonsterNo)
                        {
                            case 0:
                                if (largeMonster1 != 1)
                                {
                                    labelBP1.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,348").ToString();
                                    labelBP2.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,350").ToString();
                                    labelBP3.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,358").ToString();
                                    labelBP4.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,360").ToString();
                                    labelBP5.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,368").ToString();
                                    labelBP6.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,370").ToString();
                                    labelBP7.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,378").ToString();
                                    labelBP8.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,380").ToString();
                                    labelBP9.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,388").ToString();
                                    labelBP10.Text = selectedMonsterNo.ToString();
                                   // labelBP10.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,390").ToString();
                                }
                                break;
                            case 1:
                                if (largeMonster2 != 2)
                                {
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
                            case 3:
                                //not impletemnted
                                labelBP1.Text = "0";
                                labelBP2.Text = "0";
                                labelBP3.Text = "0";
                                labelBP4.Text = "0";
                                labelBP5.Text = "0";
                                labelBP6.Text = "0";
                                labelBP7.Text = "0";
                                labelBP8.Text = "0";
                                labelBP9.Text = "0";
                                labelBP10.Text = "0";
                                break;
                            case 4:
                                //not impletemnted
                                if (true)
                                    labelBP1.Text = "0";
                                labelBP2.Text = "0";
                                labelBP3.Text = "0";
                                labelBP4.Text = "0";
                                labelBP5.Text = "0";
                                labelBP6.Text = "0";
                                labelBP7.Text = "0";
                                labelBP8.Text = "0";
                                labelBP9.Text = "0";
                                labelBP10.Text = "0";
                                break;
                        }
                    }
                }
                else
                {
                    panelBodyParts.Visible = false;
                }

                if (showHP == 0)
                {
                    int monsterHPValue;

                    if (largeMonster1 != 0)
                    {
                        labelMonN1.Visible = true;
                        labelMonHP1.Visible = true;
                        List.MonsterID.TryGetValue(largeMonster1, out string monsterName1);
                        if (selectedMonsterNo == 1)
                        {
                            monsterName1 = "★" + monsterName1;
                        }
                        labelMonN1.Text = monsterName1 + ":";
                        monsterHPValue = m.Read2Byte("0043C600");
                        labelMonHP1.Text = monsterHPValue.ToString();
                    }
                    else
                    {
                        labelMonN1.Visible = false;
                        labelMonHP1.Visible = false;
                    }

                    if (largeMonster2 != 0 && largeMonster2 != 255)
                    {
                        labelMonN2.Visible = true;
                        labelMonHP2.Visible = true;
                        List.MonsterID.TryGetValue(largeMonster2, out string monsterName2);
                        if (selectedMonsterNo == 2)
                        {
                            monsterName2 = "★" + monsterName2;
                        }
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
                        if (selectedMonsterNo == 3)
                        {
                            monsterName3 = "★" + monsterName3;
                        }
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
                        if (selectedMonsterNo == 4)
                        {
                            monsterName4 = "★" + monsterName4;
                        }
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
                else
                {
                    labelMonN1.Visible = false;
                }

                if (showMonsterInfo == 0)
                {
                    if (normalQuest)
                    {
                        switch (selectedMonsterNo)
                        {
                            case 0:
                                if (largeMonster1 != 0)
                                {
                                    labelAtkValue.Text = m.ReadFloat("mhfo-hd.dll+0E37DD38,898").ToString();
                                    labelDefValue.Text = m.ReadFloat("mhfo-hd.dll+0E37DD38,89C").ToString();
                                    labelPoison.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,88A").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+0E37DD38,888").ToString();
                                    labelSleep.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,86C").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+0E37DD38,86A").ToString();
                                    labelPara.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,886").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+0E37DD38,880").ToString();
                                    labelBlast.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,D4A").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+0E37DD38,D48").ToString();
                                    labelStun.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,872").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+0E37DD38,A74").ToString();
                                    labelSize.Text = m.Read2Byte("mhfo-hd.dll+2AFA784").ToString() + "%";
                                }
                                break;
                            case 1:
                                if (largeMonster2 != 0)
                                {
                                    labelAtkValue.Text = m.ReadFloat("mhfo-hd.dll+0E37DD38,1788").ToString();
                                    labelDefValue.Text = m.ReadFloat("mhfo-hd.dll+0E37DD38,178C").ToString();
                                    labelPoison.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,177A").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+0E37DD38,1778").ToString();
                                    labelSleep.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,175C").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+0E37DD38,175A").ToString();
                                    labelPara.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,1776").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+0E37DD38,1770").ToString();
                                    labelBlast.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,1C3A").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+0E37DD38,1C38").ToString();
                                    labelStun.Text = m.Read2Byte("mhfo-hd.dll+0E37DD38,1762").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+0E37DD38,1964").ToString();
                                    labelSize.Text = m.Read2Byte("mhfo-hd.dll+2AFA784").ToString() + "%";
                                }
                                break;
                            case 3:
                                //not imp
                                if (true)
                                {
                                    labelAtkValue.Text = "0";
                                    labelDefValue.Text = "0";
                                    labelPoison.Text = "0";
                                    labelSleep.Text = "0";
                                    labelPara.Text = "0";
                                    labelBlast.Text = "0";
                                    labelStun.Text = "0";
                                    labelSize.Text = "0%";
                                }
                                break;
                            case 4:
                                //not imp
                                if (true)
                                {
                                    labelAtkValue.Text = "0";
                                    labelDefValue.Text = "0";
                                    labelPoison.Text = "0";
                                    labelSleep.Text = "0";
                                    labelPara.Text = "0";
                                    labelBlast.Text = "0";
                                    labelStun.Text = "0";
                                    labelSize.Text = "0%";
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (selectedMonsterNo)
                        {
                            case 1:
                                if (largeMonster1 != 0)
                                {
                                    labelAtkValue.Text = m.ReadFloat("mhfo-hd.dll+ECDE5F8,898").ToString();
                                    labelDefValue.Text = m.ReadFloat("mhfo-hd.dll+ECDE5F8,89C").ToString();
                                    labelPoison.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,88A").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,888").ToString();
                                    labelSleep.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,86C").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,86A").ToString();
                                    labelPara.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,886").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,880").ToString();
                                    labelBlast.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,D4A").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,D48").ToString();
                                    labelStun.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,872").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,A74").ToString();
                                    labelSize.Text = m.Read2Byte("mhfo-hd.dll+2AFA784").ToString() + "%";
                                }
                                break;
                            case 2:
                                if (largeMonster2 != 0)
                                {
                                    labelAtkValue.Text = m.ReadFloat("mhfo-hd.dll+ECDE5F8,1788").ToString();
                                    labelDefValue.Text = m.ReadFloat("mhfo-hd.dll+ECDE5F8,178C").ToString();
                                    labelPoison.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,177A").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,1778").ToString();
                                    labelSleep.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,175C").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,175A").ToString();
                                    labelPara.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1776").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,1770").ToString();
                                    labelBlast.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1C3A").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,1C38").ToString();
                                    labelStun.Text = m.Read2Byte("mhfo-hd.dll+ECDE5F8,1762").ToString() + "/" + m.Read2Byte("mhfo-hd.dll+ECDE5F8,1964").ToString();
                                    labelSize.Text = m.Read2Byte("mhfo-hd.dll+2AFA784").ToString() + "%";
                                }
                                break;
                            case 3:
                                //not imp
                                if (true)
                                {
                                    labelAtkValue.Text = "0";
                                    labelDefValue.Text = "0";
                                    labelPoison.Text = "0";
                                    labelSleep.Text = "0";
                                    labelPara.Text = "0";
                                    labelBlast.Text = "0";
                                    labelStun.Text = "0";
                                    labelSize.Text = "0%";
                                }
                                break;
                            case 4:
                                //not imp
                                if (true)
                                {
                                    labelAtkValue.Text = "0";
                                    labelDefValue.Text = "0";
                                    labelPoison.Text = "0";
                                    labelSleep.Text = "0";
                                    labelPara.Text = "0";
                                    labelBlast.Text = "0";
                                    labelStun.Text = "0";
                                    labelSize.Text = "0%";
                                }
                                break;
                        }
                    }

                }
                else
                {
                    panelMonsInfo.Visible = false;
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
            else
            {
                if (showPlayerInfo == 0)
                {
                    labelHitCountTitle.Visible = true;
                    labelTime1.Visible = true;
                    labelPlayerAtk.Visible = true;
                    labelHitCountsValue.Visible = true;
                    labelTimeValue1.Visible = true;
                    label21.Visible = true;

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
                else
                {
                    labelHitCountTitle.Visible = false;
                    labelTime1.Visible = false;
                    labelPlayerAtk.Visible = false;
                    labelHitCountsValue.Visible = false;
                    labelTimeValue1.Visible = false;
                    label21.Visible = false;
                }

                int val = m.Read2Byte("mhfo.dll+5C4760C");

                if (val != 0)
                {
                    largeMonster1 = m.ReadByte("mhfo.dll+1A98FD8");
                    largeMonster2 = m.ReadByte("mhfo.dll+1A99014");
                    largeMonster3 = 0;
                    largeMonster4 = 0;
                    isRoad = true;
                }
                else
                {
                    largeMonster1 = m.ReadByte("mhfo.dll+1B97794");
                    largeMonster2 = m.ReadByte("mhfo.dll+1B9779C");
                    largeMonster3 = m.ReadByte("mhfo.dll+1B977A4");
                    largeMonster4 = m.ReadByte("mhfo.dll+1B977AC");
                    isRoad = false;
                }

                if (showMonsterInfo == 0)
                {
                    switch (selectedMonsterNo)
                    {
                        case 1:
                            if (largeMonster1 != 0)
                            {
                                labelAtkValue.Text = m.ReadFloat("mhfo.dll+5CA338C,898").ToString();
                                labelDefValue.Text = m.ReadFloat("mhfo.dll+5CA338C,89C").ToString();
                                labelPoison.Text = m.Read2Byte("mhfo.dll+5CA338C,88A").ToString() + "/" + m.Read2Byte("mhfo.dll+5CA338C,888").ToString();
                                labelSleep.Text = m.Read2Byte("mhfo.dll+5CA338C,86C").ToString() + "/" + m.Read2Byte("mhfo.dll+5CA338C,86A").ToString();
                                labelPara.Text = m.Read2Byte("mhfo.dll+5CA338C,886").ToString() + "/" + m.Read2Byte("mhfo.dll+5CA338C,880").ToString();
                                labelBlast.Text = m.Read2Byte("mhfo.dll+5CA338C,D4A").ToString() + "/" + m.Read2Byte("mhfo.dll+5CA338C,D48").ToString();
                                labelStun.Text = m.Read2Byte("mhfo.dll+5CA338C,872").ToString() + "/" + m.Read2Byte("mhfo.dll+5CA338C,A74").ToString();
                                labelSize.Text = m.Read2Byte("mhfo.dll+28C2BD4").ToString() + "%";
                            }
                            break;
                        case 2:
                            if (largeMonster2 != 0)
                            {
                                labelAtkValue.Text = m.ReadFloat("mhfo.dll+5CA338C,1788").ToString();
                                labelDefValue.Text = m.ReadFloat("mhfo.dll+5CA338C,178C").ToString();
                                labelPoison.Text = m.Read2Byte("mhfo.dll+5CA338C,177A").ToString() + "/" + m.Read2Byte("mhfo.dll+5CA338C,1778").ToString();
                                labelSleep.Text = m.Read2Byte("mhfo.dll+5CA338C,175C").ToString() + "/" + m.Read2Byte("mhfo.dll+5CA338C,175A").ToString();
                                labelPara.Text = m.Read2Byte("mhfo.dll+5CA338C,1776").ToString() + "/" + m.Read2Byte("mhfo.dll+5CA338C,1770").ToString();
                                labelBlast.Text = m.Read2Byte("mhfo.dll+5CA338C,1C3A").ToString() + "/" + m.Read2Byte("mhfo.dll+5CA338C,1C38").ToString();
                                labelStun.Text = m.Read2Byte("mhfo.dll+5CA338C,1762").ToString() + "/" + m.Read2Byte("mhfo.dll+5CA338C,1964").ToString();
                                labelSize.Text = m.Read2Byte("mhfo.dll+28C2BD4").ToString() + "%";
                            }
                            break;
                        case 3:
                            //not imp
                            if (true)
                            {
                                labelAtkValue.Text = "0";
                                labelDefValue.Text = "0";
                                labelPoison.Text = "0";
                                labelSleep.Text = "0";
                                labelPara.Text = "0";
                                labelBlast.Text = "0";
                                labelStun.Text = "0";
                                labelSize.Text = "0%";
                            }
                            break;
                        case 4:
                            //not imp
                            if (true)
                            {
                                labelAtkValue.Text = "0";
                                labelDefValue.Text = "0";
                                labelPoison.Text = "0";
                                labelSleep.Text = "0";
                                labelPara.Text = "0";
                                labelBlast.Text = "0";
                                labelStun.Text = "0";
                                labelSize.Text = "0%";
                            }
                            break;
                    }
                }
                else
                {
                    panelMonsInfo.Visible = false;
                }

                switch (selectedMonsterNo)
                {
                    case 1:
                        if (largeMonster1 != 0)
                        {
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
                        }
                        break;
                    case 2:
                        if (largeMonster2 != 0)
                        {
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
                        }
                        break;
                    case 3:
                        labelBP1.Text = "0";
                        labelBP2.Text = "0";
                        labelBP3.Text = "0";
                        labelBP4.Text = "0";
                        labelBP5.Text = "0";
                        labelBP6.Text = "0";
                        labelBP7.Text = "0";
                        labelBP8.Text = "0";
                        labelBP9.Text = "0";
                        labelBP10.Text = "0";
                        break;
                    case 4:
                        labelBP1.Text = "0";
                        labelBP2.Text = "0";
                        labelBP3.Text = "0";
                        labelBP4.Text = "0";
                        labelBP5.Text = "0";
                        labelBP6.Text = "0";
                        labelBP7.Text = "0";
                        labelBP8.Text = "0";
                        labelBP9.Text = "0";
                        labelBP10.Text = "0";
                        break;
                }
            
                if (showHP == 0)
                {
                    int monsterHPValue;

                    if (largeMonster1 != 0)
                    {
                        labelMonN1.Visible = true;
                        labelMonHP1.Visible = true;
                        List.MonsterID.TryGetValue(largeMonster1, out string monsterName1);
                        if (selectedMonsterNo == 1)
                        {
                            monsterName1 = "★" + monsterName1;
                        }
                        labelMonN1.Text = monsterName1 + ":";
                        monsterHPValue = m.Read2Byte("0043C600");
                        labelMonHP1.Text = monsterHPValue.ToString();
                    }
                    else
                    {
                        labelMonN1.Visible = false;
                        labelMonHP1.Visible = false;
                    }

                    //if (largeMonster2 != 0)
                    //{
                    //    labelMonN2.Visible = true;
                    //    labelMonHP2.Visible = true;
                    //    List.MonsterID.TryGetValue(largeMonster2, out string monsterName2);
                    //    if (selectedMonsterNo == 2)
                    //    {
                    //        monsterName2 = "★" + monsterName2;
                    //    }
                    //    labelMonN2.Text = monsterName2 + ":";
                    //    //monsterHPValue = m.Read2Byte("0043C604");
                    //    labelMonHP2.Text = m.Read2Byte("0043C604").ToString();
                    //}
                    ////else
                    ////{
                    ////    labelMonN2.Visible = false;
                    ////    labelMonHP2.Visible = false;
                    ////}
                    
                    if (largeMonster2 == 0)
                    {
                        labelMonN2.Visible = false;
                        labelMonHP2.Visible = false;
                    }
                    else
                    {
                        labelMonN2.Visible = true;
                        labelMonHP2.Visible = true;
                        List.MonsterID.TryGetValue(largeMonster2, out string monsterName2);
                        labelMonN2.Text = monsterName2 + ":";
                        labelMonHP2.Text = m.Read2Byte("0043C604").ToString();
                    }


                    if (largeMonster3 != 0)
                    {
                        labelMonN3.Visible = true;
                        labelMonHP3.Visible = true;
                        List.MonsterID.TryGetValue(largeMonster3, out string monsterName3);
                        if (selectedMonsterNo == 3)
                        {
                            monsterName3 = "★" + monsterName3;
                        }
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
                        if (selectedMonsterNo == 4)
                        {
                            monsterName4 = "★" + monsterName4;
                        }
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
                else
                {
                    labelMonN1.Visible = false;
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
            }

            if (showSample == 0)
            {
                panelSample.Visible = true;
                panelSample.Size = new Size(width, height);
                panelSample.Location = new Point(centerx, centery);

                Font font = new Font(Form1.textfont, Form1.damageTextSize, FontStyle.Regular);
                labelSampleDmg1.Font = font;
                labelSampleDmg2.Font = font;
                labelSampleDmg3.Font = font;
            }
            else
            {
                panelSample.Visible = false;
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

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == MYACTION_HOTKEY_ID)
            {
                this.Close();
                if (selectedMonsterNo != 4)
                {
                    selectedMonsterNo = selectedMonsterNo + 1;
                }
                else
                {
                    selectedMonsterNo = 1;
                }
            }
            selectedMonsterNo = selectedMonsterNo;
            base.WndProc(ref m);
        }

        private void openConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelBodyParts.BackColor = Color.Silver;
            panelMonsInfo.BackColor = Color.Silver;
            panelHP.BackColor = Color.Silver;
            panelPlayerInfo.BackColor = Color.Silver;
            OpenConfig(true);
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

        void OpenConfig(bool show)
        {
            // this.TransparencyKey = Color.Beige;
            // this.BackColor = Color.Beige;
            // this.TopMost = false;

            Configcs form = new Configcs(this);
            form.Show();
            //form.TopMost = true;
            if (!show)
            {
                form.Close();
            }

            panelPlayerInfo.Location = new Point(playerInfoPanelx, playerInfoPanely);
            panelHP.Location = new Point(HPPanelx, HPPanely);
            panelMonsInfo.Location = new Point(monsterInfoPanelx, monsterInfoPanely);
            panelBodyParts.Location = new Point(BPPanelx, BPPanely);
            panelSample.Size = new Size(width, height);
            panelSample.Location = new Point(centerx, centery);
        }
    }
}