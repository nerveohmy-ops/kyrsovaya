namespace kyrsovaya.Forms
{
    partial class ExcursionEditForm
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.labelZone = new System.Windows.Forms.Label();
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.labelGuide = new System.Windows.Forms.Label();
            this.cmbGuide = new System.Windows.Forms.ComboBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.labelMax = new System.Windows.Forms.Label();
            this.numMax = new System.Windows.Forms.NumericUpDown();
            this.chkIsOpen = new System.Windows.Forms.CheckBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).BeginInit();
            this.SuspendLayout();
            //
            // errorProvider
            //
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            //
            // title
            //
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(20, 23);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Text = "Название";
            this.txtTitle.Location = new System.Drawing.Point(170, 20);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(310, 25);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.TextChanged += new System.EventHandler(this.Field_Changed);
            //
            // zone
            //
            this.labelZone.AutoSize = true;
            this.labelZone.Location = new System.Drawing.Point(20, 63);
            this.labelZone.Name = "labelZone";
            this.labelZone.Text = "Участок парка";
            this.cmbZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZone.Location = new System.Drawing.Point(170, 60);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(310, 25);
            this.cmbZone.TabIndex = 1;
            //
            // guide
            //
            this.labelGuide.AutoSize = true;
            this.labelGuide.Location = new System.Drawing.Point(20, 103);
            this.labelGuide.Name = "labelGuide";
            this.labelGuide.Text = "Гид";
            this.cmbGuide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGuide.Location = new System.Drawing.Point(170, 100);
            this.cmbGuide.Name = "cmbGuide";
            this.cmbGuide.Size = new System.Drawing.Size(310, 25);
            this.cmbGuide.TabIndex = 2;
            //
            // date and time
            //
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(20, 143);
            this.labelDate.Name = "labelDate";
            this.labelDate.Text = "Дата и время";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(170, 140);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(160, 25);
            this.dtpDate.TabIndex = 3;
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime.Location = new System.Drawing.Point(345, 140);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new System.Drawing.Size(135, 25);
            this.dtpTime.TabIndex = 4;
            //
            // max participants
            //
            this.labelMax.AutoSize = true;
            this.labelMax.Location = new System.Drawing.Point(20, 183);
            this.labelMax.Name = "labelMax";
            this.labelMax.Text = "Макс. участников";
            this.numMax.Location = new System.Drawing.Point(170, 180);
            this.numMax.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numMax.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numMax.Name = "numMax";
            this.numMax.Size = new System.Drawing.Size(110, 25);
            this.numMax.TabIndex = 5;
            this.numMax.Value = new decimal(new int[] { 12, 0, 0, 0 });
            this.numMax.ValueChanged += new System.EventHandler(this.Field_Changed);
            //
            // isOpen
            //
            this.chkIsOpen.AutoSize = true;
            this.chkIsOpen.Location = new System.Drawing.Point(300, 183);
            this.chkIsOpen.Name = "chkIsOpen";
            this.chkIsOpen.TabIndex = 6;
            this.chkIsOpen.Text = "Открыта для записи";
            //
            // description
            //
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(20, 223);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Text = "Описание";
            this.txtDescription.Location = new System.Drawing.Point(170, 220);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(310, 95);
            this.txtDescription.TabIndex = 7;
            this.txtDescription.TextChanged += new System.EventHandler(this.Field_Changed);
            //
            // buttons
            //
            this.btnSave.Location = new System.Drawing.Point(170, 338);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(145, 38);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnCancel.Location = new System.Drawing.Point(335, 338);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(145, 38);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // ExcursionEditForm
            //
            this.AcceptButton = this.btnSave;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(515, 398);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.labelZone);
            this.Controls.Add(this.cmbZone);
            this.Controls.Add(this.labelGuide);
            this.Controls.Add(this.cmbGuide);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.labelMax);
            this.Controls.Add(this.numMax);
            this.Controls.Add(this.chkIsOpen);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExcursionEditForm";
            this.Text = "Экскурсия";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label labelZone;
        private System.Windows.Forms.ComboBox cmbZone;
        private System.Windows.Forms.Label labelGuide;
        private System.Windows.Forms.ComboBox cmbGuide;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.NumericUpDown numMax;
        private System.Windows.Forms.CheckBox chkIsOpen;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
