namespace BDO_Plus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.daynight = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.nightclock = new System.Windows.Forms.Label();
            this.overlaynote = new System.Windows.Forms.Label();
            this.overlaynote2 = new System.Windows.Forms.Label();
            this.morebt = new System.Windows.Forms.Button();
            this.bosstime2 = new System.Windows.Forms.Label();
            this.bosstime1 = new System.Windows.Forms.Label();
            this.bossname2 = new System.Windows.Forms.Label();
            this.bossname1 = new System.Windows.Forms.Label();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.ElixLabel = new System.Windows.Forms.Label();
            this.timerElix = new System.Windows.Forms.Timer(this.components);
            this.elixstathelp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // daynight
            // 
            this.daynight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.daynight.AutoSize = true;
            this.daynight.Font = new System.Drawing.Font("Keifont", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.daynight.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.daynight.Location = new System.Drawing.Point(12, 55);
            this.daynight.Name = "daynight";
            this.daynight.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.daynight.Size = new System.Drawing.Size(91, 18);
            this.daynight.TabIndex = 6;
            this.daynight.Text = "Day/Night";
            this.daynight.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // nightclock
            // 
            this.nightclock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nightclock.AutoSize = true;
            this.nightclock.Font = new System.Drawing.Font("Keifont", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nightclock.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.nightclock.Location = new System.Drawing.Point(119, 55);
            this.nightclock.Name = "nightclock";
            this.nightclock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nightclock.Size = new System.Drawing.Size(80, 18);
            this.nightclock.TabIndex = 11;
            this.nightclock.Text = "00:00:00";
            this.nightclock.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // overlaynote
            // 
            this.overlaynote.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.overlaynote.AutoSize = true;
            this.overlaynote.Font = new System.Drawing.Font("Keifont", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.overlaynote.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.overlaynote.Location = new System.Drawing.Point(228, 47);
            this.overlaynote.Name = "overlaynote";
            this.overlaynote.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.overlaynote.Size = new System.Drawing.Size(91, 24);
            this.overlaynote.TabIndex = 12;
            this.overlaynote.Text = "press Alt+V to \r\nenable overlay";
            // 
            // overlaynote2
            // 
            this.overlaynote2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.overlaynote2.AutoSize = true;
            this.overlaynote2.BackColor = System.Drawing.Color.Transparent;
            this.overlaynote2.Font = new System.Drawing.Font("Keifont", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.overlaynote2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.overlaynote2.Location = new System.Drawing.Point(228, 10);
            this.overlaynote2.Name = "overlaynote2";
            this.overlaynote2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.overlaynote2.Size = new System.Drawing.Size(90, 12);
            this.overlaynote2.TabIndex = 13;
            this.overlaynote2.Text = "Alt+ESC to exit";
            // 
            // morebt
            // 
            this.morebt.BackColor = System.Drawing.Color.Transparent;
            this.morebt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.morebt.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.morebt.Location = new System.Drawing.Point(228, 73);
            this.morebt.Name = "morebt";
            this.morebt.Size = new System.Drawing.Size(88, 23);
            this.morebt.TabIndex = 15;
            this.morebt.Text = "More";
            this.morebt.UseVisualStyleBackColor = false;
            this.morebt.Click += new System.EventHandler(this.infobt_Click);
            this.morebt.MouseEnter += new System.EventHandler(this.infobt_MouseEnter);
            this.morebt.MouseLeave += new System.EventHandler(this.infobt_MouseLeave);
            this.morebt.MouseHover += new System.EventHandler(this.infobt_MouseHover);
            // 
            // bosstime2
            // 
            this.bosstime2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bosstime2.AutoSize = true;
            this.bosstime2.Font = new System.Drawing.Font("Keifont", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bosstime2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.bosstime2.Location = new System.Drawing.Point(119, 32);
            this.bosstime2.Name = "bosstime2";
            this.bosstime2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bosstime2.Size = new System.Drawing.Size(80, 18);
            this.bosstime2.TabIndex = 19;
            this.bosstime2.Text = "00:00:00";
            this.bosstime2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bosstime1
            // 
            this.bosstime1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bosstime1.AutoSize = true;
            this.bosstime1.Font = new System.Drawing.Font("Keifont", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bosstime1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.bosstime1.Location = new System.Drawing.Point(119, 9);
            this.bosstime1.Name = "bosstime1";
            this.bosstime1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bosstime1.Size = new System.Drawing.Size(80, 18);
            this.bosstime1.TabIndex = 18;
            this.bosstime1.Text = "00:00:00";
            this.bosstime1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bossname2
            // 
            this.bossname2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bossname2.AutoSize = true;
            this.bossname2.Font = new System.Drawing.Font("Keifont", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bossname2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.bossname2.Location = new System.Drawing.Point(12, 32);
            this.bossname2.Name = "bossname2";
            this.bossname2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bossname2.Size = new System.Drawing.Size(97, 18);
            this.bossname2.TabIndex = 17;
            this.bossname2.Text = "Boss Name";
            this.bossname2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bossname1
            // 
            this.bossname1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bossname1.AutoSize = true;
            this.bossname1.Font = new System.Drawing.Font("Keifont", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bossname1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.bossname1.Location = new System.Drawing.Point(12, 9);
            this.bossname1.Name = "bossname1";
            this.bossname1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bossname1.Size = new System.Drawing.Size(97, 18);
            this.bossname1.TabIndex = 16;
            this.bossname1.Text = "Boss Name";
            this.bossname1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timer3
            // 
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // ElixLabel
            // 
            this.ElixLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ElixLabel.AutoSize = true;
            this.ElixLabel.Font = new System.Drawing.Font("Keifont", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ElixLabel.ForeColor = System.Drawing.Color.SpringGreen;
            this.ElixLabel.Location = new System.Drawing.Point(12, 78);
            this.ElixLabel.Name = "ElixLabel";
            this.ElixLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ElixLabel.Size = new System.Drawing.Size(104, 18);
            this.ElixLabel.TabIndex = 20;
            this.ElixLabel.Text = "Elixirs Stats";
            this.ElixLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ElixLabel.Visible = false;
            this.ElixLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ElixLabel_MouseDown);
            // 
            // timerElix
            // 
            this.timerElix.Interval = 1000;
            this.timerElix.Tick += new System.EventHandler(this.timerElix_Tick);
            // 
            // elixstathelp
            // 
            this.elixstathelp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.elixstathelp.AutoSize = true;
            this.elixstathelp.BackColor = System.Drawing.Color.Transparent;
            this.elixstathelp.Font = new System.Drawing.Font("Keifont", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.elixstathelp.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.elixstathelp.Location = new System.Drawing.Point(12, 81);
            this.elixstathelp.Name = "elixstathelp";
            this.elixstathelp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.elixstathelp.Size = new System.Drawing.Size(126, 12);
            this.elixstathelp.TabIndex = 21;
            this.elixstathelp.Text = "ALT+E to start Elixirs";
            this.elixstathelp.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(324, 104);
            this.ControlBox = false;
            this.Controls.Add(this.elixstathelp);
            this.Controls.Add(this.ElixLabel);
            this.Controls.Add(this.bosstime2);
            this.Controls.Add(this.bosstime1);
            this.Controls.Add(this.bossname2);
            this.Controls.Add(this.bossname1);
            this.Controls.Add(this.morebt);
            this.Controls.Add(this.overlaynote);
            this.Controls.Add(this.nightclock);
            this.Controls.Add(this.overlaynote2);
            this.Controls.Add(this.daynight);
            this.Font = new System.Drawing.Font("Keifont", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "BDO Plus";
            this.TopMost = true;
            this.LocationChanged += new System.EventHandler(this.Form1_LocationChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label daynight;
        private System.Windows.Forms.Timer timer1;
        private Label nightclock;
        private Label overlaynote;
        private Label overlaynote2;
        private Button morebt;
        private Label bosstime2;
        private Label bosstime1;
        private Label bossname2;
        private Label bossname1;
        private System.Windows.Forms.Timer timer3;
        private Label ElixLabel;
        private System.Windows.Forms.Timer timerElix;
        private Label elixstathelp;
    }
}