/*
 BDO Plus is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

BDO Plus is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with BDO Plus. If not, see <https://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using HtmlAgilityPack;
using System.Globalization;
using System.Runtime.InteropServices;
using BDO_Plus.Properties;


namespace BDO_Plus
{
    public partial class infoForm : Form
    {
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

        Properties.Settings Settings = new Properties.Settings();
        public infoForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
            this.TopMost = true;

            this.CenterToScreen();

            loadSettings();
        }
        private async void closefornow_Click(object sender, EventArgs e) => this.Close();

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.region = metroComboBox1.Text.ToLower();

            RGlabel.Text = metroComboBox1.Text;
        }
        private void saveBT_Click(object sender, EventArgs e)
        {
            Settings.Save();
            Application.Restart();
            Environment.Exit(0);
        }
        private void addBoss(string boss)
        {
            string bosslist = Settings.bosses;
            if (!bosslist.Contains(boss))
                bosslist += "\n"+ boss;
            bosslist = bosslist.Replace("\n\n", "\n");
            Settings.bosses = bosslist;
        }
        private void removeBoss(string boss)
        {
            string bosslist = Settings.bosses;
            if (bosslist.Contains(boss))
                bosslist = bosslist.Replace("\n" + boss, "");
            bosslist = bosslist.Replace("\n\n", "\n");
            Settings.bosses = bosslist;
        }
        private void VellBox_CheckedChanged(object sender, EventArgs e)
        {
            if (VellBox.Checked == false)
                removeBoss("Vell");
            else if (VellBox.Checked == true)
                addBoss("Vell");
        }

        private void KarandaBox_CheckedChanged(object sender, EventArgs e)
        {
            if (KarandaBox.Checked == false)
                removeBoss("Karanda");
            else if (KarandaBox.Checked == true)
                addBoss("Karanda");
        }

        private void GarmothBox_CheckedChanged(object sender, EventArgs e)
        {
            if (GarmothBox.Checked == false)
                removeBoss("Garmoth");
            else if (GarmothBox.Checked == true)
                addBoss("Garmoth");
        }

        private void kutbox_CheckedChanged(object sender, EventArgs e)
        {
            if (kutbox.Checked == false)
                removeBoss("Kutum");
            else if (kutbox.Checked == true)
                addBoss("Kutum");
        }

        private void KzarkaBox_CheckedChanged(object sender, EventArgs e)
        {
            if (KzarkaBox.Checked == false)
                removeBoss("Kzarka");
            else if (KzarkaBox.Checked == true)
                addBoss("Kzarka");
        }

        private void NouverBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NouverBox.Checked == false)
                removeBoss("Nouver");
            else if (NouverBox.Checked == true)
                addBoss("Nouver");
        }

        private void OffinBox_CheckedChanged(object sender, EventArgs e)
        {
            if (OffinBox.Checked == false)
                removeBoss("Offin");
            else if (OffinBox.Checked == true)
                addBoss("Offin");
        }

        private void QuintBox_CheckedChanged(object sender, EventArgs e)
        {
            if (QuintBox.Checked == false)
                removeBoss("Quint");
            else if (QuintBox.Checked == true)
                addBoss("Quint");
        }

        private void MurakaBox_CheckedChanged(object sender, EventArgs e)
        {
            if (MurakaBox.Checked == false)
                removeBoss("Muraka");
            else if (MurakaBox.Checked == true)
                addBoss("Muraka");
        }

        private void loadSettings()
        {
            RGlabel.Text = Settings.region.ToUpper();

            if (Settings.bosses.Contains(VellBox.Text))
                VellBox.Checked = true;
            else if (!Settings.bosses.Contains(VellBox.Text))
                VellBox.Checked = false;

            if (Settings.bosses.Contains(kutbox.Text))
                kutbox.Checked = true;
            else if (!Settings.bosses.Contains(kutbox.Text))
                kutbox.Checked = false;

            if (Settings.bosses.Contains(KarandaBox.Text))
                KarandaBox.Checked = true;
            else if (!Settings.bosses.Contains(KarandaBox.Text))
                KarandaBox.Checked = false;

            if (Settings.bosses.Contains(KzarkaBox.Text))
                KzarkaBox.Checked = true;
            else if (!Settings.bosses.Contains(KzarkaBox.Text))
                KzarkaBox.Checked = false;

            if (Settings.bosses.Contains(OffinBox.Text))
                OffinBox.Checked = true;
            else if (!Settings.bosses.Contains(OffinBox.Text))
                OffinBox.Checked = false;

            if (Settings.bosses.Contains(NouverBox.Text))
                NouverBox.Checked = true;
            else if (!Settings.bosses.Contains(NouverBox.Text))
                NouverBox.Checked = false;

            if (Settings.bosses.Contains(GarmothBox.Text))
                GarmothBox.Checked = true;
            else if (!Settings.bosses.Contains(GarmothBox.Text))
                GarmothBox.Checked = false;

            if (Settings.bosses.Contains(QuintBox.Text))
                QuintBox.Checked = true;
            else if (!Settings.bosses.Contains(QuintBox.Text))
                QuintBox.Checked = false;

            if (Settings.bosses.Contains(MurakaBox.Text))
                MurakaBox.Checked = true;
            else if (!Settings.bosses.Contains(MurakaBox.Text))
                MurakaBox.Checked = false;

            if (Settings.elixtimer == true)
                elixtimercheck.Checked = true;
            else if (Settings.elixtimer == false)
                elixtimercheck.Checked = false;

            if (Settings.daynight == true)
                daynightcheck.Checked = true;
            else if (Settings.daynight == false)
                daynightcheck.Checked = false;
        }

        private void elixtimercheck_CheckedChanged(object sender, EventArgs e)
        {
            if (elixtimercheck.Checked == true)
                Settings.elixtimer = true;
            else if (elixtimercheck.Checked == false)
                Settings.elixtimer = false;
        }

        private void daynightcheck_CheckedChanged(object sender, EventArgs e)
        {
            if (daynightcheck.Checked == true)
                Settings.daynight = true;
            else if (daynightcheck.Checked == false)
                Settings.daynight = false;
        }
    }
}
