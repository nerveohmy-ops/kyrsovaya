using System;
using System.Windows.Forms;
using kyrsovaya.Data;
using kyrsovaya.Models;
using kyrsovaya.Services;

namespace kyrsovaya.Forms
{
    /// <summary>
    /// Восстановление пароля: пользователю на email приходит новый пароль.
    /// </summary>
    public partial class ForgotPasswordForm : Form
    {
        private readonly UserRepository _users = new UserRepository();

        public ForgotPasswordForm()
        {
            InitializeComponent();
            Ui.Apply(this);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string identifier = txtIdentifier.Text.Trim();
            if (identifier == "")
            {
                Ui.ShowFieldError(errorProvider, txtIdentifier, "Введите логин, email или телефон");
                return;
            }

            UserInfo user = _users.FindByIdentifier(identifier);
            if (user == null)
            {
                Ui.ShowFieldError(errorProvider, txtIdentifier, "Пользователь не найден");
                return;
            }

            string newPassword = PasswordHelper.Generate();

            try
            {
                string body = "Здравствуйте, " + user.FirstName + "!\r\n\r\n" +
                              "Ваш новый пароль: " + newPassword + "\r\n" +
                              "После входа рекомендуем сменить его в личном кабинете.";
                string result = EmailService.Send(user.Email, "Восстановление пароля", body);

                // Пароль меняем только после того, как письмо отправлено
                _users.UpdatePassword(user.Id, PasswordHelper.Hash(newPassword));
                Ui.Info("Новый пароль создан.\n" + result);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Ui.Error("Не удалось отправить письмо: " + ex.Message);
            }
        }

        private void txtIdentifier_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtIdentifier, "");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
