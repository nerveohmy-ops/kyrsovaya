namespace kyrsovaya.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerSlideshow = new System.Windows.Forms.Timer(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGuide = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.labelLogo = new System.Windows.Forms.Label();
            this.btnSpecies = new System.Windows.Forms.Button();
            this.btnObservations = new System.Windows.Forms.Button();
            this.btnExcursions = new System.Windows.Forms.Button();
            this.btnZones = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.labelRole = new System.Windows.Forms.Label();
            this.labelSpeciesCount = new System.Windows.Forms.Label();
            this.labelThreatened = new System.Windows.Forms.Label();
            this.labelObservations = new System.Windows.Forms.Label();
            this.labelExcursions = new System.Windows.Forms.Label();
            this.labelStaff = new System.Windows.Forms.Label();
            this.pictureStaff = new System.Windows.Forms.PictureBox();
            this.menuStrip.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureStaff)).BeginInit();
            this.SuspendLayout();
            //
            // timerSlideshow
            //
            this.timerSlideshow.Interval = 4000;
            this.timerSlideshow.Tick += new System.EventHandler(this.timerSlideshow_Tick);
            //
            // menuStrip
            //
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.menuHelp });
            this.menuStrip.Name = "menuStrip";
            //
            // menuHelp
            //
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.menuGuide, this.menuAbout });
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Text = "Справка";
            //
            // menuGuide
            //
            this.menuGuide.Name = "menuGuide";
            this.menuGuide.Text = "Руководство пользователя";
            this.menuGuide.Click += new System.EventHandler(this.menuGuide_Click);
            //
            // menuAbout
            //
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Text = "О программе";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            //
            // panelMenu
            //
            this.panelMenu.Controls.Add(this.btnExit);
            this.panelMenu.Controls.Add(this.btnLogout);
            this.panelMenu.Controls.Add(this.btnProfile);
            this.panelMenu.Controls.Add(this.btnUsers);
            this.panelMenu.Controls.Add(this.btnZones);
            this.panelMenu.Controls.Add(this.btnExcursions);
            this.panelMenu.Controls.Add(this.btnObservations);
            this.panelMenu.Controls.Add(this.btnSpecies);
            this.panelMenu.Controls.Add(this.labelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(240, 600);
            //
            // labelLogo
            //
            this.labelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelLogo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelLogo.ForeColor = System.Drawing.Color.White;
            this.labelLogo.Name = "labelLogo";
            this.labelLogo.Size = new System.Drawing.Size(240, 80);
            this.labelLogo.Text = "GRINPICH\r\nNATION";
            this.labelLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // btnSpecies
            //
            this.btnSpecies.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSpecies.Name = "btnSpecies";
            this.btnSpecies.Size = new System.Drawing.Size(240, 50);
            this.btnSpecies.Tag = "menu";
            this.btnSpecies.Text = "Редкие виды";
            this.btnSpecies.Click += new System.EventHandler(this.btnSpecies_Click);
            //
            // btnObservations
            //
            this.btnObservations.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnObservations.Name = "btnObservations";
            this.btnObservations.Size = new System.Drawing.Size(240, 50);
            this.btnObservations.Tag = "menu";
            this.btnObservations.Text = "Журнал наблюдений";
            this.btnObservations.Click += new System.EventHandler(this.btnObservations_Click);
            //
            // btnExcursions
            //
            this.btnExcursions.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExcursions.Name = "btnExcursions";
            this.btnExcursions.Size = new System.Drawing.Size(240, 50);
            this.btnExcursions.Tag = "menu";
            this.btnExcursions.Text = "Экскурсии";
            this.btnExcursions.Click += new System.EventHandler(this.btnExcursions_Click);
            //
            // btnZones
            //
            this.btnZones.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnZones.Name = "btnZones";
            this.btnZones.Size = new System.Drawing.Size(240, 50);
            this.btnZones.Tag = "menu";
            this.btnZones.Text = "Участки парка";
            this.btnZones.Click += new System.EventHandler(this.btnZones_Click);
            //
            // btnUsers
            //
            this.btnUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(240, 50);
            this.btnUsers.Tag = "menu";
            this.btnUsers.Text = "Пользователи";
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            //
            // btnProfile
            //
            this.btnProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(240, 50);
            this.btnProfile.Tag = "menu";
            this.btnProfile.Text = "Личный кабинет";
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            //
            // btnExit
            //
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(240, 50);
            this.btnExit.Tag = "menu";
            this.btnExit.Text = "Выход";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            //
            // btnLogout
            //
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(240, 50);
            this.btnLogout.Tag = "menu";
            this.btnLogout.Text = "Сменить пользователя";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            //
            // panelContent
            //
            this.panelContent.Controls.Add(this.panelInfo);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Name = "panelContent";
            //
            // panelInfo (белая карточка поверх фона)
            //
            this.panelInfo.BackColor = System.Drawing.Color.White;
            this.panelInfo.Controls.Add(this.pictureStaff);
            this.panelInfo.Controls.Add(this.labelStaff);
            this.panelInfo.Controls.Add(this.labelExcursions);
            this.panelInfo.Controls.Add(this.labelObservations);
            this.panelInfo.Controls.Add(this.labelThreatened);
            this.panelInfo.Controls.Add(this.labelSpeciesCount);
            this.panelInfo.Controls.Add(this.labelRole);
            this.panelInfo.Controls.Add(this.labelWelcome);
            this.panelInfo.Location = new System.Drawing.Point(40, 40);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(620, 360);
            //
            // labelWelcome
            //
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelWelcome.ForeColor = System.Drawing.Color.FromArgb(28, 70, 42);
            this.labelWelcome.Location = new System.Drawing.Point(20, 18);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Text = "Добро пожаловать!";
            //
            // labelRole
            //
            this.labelRole.AutoSize = true;
            this.labelRole.Location = new System.Drawing.Point(22, 60);
            this.labelRole.Name = "labelRole";
            this.labelRole.Text = "Роль";
            //
            // labelSpeciesCount
            //
            this.labelSpeciesCount.AutoSize = true;
            this.labelSpeciesCount.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelSpeciesCount.Location = new System.Drawing.Point(22, 120);
            this.labelSpeciesCount.Name = "labelSpeciesCount";
            //
            // labelThreatened
            //
            this.labelThreatened.AutoSize = true;
            this.labelThreatened.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelThreatened.Location = new System.Drawing.Point(22, 160);
            this.labelThreatened.Name = "labelThreatened";
            //
            // labelObservations
            //
            this.labelObservations.AutoSize = true;
            this.labelObservations.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelObservations.Location = new System.Drawing.Point(22, 200);
            this.labelObservations.Name = "labelObservations";
            //
            // labelExcursions
            //
            this.labelExcursions.AutoSize = true;
            this.labelExcursions.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelExcursions.Location = new System.Drawing.Point(22, 240);
            this.labelExcursions.Name = "labelExcursions";
            //
            // labelStaff
            //
            this.labelStaff.Location = new System.Drawing.Point(330, 14);
            this.labelStaff.Name = "labelStaff";
            this.labelStaff.Size = new System.Drawing.Size(270, 24);
            this.labelStaff.Text = "Наши сотрудники";
            this.labelStaff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // pictureStaff
            //
            this.pictureStaff.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureStaff.Location = new System.Drawing.Point(330, 44);
            this.pictureStaff.Name = "pictureStaff";
            this.pictureStaff.Size = new System.Drawing.Size(270, 300);
            this.pictureStaff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureStaff.TabStop = false;
            //
            // MainForm
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(960, 600);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(900, 560);
            this.Name = "MainForm";
            this.Text = "Главное меню";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureStaff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timerSlideshow;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuGuide;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Label labelLogo;
        private System.Windows.Forms.Button btnSpecies;
        private System.Windows.Forms.Button btnObservations;
        private System.Windows.Forms.Button btnExcursions;
        private System.Windows.Forms.Button btnZones;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.Label labelSpeciesCount;
        private System.Windows.Forms.Label labelThreatened;
        private System.Windows.Forms.Label labelObservations;
        private System.Windows.Forms.Label labelExcursions;
        private System.Windows.Forms.Label labelStaff;
        private System.Windows.Forms.PictureBox pictureStaff;
    }
}
