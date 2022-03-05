using Memory;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Linq;

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

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
			this.BackColor = Color.LimeGreen;
            this.Location = new Point(265, 90);

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

                    timer1.Start();
                }
                else
                {
                    alreadyExist = true;
                    adrf = adrf + 20;
                    timer1.Start();
                }
            }
            else
            {
				MessageBox.Show("Launch game first");
                this.Close();

            }

		}

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (alreadyExist)
            {
                monsterHPValue = m.Read2Byte(adrf.ToString("X8"));
                label1.Text = monsterHPValue.ToString();
            }
            else
            {
                monsterHPValue = m.Read2Byte(adr4.ToString("X8"));
                label1.Text = monsterHPValue.ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
			this.Close();
		}
    }
}