/*
 BDO Plus is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

BDO Plus is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with BDO Plus. If not, see <https://www.gnu.org/licenses/>.
 */
namespace BDO_Plus
{
    using HtmlAgilityPack;
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Speech.Synthesis;
    using System.Text.RegularExpressions;


    public partial class Form1 : Form
    {
        KeyboardHook hookoverlay = new KeyboardHook();
        KeyboardHook hookTXToverlay = new KeyboardHook();
        KeyboardHook hookExit = new KeyboardHook();
        KeyboardHook hookElixir = new KeyboardHook();

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public Form1()
        {
            Guid g = new Guid("81dee518-e488-416c-8bf4-c8a4e050325d");

            InitializeComponent();

            morebt.FlatStyle=FlatStyle.Flat;
            morebt.FlatAppearance.BorderSize=0;

            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
            this.TopMost = true;


            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://mmotimer.com/bdo/");
                webRequest.Method = "GET";

                string responseData = string.Empty;
                HttpWebResponse httpResponse = (HttpWebResponse)webRequest.GetResponse();

                using (StreamReader responseReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    responseData = responseReader.ReadToEnd();
                }
            }
            catch (System.Net.WebException ex)
            {
                DialogResult result = MessageBox.Show("BDO Plus gets data through network, please me sure that you have internet connection and BDO Plus is not blocked in your firewall", "Unable to connect", MessageBoxButtons.OK,MessageBoxIcon.Error);
                if(result == DialogResult.OK)
                {
                    Application.Exit();
                }
                Application.Exit();
            }

            daynight.Text = "";
            nightclock.Text = "";
            bossname1.Text = "";
            bossname2.Text = "";
            bosstime1.Text = "";
            bosstime2.Text = "";

            getDayTime();

            hookoverlay.KeyPressed +=
               new EventHandler<KeyPressedEventArgs>(hook_KeyPressed2);
            hookoverlay.RegisterHotKey(ModKeys.Alt, Keys.V);

            hookTXToverlay.KeyPressed +=
               new EventHandler<KeyPressedEventArgs>(hook_KeyPressedH);
            hookTXToverlay.RegisterHotKey(ModKeys.Alt, Keys.H);

            hookExit.KeyPressed +=
               new EventHandler<KeyPressedEventArgs>(hook_KeyPressed_Exit);
            hookExit.RegisterHotKey(ModKeys.Alt, Keys.Escape);

            hookElixir.KeyPressed +=
               new EventHandler<KeyPressedEventArgs>(hook_KeyPressed_Elixir);
            hookElixir.RegisterHotKey(ModKeys.Alt, Keys.E);

            LoadSettings();
        }

        Properties.Settings Settings = new Properties.Settings();

        string webData;
        string ColData = "";
        DateTime dateTime;
        string webData2;
        DateTime dateTimeF;
        DateTime dateTimeS;
        bool secBossFound = false;
        private void getDayTime()
        {
            timer1.Stop();
            countBoss = true;
            countDay = true;
            dateTime = DateTime.MinValue;
            dateTimeF = DateTime.MinValue;

            HtmlWeb wbsite = new HtmlWeb();
            HtmlDocument document = wbsite.Load("https://mmotimer.com/bdo/");
            var datalist = document.DocumentNode.SelectNodes("//div[@class='col-md-6']").ToList();

            foreach (var content in datalist)
            {
                webData = webData + content.InnerText;
            }
            var lines = webData.Split("\n");
            if (lines[2].Contains("Night"))
            {
                string output = lines[2].Substring(lines[2].IndexOf('N'));
                ColData = output;
            }
            else if (lines[2].Contains("Day"))
            {
                string output = lines[2].Substring(lines[2].IndexOf('D'));
                ColData = output;
            }
            string[] testing = ColData.Split(" ");
            string[] timeLeft = testing[2].Split(":");
            string hour = timeLeft[0], min = timeLeft[1], sec = timeLeft[2];

            ColData = testing[0] + " " + testing[1]+" ";
            daynight.Text = ColData;

            dateTime = DateTime.ParseExact(hour, "HH", CultureInfo.InvariantCulture);
            dateTime = dateTime.AddMinutes(Int32.Parse(min));

            string region = Settings.region;
            HtmlWeb wbsite2 = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument document2 = wbsite2.Load("https://mmotimer.com/bdo/streamwidget/stream.php?server=" + region);
            var datalist2 = document2.DocumentNode.SelectNodes("//table[@class='table table-borderless']").ToList();
            foreach (var content2 in datalist2)
            {
                webData2 = webData2 + content2.InnerText;
            }
            webData2 = Regex.Replace(webData2, @"\s+", " ");
            var linesN = webData2.Split(" ");

            string firstBoss = linesN[1], firstBossTime = linesN[2];
            string secBoss = "", secBossTime = "";
            bossname1.Text = firstBoss;
            try
            {
                secBossFound = false;
                secBoss = linesN[3];
                secBossTime = linesN[4];
                bossname2.Text = secBoss;
                bool checktime2 = secBossTime.Contains(":");
                secBossFound = true;
                if (checktime2 == false)
                    secBossFound = false;
            }
            catch
            {
                secBossFound = false;
            }

            if (secBossFound == false)
            {
                bossname2.Text = "";
                bosstime2.Text = "";
            }

            if (Settings.bosses.Contains(firstBoss))
            {
                bossname1.Visible = true;
                bosstime1.Visible = true;
            }
            else
            {
                bossname1.Visible = false;
                bosstime1.Visible = false;
            }

            if (Settings.bosses.Contains(secBoss))
            {
                bossname2.Visible = true;
                bosstime2.Visible = true;
            }
            else
            {
                bossname2.Visible = false;
                bosstime2.Visible = false;
            }

            string[] timeLeftF = firstBossTime.Split(":");
            string hourF = timeLeftF[0], minF = timeLeftF[1], secF = timeLeftF[2];

            dateTimeF = DateTime.ParseExact(hourF, "HH", CultureInfo.InvariantCulture);
            dateTimeF = dateTimeF.AddMinutes(Int32.Parse(minF)).AddSeconds(Int32.Parse(secF));

            dateTime = dateTime.AddSeconds(Int32.Parse(secF));

            timer1.Start();

            webData = null;
            webData2 = null;
        }
        bool needRefresh = false, countDay = true, countBoss = true;
        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (countBoss == true)
                dateTimeF = dateTimeF.AddSeconds(-1);
            if (countDay == true)
                dateTime = dateTime.AddSeconds(-1);

            if (countDay == true)
                nightclock.Text = dateTime.ToString("HH:mm:ss");
            if(countBoss == true)
            {
                bosstime1.Text = dateTimeF.ToString("HH:mm:ss");
                if (secBossFound == true)
                    bosstime2.Text = dateTimeF.ToString("HH:mm:ss");
            }

            if (needRefresh == true)
            {
                this.Refresh();
                needRefresh = false;
            }

            if (dateTime.ToString("HH:mm:ss") == "00:00:01" && countDay == true)
            {
                countDay = false;

                await Task.Delay(100);
                if (ColData.Contains("Night"))
                {
                    daynight.Text = "It's night now!";
                    nightclock.Text = "";
                }
                else if (ColData.Contains("Day"))
                {
                    daynight.Text = "It's day now!";
                    nightclock.Text = "";
                }
                this.Refresh();
                needRefresh = true;

                timer3.Start();

            }
            if (dateTimeF.ToString("HH:mm:ss") == "00:00:01" && countBoss == true)
            {
                countBoss = false;

                await Task.Delay(100);
                bosstime1.Text = "Spawned!";
                if (secBossFound == true)
                    bosstime2.Text = "Spawned!";
                this.Refresh();
                needRefresh = true;

                timer3.Start();
            }
        }
        int CD = 0;
        private async void timer3_Tick(object sender, EventArgs e)
        {
            if (CD < 10)
                CD++;
            else if (CD >= 10)
            {
                timer3.Stop();
                CD = 0;
                getDayTime();
            }
        }
        private void LoadSettings()
        {
            this.Location = Settings.windowPos;

            if (Settings.windowPos.Y == 0 && Settings.windowPos.X == 0)
                this.CenterToScreen();

            if (Settings.isoverlay == true)
            {
                this.BackColor = Color.Gray;
                this.AllowTransparency = true;
                this.TransparencyKey = Color.Gray;
                morebt.Visible = false;
                overlaynote.Text = "press Alt+V to \ndisable overlay";
            }
            if (Settings.hidetxt == true)
            {
                overlaynote.Visible = false;
                overlaynote2.Visible = false;
            }

            if (Settings.elixtimer == true)
                elixstathelp.Visible = true;

            if (Settings.daynight == true)
            {
                daynight.Visible = true;
                nightclock.Visible = true;
            }
            else if (Settings.daynight == false)
            {
                daynight.Visible = false;
                nightclock.Visible = false;
            }
        }

        async void hook_KeyPressed2(object sender, KeyPressedEventArgs e)
        {
            if(Settings.isoverlay == false)
            {
                this.BackColor = Color.Gray;
                this.AllowTransparency = true;
                this.TransparencyKey = Color.Gray;
                morebt.Visible = false;
                overlaynote.Text = "press Alt+V to \ndisable overlay";

                Settings.isoverlay = true;
                Settings.Save();
            }
            else if (Settings.isoverlay == true)
            {
                this.BackColor = Color.FromArgb(18, 18, 18);
                this.AllowTransparency = false;
                morebt.Visible = true;
                overlaynote.Text = "press Alt+V to \nenable overlay";

                Settings.isoverlay = false;
                Settings.Save();
            }
        }
        async void hook_KeyPressedH(object sender, KeyPressedEventArgs e)
        {
            if (Settings.hidetxt == false)
            {
                overlaynote.Visible = false;
                overlaynote2.Visible = false;

                Settings.hidetxt = true;
                Settings.Save();
            }
            else if (Settings.hidetxt == true)
            {
                overlaynote.Visible = true;
                overlaynote2.Visible = true;

                Settings.hidetxt = false;
                Settings.Save();
            }
        }

        async void hook_KeyPressed_Exit(object sender, KeyPressedEventArgs e)
        {
            Settings.windowPos = this.Location;
            Settings.Save();
            await Task.Delay(100);
            Application.Exit();
        }
        DateTime DateTimeElix;
        int AfkElixTime = 0;
        bool countElix = true;
        async void hook_KeyPressed_Elixir(object sender, KeyPressedEventArgs e)
        {
            if (Settings.elixtimer == false)
                return;
            countElix = true;
            AfkElixTime = 0;
            DateTimeElix = DateTime.MinValue;
            ElixLabel.Text = "Elixirs Are Running";
            ElixLabel.ForeColor = Color.SpringGreen;
            ElixLabel.Visible = true;
            elixstathelp.Visible = false;
            DateTimeElix = DateTime.ParseExact("15", "mm", CultureInfo.InvariantCulture);
            timerElix.Start();
        }
        private void timerElix_Tick(object sender, EventArgs e)
        {
            if (countElix == true)
                DateTimeElix = DateTimeElix.AddSeconds(-1);
            if (DateTimeElix.ToString("HH:mm:ss") == "00:00:10")
            {
                countElix = false;
                DateTimeElix = DateTime.MinValue;
                ElixLabel.Text = "Repop Elixirs! (ALT+E)";
                ElixLabel.ForeColor = Color.Coral;
                vocetosp("Re Pop Elixirs");
            }
            if (countElix == false)
            {
                AfkElixTime ++;
                if (AfkElixTime == 60)
                {
                    ElixLabel.Visible = false;
                    elixstathelp.Visible = true;
                }
            }
        }

        SpeechSynthesizer synth = new SpeechSynthesizer();
        private async void vocetosp(string TTS)
        {
            synth.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Child);
            synth.SetOutputToDefaultAudioDevice();
            synth.Rate = -2;
            synth.Volume = 80;
            synth.SpeakAsync(TTS);

        }
        private void moveform(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e) => moveform(sender,e);
        private void nightclock_MouseDown(object sender, MouseEventArgs e) => moveform(sender, e);
        private void daynight_MouseDown(object sender, MouseEventArgs e) => moveform(sender, e);
        private void overlaynote_MouseDown(object sender, MouseEventArgs e) => moveform(sender, e);
        private void label1_MouseDown(object sender, MouseEventArgs e) => moveform(sender, e);
        private void label2_MouseDown(object sender, MouseEventArgs e) => moveform(sender, e);
        private void ElixLabel_MouseDown(object sender, MouseEventArgs e) => moveform(sender, e);

        private async void Form1_LocationChanged(object sender, EventArgs e)
        {
            Settings.windowPos = this.Location;
            Settings.Save();
        }

        private void infobt_Click(object sender, EventArgs e)
        {
            infoForm inf = new infoForm();
            inf.Show();
        }

        private void infobt_MouseHover(object sender, EventArgs e) => morebt.BackColor = Color.FromArgb(8, 8, 8);
        private void infobt_MouseLeave(object sender, EventArgs e) => morebt.BackColor = Color.Transparent;
        private void infobt_MouseEnter(object sender, EventArgs e) => morebt.BackColor = Color.FromArgb(8, 8, 8);

    }
}