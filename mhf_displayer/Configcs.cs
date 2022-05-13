using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mhf_displayer
{
    public partial class Configcs : Form
    {
        Form fm1;

        public Configcs(Form1 fm)
        {
            InitializeComponent();
            fm1 = fm;
        }

        static void LineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit] = newText;
            File.WriteAllLines(fileName, arrLine);
        }

        public static string cfgFileName = "mhf_displayer.cfg";
        private Form1 mainForm = null;

        public void Form2(Form callingForm)
        {
            mainForm = callingForm as Form1;
        }



        void InitUI()
        {
            //playerinfo
            string line = File.ReadLines(cfgFileName).ElementAt(1);
            string text = "show=";
            string value = line.Substring(line.IndexOf(text) + text.Length);
            comboBox1.SelectedIndex = Convert.ToInt16(value);
            Form1.showPlayerInfo = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(2);
            text = "x=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            Form1.playerInfoPanelx = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(3);
            text = "y=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            Form1.playerInfoPanely = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(4);
            text = "type=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            comboBox4.SelectedIndex = Convert.ToInt16(value);
            Form1.timetype = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(5);
            text = "format=";
            value = line.Substring(line.IndexOf(text) + text.Length);
           comboBox6.SelectedIndex = Convert.ToInt16(value);
            Form1.timeformat = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(6);
            text = "showatk=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            comboBox10.SelectedIndex = Convert.ToInt16(value);
            Form1.showatk = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(7);
            text = "atk=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            comboBox5.SelectedIndex = Convert.ToInt16(value);
            Form1.atkFormat = Convert.ToInt16(value);


            //hp
            line = File.ReadLines(cfgFileName).ElementAt(8);
            text = "showhp=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            comboBox2.SelectedIndex = Convert.ToInt16(value);
            Form1.showHP = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(9);
            text = "x=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            Form1.HPPanelx = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(10);
            text = "y=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            Form1.HPPanely = Convert.ToInt16(value);


            //monsterinfo
            line = File.ReadLines(cfgFileName).ElementAt(11);
            text = "showmonsterInfo=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            comboBox3.SelectedIndex = Convert.ToInt16(value);
            Form1.showMonsterInfo = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(12);
            text = "x=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            Form1.monsterInfoPanelx = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(13);
            text = "y=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            Form1.monsterInfoPanely = Convert.ToInt16(value);


            //damage
            line = File.ReadLines(cfgFileName).ElementAt(14);
            text = "showdamage=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            comboBox7.SelectedIndex = Convert.ToInt16(value);
            Form1.showDamage = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(15);
            text = "centerx=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            numericUpDown13.Value = Convert.ToInt16(value);
            Form1.centerx = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(16);
            text = "centery=";
            value = line.Substring(line.IndexOf(text) + text.Length);
           numericUpDown12.Value = Convert.ToInt16(value);
            Form1.centery = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(17);
            text = "height-=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            numericUpDown14.Value = Convert.ToInt16(value);
            Form1.height = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(18);
            text = "width+=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            numericUpDown15.Value = Convert.ToInt16(value);
            Form1.width = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(19);
            text = "size=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            numericUpDown18.Value = Convert.ToInt16(value);
            Form1.damageTextSize = Convert.ToInt16(value);


            //Body parts
            line = File.ReadLines(cfgFileName).ElementAt(20);
            text = "showbp=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            comboBox9.SelectedIndex = Convert.ToInt16(value);
            Form1.ShowBP = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(21);
            text = "x=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            Form1.BPPanelx = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(22);
            text = "y=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            Form1.BPPanely = Convert.ToInt16(value);


            //overall
            line = File.ReadLines(cfgFileName).ElementAt(23);
            text = "font=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            //comboBox9.SelectedIndex = Convert.ToInt16(value);
            Form1.textfont = value;

            line = File.ReadLines(cfgFileName).ElementAt(24);
            text = "size=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            numTextSize.Value = Convert.ToInt16(value);
            Form1.textsize = Convert.ToInt16(value);

            line = File.ReadLines(cfgFileName).ElementAt(25);
            text = "color=";
            value = line.Substring(line.IndexOf(text) + text.Length);
            //comboBox11.Text = Convert.ToInt16(value);
            Form1.textcolor = value;

            comboBox8.SelectedIndex = 1;
        }

        private void buttonCloseConfig_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;

            foreach (Panel pnl in fm1.Controls)
            {
                switch (pnl.Name)
                {
                    case "panelPlayerInfo":
                        x = pnl.Location.X;
                        y = pnl.Location.Y;
                        break;
                }
            }

            Form1.showSample = 1;


            LineChanger("show=" + Form1.showPlayerInfo.ToString(), cfgFileName, 1);
            LineChanger("x=" + x.ToString(), cfgFileName, 2);
            LineChanger("y=" + y.ToString(), cfgFileName, 3);
            LineChanger("type=" + Form1.timetype.ToString(), cfgFileName, 4);
            LineChanger("format=" + Form1.timeformat.ToString(), cfgFileName, 5);
            LineChanger("showatk=" + Form1.showatk.ToString(), cfgFileName, 6);
            LineChanger("atk=" + Form1.atkFormat.ToString(), cfgFileName, 7);

            LineChanger("showhp=" + Form1.showHP.ToString(), cfgFileName, 8);
            LineChanger("x=" + Form1.HPPanelx.ToString(), cfgFileName, 9);
            LineChanger("y=" + Form1.HPPanely.ToString(), cfgFileName, 10);

            LineChanger("showmonsterInfo=" + Form1.showMonsterInfo.ToString(), cfgFileName, 11);
            LineChanger("x=" + Form1.monsterInfoPanelx.ToString(), cfgFileName, 12);
            LineChanger("y=" + Form1.monsterInfoPanely.ToString(), cfgFileName, 13);

            LineChanger("showdamage=" + Form1.showDamage.ToString(), cfgFileName, 14);
            LineChanger("centerx=" + Form1.centerx.ToString(), cfgFileName, 15);
            LineChanger("centery=" + Form1.centery.ToString(), cfgFileName, 16);
            LineChanger("height=" + Form1.height.ToString(), cfgFileName, 17);
            LineChanger("width=" + Form1.width.ToString(), cfgFileName, 18);
            LineChanger("size=" + Form1.damageTextSize.ToString(), cfgFileName, 19);

            LineChanger("showbp=" + Form1.ShowBP.ToString(), cfgFileName, 20);
            LineChanger("x=" + Form1.BPPanelx.ToString(), cfgFileName, 21);
            LineChanger("y=" + Form1.BPPanely.ToString(), cfgFileName, 22);

            LineChanger("font=" + comTextFont.Text.ToString(), cfgFileName, 23);
            LineChanger("size=" + numTextSize.Value.ToString(), cfgFileName, 24);
            LineChanger("color=" + comboBox11.Text.ToString(), cfgFileName, 25);

            foreach (Panel pnl in fm1.Controls)
            {
                pnl.BackColor  = Color.Transparent;
            }
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1.showPlayerInfo = comboBox1.SelectedIndex;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1.timetype = comboBox4.SelectedIndex;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1.timeformat = comboBox6.SelectedIndex;
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1.showatk = comboBox10.SelectedIndex;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1.atkFormat = comboBox5.SelectedIndex;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1.showHP = comboBox2.SelectedIndex;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1.showMonsterInfo = comboBox3.SelectedIndex;
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1.ShowBP = comboBox9.SelectedIndex;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1.showDamage = comboBox7.SelectedIndex;
        }

        private void numericUpDown18_ValueChanged(object sender, EventArgs e)
        {
            Form1.damageTextSize = (int)numericUpDown18.Value;
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1.showSample = comboBox8.SelectedIndex;
        }

        private void numericUpDown13_ValueChanged(object sender, EventArgs e)
        {
            Form1.centerx = (int)numericUpDown13.Value;
        }

        private void numericUpDown12_ValueChanged(object sender, EventArgs e)
        {
            Form1.centery = (int)numericUpDown12.Value;
        }

        private void numericUpDown14_ValueChanged(object sender, EventArgs e)
        {
            Form1.height = (int)numericUpDown14.Value;
        }

        private void numericUpDown15_ValueChanged(object sender, EventArgs e)
        {
            Form1.width = (int)numericUpDown15.Value;
        }

        private void comTextFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1.textfont = comTextFont.Text;
            UpdateUI();
        }

        private void numTextSize_ValueChanged(object sender, EventArgs e)
        {
            Form1.textsize = (int)numTextSize.Value;
            UpdateUI();
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form1.textcolor = comboBox11.Text;
            UpdateUI();

            Color cor = Color.Wheat;
            switch (comboBox11.Text)
            {
                case "White":
                    cor = Color.WhiteSmoke;
                    break;
                case "Gray":
                    cor = Color.Silver;
                    break;
                case "Red":
                    cor = Color.Black; //IndianRed
                    break;
                case "Orange":
                    cor = Color.Black;
                    break;
                case "Yellow":
                    cor = Color.Black;
                    break;
                case "Green":
                    cor = Color.Black;
                    break;
                case "LimeGreen":
                    cor = Color.Black;
                    break;
                case "SkyBlue":
                    cor = Color.Black;
                    break;
                case "Cyan":
                    cor = Color.Black;
                    break;
                case "Blue":
                    cor = Color.Black;
                    break;
                case "Purple":
                    cor = Color.Black;
                    break;
                case "Black":
                    cor = Color.DimGray;
                    break;
                    default:
                    cor = Color.Black;
                        break;
            }
            //Color cor = Color.FromName(Form1.textcolor);

            //int r = (int)cor.R;
            //int b = (int)cor.B;
            //int g = (int)cor.G;

            //switch (r)
            //{
            //    case 0:
            //        r = r + 10;
            //        break;
            //    case 255:
            //        r = r - 10;
            //        break;
            //    case var expression when (r >= 0 && r < 255):
            //        r = r - 15;
            //        break;
            //}

            //switch (b)
            //{
            //    case 0:
            //        b = b + 10;
            //        break;
            //    case 255:
            //        b = b - 10;
            //        break;
            //    case var expression when (b >= 0 && b < 255):
            //        b = b - 15;
            //        break;
            //}

            //switch (g)
            //{
            //    case 0:
            //        g = g + 10;
            //        break;
            //    case 255:
            //        g = g - 10;
            //        break;
            //    case var expression when (g >= 0 && g < 255):
            //        g = g+5;
            //        break;
            //}




            //cor = Color.FromArgb(r,b,g);
            fm1.TransparencyKey = cor;
            fm1.BackColor = cor;
        }

        void UpdateUI()
        {
            foreach (Panel pnl in fm1.Controls)
            {
               //pnl.BackColor = coll;
                foreach (Control lbl in pnl.Controls)
                {
                    Font font = new Font(Form1.textfont, Form1.textsize, FontStyle.Regular);
                    lbl.ForeColor = Color.FromName(Form1.textcolor);
                    lbl.Font = font;
                    lbl.BackColor = Color.Transparent;

                }
            }

            Color cor = Color.FromName(Form1.textcolor);
           // cor = Color.FromArgb(cor.R + 1, cor.G, cor.B);

            //((Form1)Application.OpenForms["Form1"]).hoge();
        }

        private void Configcs_Load(object sender, EventArgs e)
        {
            InitUI();

            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                comTextFont.Items.Add(font.Name);
            }

            //foreach (System.Reflection.PropertyInfo prop in typeof(Color).GetProperties())
            //{
            //    if (prop.PropertyType.FullName == "System.Drawing.Color")
            //        comboBox11.Items.Add(prop.Name);
            //}

            comTextFont.Text = Form1.textfont;
            numTextSize.Value = Form1.textsize;
            comboBox11.Text = Form1.textcolor;

            UpdateUI();

        }
    }
}
