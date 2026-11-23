namespace kyrsovaya.Forms
{
    partial class RegisterForm
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
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.mtbPhone = new System.Windows.Forms.MaskedTextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnEyePassword = new System.Windows.Forms.Button();
            this.labelRepeat = new System.Windows.Forms.Label();
            this.txtRepeat = new System.Windows.Forms.TextBox();
            this.btnEyeRepeat = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
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
            this.labelTitle.Size = new System.Drawing.Size(400, 32);
            this.labelTitle.Text = "Регистрация";
            //
            // labelLastName / txtLastName
            //
            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(25, 60);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Text = "Фамилия";
            this.txtLastName.Location = new System.Drawing.Point(180, 57);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(240, 25);
            this.txtLastName.TabIndex = 0;
            this.txtLastName.TextChanged += new System.EventHandler(this.Field_TextChanged);
            //
            // labelFirstName / txtFirstName
            //
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(25, 100);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Text = "Имя";
            this.txtFirstName.Location = new System.Drawing.Point(180, 97);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(240, 25);
            this.txtFirstName.TabIndex = 1;
            this.txtFirstName.TextChanged += new System.EventHandler(this.Field_TextChanged);
            //
            // labelLogin / txtLogin
            //
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(25, 140);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Text = "Логин";
            this.txtLogin.Location = new System.Drawing.Point(180, 137);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(240, 25);
            this.txtLogin.TabIndex = 2;
            this.txtLogin.TextChanged += new System.EventHandler(this.Field_TextChanged);
            //
            // labelEmail / txtEmail
            //
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(25, 180);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Text = "Email";
            this.txtEmail.Location = new System.Drawing.Point(180, 177);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(240, 25);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.TextChanged += new System.EventHandler(this.Field_TextChanged);
            //
            // labelPhone / mtbPhone
            //
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(25, 220);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Text = "Телефон";
            this.mtbPhone.Location = new System.Drawing.Point(180, 217);
            this.mtbPhone.Mask = "+7 (000) 000-00-00";
            this.mtbPhone.Name = "mtbPhone";
            this.mtbPhone.Size = new System.Drawing.Size(240, 25);
            this.mtbPhone.TabIndex = 4;
            this.mtbPhone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtbPhone.TextChanged += new System.EventHandler(this.Field_TextChanged);
            //
            // labelPassword / txtPassword
            //
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(25, 260);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Text = "Пароль";
            this.txtPassword.Location = new System.Drawing.Point(180, 257);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(206, 25);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.Field_TextChanged);
            this.btnEyePassword.Location = new System.Drawing.Point(408, 257);
            this.btnEyePassword.Name = "btnEyePassword";
            this.btnEyePassword.Size = new System.Drawing.Size(34, 25);
            this.btnEyePassword.TabStop = false;
            this.btnEyePassword.Tag = "eye";
            //
            // labelRepeat / txtRepeat
            //
            this.labelRepeat.AutoSize = true;
            this.labelRepeat.Location = new System.Drawing.Point(25, 300);
            this.labelRepeat.Name = "labelRepeat";
            this.labelRepeat.Text = "Повторите пароль";
            this.txtRepeat.Location = new System.Drawing.Point(180, 297);
            this.txtRepeat.Name = "txtRepeat";
            this.txtRepeat.Size = new System.Drawing.Size(206, 25);
            this.txtRepeat.TabIndex = 6;
            this.txtRepeat.UseSystemPasswordChar = true;
            this.txtRepeat.TextChanged += new System.EventHandler(this.Field_TextChanged);
            this.btnEyeRepeat.Location = new System.Drawing.Point(408, 297);
            this.btnEyeRepeat.Name = "btnEyeRepeat";
            this.btnEyeRepeat.Size = new System.Drawing.Size(34, 25);
            this.btnEyeRepeat.TabStop = false;
            this.btnEyeRepeat.Tag = "eye";
            //
            // btnRegister
            //
            this.btnRegister.Location = new System.Drawing.Point(180, 348);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(262, 38);
            this.btnRegister.TabIndex = 7;
            this.btnRegister.Text = "Зарегистрироваться";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            //
            // btnBack
            //
            this.btnBack.Location = new System.Drawing.Point(25, 348);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(130, 38);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Назад";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            //
            // RegisterForm
            //
            this.AcceptButton = this.btnRegister;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(480, 410);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.labelFirstName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.mtbPhone);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnEyePassword);
            this.Controls.Add(this.labelRepeat);
            this.Controls.Add(this.txtRepeat);
            this.Controls.Add(this.btnEyeRepeat);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterForm";
            this.Text = "Регистрация";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.MaskedTextBox mtbPhone;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnEyePassword;
        private System.Windows.Forms.Label labelRepeat;
        private System.Windows.Forms.TextBox txtRepeat;
        private System.Windows.Forms.Button btnEyeRepeat;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnBack;
    }
}

