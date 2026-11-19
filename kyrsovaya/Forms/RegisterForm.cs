using System;
using System.Windows.Forms;
using kyrsovaya.Data;
using kyrsovaya.Models;
using kyrsovaya.Services;

namespace kyrsovaya.Forms
{
    /// <summary>
    /// Форма регистрации нового пользователя (роль «Посетитель»).
    /// </summary>
    public partial class RegisterForm : Form
    {
        private readonly UserRepository _users = new UserRepository();

        /// <summary>Логин созданного пользователя, чтобы подставить его на форму входа.</summary>
        public string RegisteredLogin { get; private set; }

        public RegisterForm()
        {
            InitializeComponent();
            Ui.Apply(this);
            SetupHints();
        }

        /// <summary>Всплывающие подсказки при наведении на поля.</summary>
        private void SetupHints()
        {
            toolTip.SetToolTip(txtLastName, "Только буквы, от 2 до 50 символов");
            toolTip.SetToolTip(txtFirstName, "Только буквы, от 2 до 50 символов");
            toolTip.SetToolTip(txtLogin, "4–30 символов: латинские буквы, цифры, _ и точка");
            toolTip.SetToolTip(txtEmail, "Например: name@mail.ru");
            toolTip.SetToolTip(mtbPhone, "Формат: +7 (900) 123-45-67");
            toolTip.SetToolTip(txtPassword, "Не короче 12 символов, с буквами, цифрами и спецсимволами");
            toolTip.SetToolTip(txtRepeat, "Повторите пароль ещё раз");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!ValidateAll()) return;

            var user = new UserInfo
            {
                Login = txtLogin.Text.Trim(),
                PasswordHash = PasswordHelper.Hash(txtPassword.Text),
                LastName = txtLastName.Text.Trim(),
                FirstName = txtFirstName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = PhoneHelper.Normalize(mtbPhone.Text),
                RoleId = RoleIds.Visitor
            };

            _users.Add(user);
            RegisteredLogin = user.Login;

            Ui.Info("Регистрация прошла успешно! Теперь можно войти в систему.");
            DialogResult = DialogResult.OK;
        }

        /// <summary>Проверяет все поля. Ошибки отображаются у каждого поля значком с подсказкой.</summary>
        private bool ValidateAll()
        {
            bool hasError = false;

            hasError |= Ui.ShowFieldError(errorProvider, txtLastName, Validator.Name(txtLastName.Text, "Фамилия"));
            hasError |= Ui.ShowFieldError(errorProvider, txtFirstName, Validator.Name(txtFirstName.Text, "Имя"));

            string loginError = Validator.Login(txtLogin.Text);
            if (loginError == null && _users.LoginExists(txtLogin.Text.Trim()))
                loginError = "Пользователь с таким логином уже существует";
            hasError |= Ui.ShowFieldError(errorProvider, txtLogin, loginError);

            string emailError = Validator.Email(txtEmail.Text.Trim());
            if (emailError == null && _users.EmailExists(txtEmail.Text.Trim()))
                emailError = "Пользователь с таким email уже существует";
            hasError |= Ui.ShowFieldError(errorProvider, txtEmail, emailError);

            string phoneError = Validator.Phone(mtbPhone.Text);
            if (phoneError == null && _users.PhoneExists(PhoneHelper.Normalize(mtbPhone.Text)))
                phoneError = "Пользователь с таким телефоном уже существует";
            hasError |= Ui.ShowFieldError(errorProvider, mtbPhone, phoneError);

            hasError |= Ui.ShowFieldError(errorProvider, txtPassword, PasswordHelper.CheckStrength(txtPassword.Text));
            hasError |= Ui.ShowFieldError(errorProvider, txtRepeat,
                Validator.PasswordRepeat(txtPassword.Text, txtRepeat.Text));

            if (hasError)
            {
                Ui.Error("Исправьте ошибки в форме. Наведите курсор на красный значок рядом с полем, чтобы увидеть подсказку.");
            }
            return !hasError;
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
            txtRepeat.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        // Как только пользователь начинает исправлять поле, ошибка рядом с ним пропадает
        private void Field_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError((Control)sender, "");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
