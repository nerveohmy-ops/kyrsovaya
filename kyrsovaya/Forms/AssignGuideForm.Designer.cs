namespace kyrsovaya.Forms
{
    partial class AssignGuideForm
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
            this.labelExcursion = new System.Windows.Forms.Label();
            this.labelGuide = new System.Windows.Forms.Label();
            this.cmbGuide = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // labelExcursion
            //
            this.labelExcursion.Location = new System.Drawing.Point(20, 18);
            this.labelExcursion.Name = "labelExcursion";
            this.labelExcursion.Size = new System.Drawing.Size(390, 40);
            this.labelExcursion.Text = "Экскурсия";
            //
            // labelGuide
            //
            this.labelGuide.AutoSize = true;
            this.labelGuide.Location = new System.Drawing.Point(20, 72);
            this.labelGuide.Name = "labelGuide";
            this.labelGuide.Text = "Выберите гида:";
            //
            // cmbGuide
            //
            this.cmbGuide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGuide.Location = new System.Drawing.Point(20, 98);
            this.cmbGuide.Name = "cmbGuide";
            this.cmbGuide.Size = new System.Drawing.Size(390, 25);
            this.cmbGuide.TabIndex = 0;
            //
            // btnSave
            //
            this.btnSave.Location = new System.Drawing.Point(130, 145);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(135, 36);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Назначить";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(275, 145);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 36);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // AssignGuideForm
            //
            this.AcceptButton = this.btnSave;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(430, 200);
            this.Controls.Add(this.labelExcursion);
            this.Controls.Add(this.labelGuide);
            this.Controls.Add(this.cmbGuide);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AssignGuideForm";
            this.Text = "Назначение гида";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelExcursion;
        private System.Windows.Forms.Label labelGuide;
        private System.Windows.Forms.ComboBox cmbGuide;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
