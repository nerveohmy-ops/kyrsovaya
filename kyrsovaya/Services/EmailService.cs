using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace kyrsovaya.Services
{
    /// <summary>
    /// Отправка писем. Если в App.config не задан SMTP-сервер,
    /// письмо сохраняется в текстовый файл в папке Outbox.
    /// </summary>
    public static class EmailService
    {
        /// <summary>Возвращает описание того, куда ушло письмо (для показа пользователю).</summary>
        public static string Send(string to, string subject, string body)
        {
            string host = ConfigurationManager.AppSettings["SmtpHost"];

            if (string.IsNullOrWhiteSpace(host))
            {
                return SaveToFile(to, subject, body);
            }

            string user = ConfigurationManager.AppSettings["SmtpUser"];
            using (var client = new SmtpClient(host, int.Parse(ConfigurationManager.AppSettings["SmtpPort"])))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(user, ConfigurationManager.AppSettings["SmtpPassword"]);
                client.Send(new MailMessage(user, to, subject, body));
            }
            return "Письмо отправлено на " + to;
        }

        private static string SaveToFile(string to, string subject, string body)
        {
            string folder = Path.Combine(Application.StartupPath, "Outbox");
            Directory.CreateDirectory(folder);

            string fileName = "mail_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            string path = Path.Combine(folder, fileName);
            File.WriteAllText(path, "Кому: " + to + "\r\nТема: " + subject + "\r\n\r\n" + body);

            return "SMTP-сервер не настроен, поэтому письмо сохранено в файл:\n" + path;
        }
    }
}
