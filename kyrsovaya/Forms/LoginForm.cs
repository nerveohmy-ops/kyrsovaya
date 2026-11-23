using System;
using System.Windows.Forms;
using kyrsovaya.Data;
using kyrsovaya.Models;
using kyrsovaya.Services;

namespace kyrsovaya.Forms
{
    /// <summary>
    /// Форма авторизации: вход по логину, email или телефону.
    /// </summary>
    public partial class LoginForm : Form
    {
        private readonly UserRepository _users = new UserRepository();

        public LoginForm()
        {
            InitializeComponent();
            Ui.Apply(this);
            Ui.SetupPasswordEye(btnEyePassword, txtPassword, toolTip);
            panelCard.BackColor = System.Drawing.Color.White;
            labelTitle.ForeColor = Ui.DarkGreen;
            LoadBackground();
        }

        private void LoadBackground()
        {
            string path = System.IO.Path.Combine(Application.StartupPath, "Images", "Fon_menu.jpg");
            if (System.IO.File.Exists(path))
            {
                BackgroundImage = System.Drawing.Image.FromFile(path);
                BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string identifier = txtLogin.Text.Trim();
            string password = txtPassword.Text;

            bool hasError = Ui.ShowFieldError(errorProvider, txtLogin,
                identifier == "" ? "Введите логин, email или телефон" : null);
            hasError |= Ui.ShowFieldError(errorProvider, txtPassword,
                password == "" ? "Введите пароль" : null);
            if (hasError) return;

            UserInfo user = _users.FindByIdentifier(identifier);

            if (user == null)
            {
                // Такого пользователя нет — предлагаем зарегистрироваться
                if (Ui.Confirm("Пользователь не найден. Перейти к регистрации?"))
                {
                    OpenRegister();
                }
                return;
            }

            if (!PasswordHelper.Verify(password, user.PasswordHash))
            {
                Ui.ShowFieldError(errorProvider, txtPassword, "Неверный пароль");
                return;
            }

            Session.CurrentUser = user;
            DialogResult = DialogResult.OK;
        }

        private void OpenRegister()
        {
            using (var form = new RegisterForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    txtLogin.Text = form.RegisteredLogin;
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenRegister();
        }

        private void linkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var form = new ForgotPasswordForm())
            {
                form.ShowDialog(this);
            }
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtLogin, "");
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtPassword, "");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
