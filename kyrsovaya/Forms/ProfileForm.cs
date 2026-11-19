using System;
using System.Windows.Forms;
using kyrsovaya.Data;
using kyrsovaya.Models;
using kyrsovaya.Services;

namespace kyrsovaya.Forms
{
    /// <summary>
    /// Личный кабинет: просмотр и изменение своих данных и пароля.
    /// </summary>
    public partial class ProfileForm : Form
    {
        private readonly UserRepository _users = new UserRepository();
        private readonly UserInfo _user = Session.CurrentUser;

        public ProfileForm()
        {
            InitializeComponent();
            Ui.Apply(this);
            FillFields();
        }

        private void FillFields()
        {
            txtLogin.Text = _user.Login;
            txtRole.Text = _user.RoleName;
            txtLastName.Text = _user.LastName;
            txtFirstName.Text = _user.FirstName;
            txtEmail.Text = _user.Email;
            mtbPhone.Text = _user.Phone;
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            bool hasError = false;
            hasError |= Ui.ShowFieldError(errorProvider, txtLastName, Validator.Name(txtLastName.Text, "Фамилия"));
            hasError |= Ui.ShowFieldError(errorProvider, txtFirstName, Validator.Name(txtFirstName.Text, "Имя"));

            string email = txtEmail.Text.Trim();
            string emailError = Validator.Email(email);
            if (emailError == null && _users.EmailExists(email, _user.Id))
                emailError = "Этот email уже занят другим пользователем";
            hasError |= Ui.ShowFieldError(errorProvider, txtEmail, emailError);

            string phone = PhoneHelper.Normalize(mtbPhone.Text);
            string phoneError = Validator.Phone(mtbPhone.Text);
            if (phoneError == null && _users.PhoneExists(phone, _user.Id))
                phoneError = "Этот телефон уже занят другим пользователем";
            hasError |= Ui.ShowFieldError(errorProvider, mtbPhone, phoneError);

            if (hasError) return;

            _user.LastName = txtLastName.Text.Trim();
            _user.FirstName = txtFirstName.Text.Trim();
            _user.Email = email;
            _user.Phone = phone;
            _users.UpdateProfile(_user);

            Ui.Info("Данные сохранены.");
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            bool hasError = false;

            string oldError = PasswordHelper.Verify(txtOldPassword.Text, _user.PasswordHash)
                ? null : "Текущий пароль введён неверно";
            hasError |= Ui.ShowFieldError(errorProvider, txtOldPassword, oldError);
            hasError |= Ui.ShowFieldError(errorProvider, txtNewPassword,
                PasswordHelper.CheckStrength(txtNewPassword.Text));
            hasError |= Ui.ShowFieldError(errorProvider, txtRepeat,
                Validator.PasswordRepeat(txtNewPassword.Text, txtRepeat.Text));

            if (hasError) return;

            _user.PasswordHash = PasswordHelper.Hash(txtNewPassword.Text);
            _users.UpdatePassword(_user.Id, _user.PasswordHash);

            txtOldPassword.Clear();
            txtNewPassword.Clear();
            txtRepeat.Clear();
            Ui.Info("Пароль изменён.");
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool hide = !chkShowPassword.Checked;
            txtOldPassword.UseSystemPasswordChar = hide;
            txtNewPassword.UseSystemPasswordChar = hide;
            txtRepeat.UseSystemPasswordChar = hide;
        }

        private void Field_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError((Control)sender, "");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
