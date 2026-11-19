using System;
using System.Windows.Forms;
using kyrsovaya.Data;
using kyrsovaya.Forms;
using kyrsovaya.Models;
using kyrsovaya.Services;

namespace kyrsovaya
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Db.EnsureCreated();
            }
            catch (Exception ex)
            {
                Ui.Error("Не удалось подключиться к базе данных.\n" +
                         "Проверьте строку подключения в App.config и что установлен SQL Server LocalDB.\n\n" +
                         ex.Message);
                return;
            }

            // Цикл «вход -> главное меню». Если пользователь нажал «Сменить пользователя»,
            // то снова показывается форма входа, иначе программа закрывается.
            while (true)
            {
                using (var login = new LoginForm())
                {
                    if (login.ShowDialog() != DialogResult.OK) break;
                }

                using (var main = new MainForm())
                {
                    if (main.ShowDialog() != DialogResult.Retry) break;
                }

                Session.CurrentUser = null;
            }
        }
    }
}
