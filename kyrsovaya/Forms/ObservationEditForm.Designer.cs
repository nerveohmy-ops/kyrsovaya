namespace kyrsovaya.Forms
{
    partial class ObservationEditForm
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
            this.labelSpecies = new System.Windows.Forms.Label();
            this.cmbSpecies = new System.Windows.Forms.ComboBox();
            this.labelZone = new System.Windows.Forms.Label();
            this.cmbZone = new System.Windows.Forms.ComboBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.dateObservation = new System.Windows.Forms.DateTimePicker();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.labelNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            //
            // errorProvider
            //
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            //
            // species
            //
            this.labelSpecies.AutoSize = true;
            this.labelSpecies.Location = new System.Drawing.Point(20, 23);
            this.labelSpecies.Name = "labelSpecies";
            this.labelSpecies.Text = "Вид";
            this.cmbSpecies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecies.Location = new System.Drawing.Point(150, 20);
            this.cmbSpecies.Name = "cmbSpecies";
            this.cmbSpecies.Size = new System.Drawing.Size(300, 25);
            this.cmbSpecies.TabIndex = 0;
            //
            // zone
            //
            this.labelZone.AutoSize = true;
            this.labelZone.Location = new System.Drawing.Point(20, 63);
            this.labelZone.Name = "labelZone";
            this.labelZone.Text = "Участок";
            this.cmbZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZone.Location = new System.Drawing.Point(150, 60);
            this.cmbZone.Name = "cmbZone";
            this.cmbZone.Size = new System.Drawing.Size(300, 25);
            this.cmbZone.TabIndex = 1;
            //
            // date
            //
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(20, 103);
            this.labelDate.Name = "labelDate";
            this.labelDate.Text = "Дата";
            this.dateObservation.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateObservation.Location = new System.Drawing.Point(150, 100);
            this.dateObservation.Name = "dateObservation";
            this.dateObservation.Size = new System.Drawing.Size(150, 25);
            this.dateObservation.TabIndex = 2;
            //
            // quantity
            //
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Location = new System.Drawing.Point(20, 143);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Text = "Количество";
            this.numQuantity.Location = new System.Drawing.Point(150, 140);
            this.numQuantity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(150, 25);
            this.numQuantity.TabIndex = 3;
            this.numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            //
            // notes
            //
            this.labelNotes.AutoSize = true;
            this.labelNotes.Location = new System.Drawing.Point(20, 183);
            this.labelNotes.Name = "labelNotes";
            this.labelNotes.Text = "Примечание";
            this.txtNotes.Location = new System.Drawing.Point(150, 180);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(300, 90);
            this.txtNotes.TabIndex = 4;
            this.txtNotes.TextChanged += new System.EventHandler(this.txtNotes_TextChanged);
            //
            // buttons
            //
            this.btnSave.Location = new System.Drawing.Point(150, 295);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 38);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnCancel.Location = new System.Drawing.Point(310, 295);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 38);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // ObservationEditForm
            //
            this.AcceptButton = this.btnSave;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(480, 355);
            this.Controls.Add(this.labelSpecies);
            this.Controls.Add(this.cmbSpecies);
            this.Controls.Add(this.labelZone);
            this.Controls.Add(this.cmbZone);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.dateObservation);
            this.Controls.Add(this.labelQuantity);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.labelNotes);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ObservationEditForm";
            this.Text = "Наблюдение";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label labelSpecies;
        private System.Windows.Forms.ComboBox cmbSpecies;
        private System.Windows.Forms.Label labelZone;
        private System.Windows.Forms.ComboBox cmbZone;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.DateTimePicker dateObservation;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label labelNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
