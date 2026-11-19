namespace kyrsovaya.Forms
{
    partial class ProfileForm
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
            this.groupData = new System.Windows.Forms.GroupBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.labelRole = new System.Windows.Forms.Label();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.labelLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.mtbPhone = new System.Windows.Forms.MaskedTextBox();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.groupPassword = new System.Windows.Forms.GroupBox();
            this.labelOld = new System.Windows.Forms.Label();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.labelNew = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.labelRepeat = new System.Windows.Forms.Label();
            this.txtRepeat = new System.Windows.Forms.TextBox();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupData.SuspendLayout();
            this.groupPassword.SuspendLayout();
            this.SuspendLayout();
            //
            // errorProvider
            //
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            //
            // groupData
            //
            this.groupData.Controls.Add(this.labelLogin);
            this.groupData.Controls.Add(this.txtLogin);
            this.groupData.Controls.Add(this.labelRole);
            this.groupData.Controls.Add(this.txtRole);
            this.groupData.Controls.Add(this.labelLastName);
            this.groupData.Controls.Add(this.txtLastName);
            this.groupData.Controls.Add(this.labelFirstName);
            this.groupData.Controls.Add(this.txtFirstName);
            this.groupData.Controls.Add(this.labelEmail);
            this.groupData.Controls.Add(this.txtEmail);
            this.groupData.Controls.Add(this.labelPhone);
            this.groupData.Controls.Add(this.mtbPhone);
            this.groupData.Controls.Add(this.btnSaveData);
            this.groupData.Location = new System.Drawing.Point(15, 15);
            this.groupData.Name = "groupData";
            this.groupData.Size = new System.Drawing.Size(430, 380);
            this.groupData.TabStop = false;
            this.groupData.Text = "Мои данные";
            //
            // login (только чтение)
            //
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(15, 38);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Text = "Логин";
            this.txtLogin.Location = new System.Drawing.Point(150, 35);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.ReadOnly = true;
            this.txtLogin.Size = new System.Drawing.Size(260, 25);
            this.txtLogin.TabStop = false;
            //
            // role (только чтение)
            //
            this.labelRole.AutoSize = true;
            this.labelRole.Location = new System.Drawing.Point(15, 78);
            this.labelRole.Name = "labelRole";
            this.labelRole.Text = "Роль";
            this.txtRole.Location = new System.Drawing.Point(150, 75);
            this.txtRole.Name = "txtRole";
            this.txtRole.ReadOnly = true;
            this.txtRole.Size = new System.Drawing.Size(260, 25);
            this.txtRole.TabStop = false;
            //
            // last name
            //
            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(15, 118);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Text = "Фамилия";
            this.txtLastName.Location = new System.Drawing.Point(150, 115);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(260, 25);
            this.txtLastName.TabIndex = 0;
            this.txtLastName.TextChanged += new System.EventHandler(this.Field_TextChanged);
            //
            // first name
            //
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(15, 158);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Text = "Имя";
            this.txtFirstName.Location = new System.Drawing.Point(150, 155);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(260, 25);
            this.txtFirstName.TabIndex = 1;
            this.txtFirstName.TextChanged += new System.EventHandler(this.Field_TextChanged);
            //
            // email
            //
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(15, 198);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Text = "Email";
            this.txtEmail.Location = new System.Drawing.Point(150, 195);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(260, 25);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.TextChanged += new System.EventHandler(this.Field_TextChanged);
            //
            // phone
            //
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(15, 238);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Text = "Телефон";
            this.mtbPhone.Location = new System.Drawing.Point(150, 235);
            this.mtbPhone.Mask = "+7 (000) 000-00-00";
            this.mtbPhone.Name = "mtbPhone";
            this.mtbPhone.Size = new System.Drawing.Size(260, 25);
            this.mtbPhone.TabIndex = 3;
            this.mtbPhone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtbPhone.TextChanged += new System.EventHandler(this.Field_TextChanged);
            //
            // btnSaveData
            //
            this.btnSaveData.Location = new System.Drawing.Point(150, 285);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(260, 38);
            this.btnSaveData.TabIndex = 4;
            this.btnSaveData.Text = "Сохранить данные";
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            //
            // groupPassword
            //
            this.groupPassword.Controls.Add(this.labelOld);
            this.groupPassword.Controls.Add(this.txtOldPassword);
            this.groupPassword.Controls.Add(this.labelNew);
            this.groupPassword.Controls.Add(this.txtNewPassword);
            this.groupPassword.Controls.Add(this.labelRepeat);
            this.groupPassword.Controls.Add(this.txtRepeat);
            this.groupPassword.Controls.Add(this.chkShowPassword);
            this.groupPassword.Controls.Add(this.btnChangePassword);
            this.groupPassword.Location = new System.Drawing.Point(460, 15);
            this.groupPassword.Name = "groupPassword";
            this.groupPassword.Size = new System.Drawing.Size(430, 380);
            this.groupPassword.TabStop = false;
            this.groupPassword.Text = "Смена пароля";
            //
            // old password
            //
            this.labelOld.AutoSize = true;
            this.labelOld.Location = new System.Drawing.Point(15, 38);
            this.labelOld.Name = "labelOld";
            this.labelOld.Text = "Текущий пароль";
            this.txtOldPassword.Location = new System.Drawing.Point(160, 35);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Size = new System.Drawing.Size(250, 25);
            this.txtOldPassword.TabIndex = 5;
            this.txtOldPassword.UseSystemPasswordChar = true;
            this.txtOldPassword.TextChanged += new System.EventHandler(this.Field_TextChanged);
            //
            // new password
            //
            this.labelNew.AutoSize = true;
            this.labelNew.Location = new System.Drawing.Point(15, 78);
            this.labelNew.Name = "labelNew";
            this.labelNew.Text = "Новый пароль";
            this.txtNewPassword.Location = new System.Drawing.Point(160, 75);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(250, 25);
            this.txtNewPassword.TabIndex = 6;
            this.txtNewPassword.UseSystemPasswordChar = true;
            this.txtNewPassword.TextChanged += new System.EventHandler(this.Field_TextChanged);
            //
            // repeat
            //
            this.labelRepeat.AutoSize = true;
            this.labelRepeat.Location = new System.Drawing.Point(15, 118);
            this.labelRepeat.Name = "labelRepeat";
            this.labelRepeat.Text = "Повторите пароль";
            this.txtRepeat.Location = new System.Drawing.Point(160, 115);
            this.txtRepeat.Name = "txtRepeat";
            this.txtRepeat.Size = new System.Drawing.Size(250, 25);
            this.txtRepeat.TabIndex = 7;
            this.txtRepeat.UseSystemPasswordChar = true;
            this.txtRepeat.TextChanged += new System.EventHandler(this.Field_TextChanged);
            //
            // show password
            //
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.Location = new System.Drawing.Point(160, 150);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.TabIndex = 8;
            this.chkShowPassword.Text = "Показать пароль";
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            //
            // btnChangePassword
            //
            this.btnChangePassword.Location = new System.Drawing.Point(160, 195);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(250, 38);
            this.btnChangePassword.TabIndex = 9;
            this.btnChangePassword.Text = "Сменить пароль";
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            //
            // btnBack
            //
            this.btnBack.Location = new System.Drawing.Point(15, 410);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(130, 38);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Назад";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            //
            // ProfileForm
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(905, 465);
            this.Controls.Add(this.groupData);
            this.Controls.Add(this.groupPassword);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProfileForm";
            this.Text = "Личный кабинет";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupData.ResumeLayout(false);
            this.groupData.PerformLayout();
            this.groupPassword.ResumeLayout(false);
            this.groupPassword.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox groupData;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.MaskedTextBox mtbPhone;
        private System.Windows.Forms.Button btnSaveData;
        private System.Windows.Forms.GroupBox groupPassword;
        private System.Windows.Forms.Label labelOld;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.Label labelNew;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label labelRepeat;
        private System.Windows.Forms.TextBox txtRepeat;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnBack;
    }
}

