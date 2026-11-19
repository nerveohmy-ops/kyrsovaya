namespace kyrsovaya.Forms
{
    partial class ForgotPasswordForm
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
            this.labelHint = new System.Windows.Forms.Label();
            this.txtIdentifier = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            //
            // errorProvider
            //
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            //
            // labelTitle
            //
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(20, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(380, 32);
            this.labelTitle.Text = "Восстановление пароля";
            //
            // labelHint
            //
            this.labelHint.Location = new System.Drawing.Point(22, 55);
            this.labelHint.Name = "labelHint";
            this.labelHint.Size = new System.Drawing.Size(380, 45);
            this.labelHint.Text = "Введите логин, email или телефон. Новый пароль придёт на email, указанный при регистрации.";
            //
            // txtIdentifier
            //
            this.txtIdentifier.Location = new System.Drawing.Point(25, 110);
            this.txtIdentifier.Name = "txtIdentifier";
            this.txtIdentifier.Size = new System.Drawing.Size(360, 25);
            this.txtIdentifier.TabIndex = 0;
            this.txtIdentifier.TextChanged += new System.EventHandler(this.txtIdentifier_TextChanged);
            //
            // btnReset
            //
            this.btnReset.Location = new System.Drawing.Point(185, 160);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(200, 38);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Получить новый пароль";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            //
            // btnBack
            //
            this.btnBack.Location = new System.Drawing.Point(25, 160);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(130, 38);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Назад";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            //
            // ForgotPasswordForm
            //
            this.AcceptButton = this.btnReset;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(420, 225);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelHint);
            this.Controls.Add(this.txtIdentifier);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ForgotPasswordForm";
            this.Text = "Забыли пароль";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelHint;
        private System.Windows.Forms.TextBox txtIdentifier;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnBack;
    }
}
