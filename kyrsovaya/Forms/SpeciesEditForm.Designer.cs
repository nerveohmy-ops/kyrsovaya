namespace kyrsovaya.Forms
{
    partial class SpeciesEditForm
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
            this.labelName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.labelLatin = new System.Windows.Forms.Label();
            this.txtLatin = new System.Windows.Forms.TextBox();
            this.labelKind = new System.Windows.Forms.Label();
            this.cmbKind = new System.Windows.Forms.ComboBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.labelPopulation = new System.Windows.Forms.Label();
            this.numPopulation = new System.Windows.Forms.NumericUpDown();
            this.labelDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPopulation)).BeginInit();
            this.SuspendLayout();
            //
            // errorProvider
            //
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            //
            // name
            //
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(20, 23);
            this.labelName.Name = "labelName";
            this.labelName.Text = "Название";
            this.txtName.Location = new System.Drawing.Point(180, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(300, 25);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.Field_TextChanged);
            //
            // latin
            //
            this.labelLatin.AutoSize = true;
            this.labelLatin.Location = new System.Drawing.Point(20, 63);
            this.labelLatin.Name = "labelLatin";
            this.labelLatin.Text = "Латинское название";
            this.txtLatin.Location = new System.Drawing.Point(180, 60);
            this.txtLatin.Name = "txtLatin";
            this.txtLatin.Size = new System.Drawing.Size(300, 25);
            this.txtLatin.TabIndex = 1;
            this.txtLatin.TextChanged += new System.EventHandler(this.Field_TextChanged);
            //
            // kind
            //
            this.labelKind.AutoSize = true;
            this.labelKind.Location = new System.Drawing.Point(20, 103);
            this.labelKind.Name = "labelKind";
            this.labelKind.Text = "Тип";
            this.cmbKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKind.Location = new System.Drawing.Point(180, 100);
            this.cmbKind.Name = "cmbKind";
            this.cmbKind.Size = new System.Drawing.Size(300, 25);
            this.cmbKind.TabIndex = 2;
            //
            // status
            //
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(20, 143);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Text = "Статус охраны";
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Location = new System.Drawing.Point(180, 140);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(300, 25);
            this.cmbStatus.TabIndex = 3;
            //
            // population
            //
            this.labelPopulation.AutoSize = true;
            this.labelPopulation.Location = new System.Drawing.Point(20, 183);
            this.labelPopulation.Name = "labelPopulation";
            this.labelPopulation.Text = "Численность";
            this.numPopulation.Location = new System.Drawing.Point(180, 180);
            this.numPopulation.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numPopulation.Name = "numPopulation";
            this.numPopulation.Size = new System.Drawing.Size(150, 25);
            this.numPopulation.TabIndex = 4;
            //
            // description
            //
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(20, 223);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Text = "Описание";
            this.txtDescription.Location = new System.Drawing.Point(180, 220);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(300, 100);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.TextChanged += new System.EventHandler(this.Field_TextChanged);
            //
            // buttons
            //
            this.btnSave.Location = new System.Drawing.Point(180, 345);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 38);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnCancel.Location = new System.Drawing.Point(340, 345);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 38);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // SpeciesEditForm
            //
            this.AcceptButton = this.btnSave;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(520, 405);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelLatin);
            this.Controls.Add(this.txtLatin);
            this.Controls.Add(this.labelKind);
            this.Controls.Add(this.cmbKind);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.labelPopulation);
            this.Controls.Add(this.numPopulation);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SpeciesEditForm";
            this.Text = "Вид";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPopulation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label labelLatin;
        private System.Windows.Forms.TextBox txtLatin;
        private System.Windows.Forms.Label labelKind;
        private System.Windows.Forms.ComboBox cmbKind;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label labelPopulation;
        private System.Windows.Forms.NumericUpDown numPopulation;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
