namespace kyrsovaya.Forms
{
    partial class AboutForm
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
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.txtAbout = new System.Windows.Forms.TextBox();
            this.tabGuide = new System.Windows.Forms.TabPage();
            this.txtGuide = new System.Windows.Forms.TextBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.tabAbout.SuspendLayout();
            this.tabGuide.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            //
            // tabs
            //
            this.tabs.Controls.Add(this.tabAbout);
            this.tabs.Controls.Add(this.tabGuide);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Name = "tabs";
            //
            // tabAbout
            //
            this.tabAbout.Controls.Add(this.txtAbout);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Text = "О программе";
            //
            // txtAbout
            //
            this.txtAbout.BackColor = System.Drawing.Color.White;
            this.txtAbout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAbout.Multiline = true;
            this.txtAbout.Name = "txtAbout";
            this.txtAbout.ReadOnly = true;
            this.txtAbout.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            //
            // tabGuide
            //
            this.tabGuide.Controls.Add(this.txtGuide);
            this.tabGuide.Name = "tabGuide";
            this.tabGuide.Text = "Руководство пользователя";
            //
            // txtGuide
            //
            this.txtGuide.BackColor = System.Drawing.Color.White;
            this.txtGuide.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGuide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGuide.Multiline = true;
            this.txtGuide.Name = "txtGuide";
            this.txtGuide.ReadOnly = true;
            this.txtGuide.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            //
            // panelBottom
            //
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(640, 56);
            //
            // btnClose
            //
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(510, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 36);
            this.btnClose.Text = "Назад";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // AboutForm
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(640, 520);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.panelBottom);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "AboutForm";
            this.Text = "Справка";
            this.tabs.ResumeLayout(false);
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            this.tabGuide.ResumeLayout(false);
            this.tabGuide.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.TextBox txtAbout;
        private System.Windows.Forms.TabPage tabGuide;
        private System.Windows.Forms.TextBox txtGuide;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnClose;
    }
}
