using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace kyrsovaya.Services
{
    /// <summary>
    /// Единое оформление форм и короткие методы для сообщений.
    /// Чтобы не настраивать цвета у каждой кнопки вручную, форма вызывает Ui.Apply(this).
    /// </summary>
    public static class Ui
    {
        public const string AppTitle = "GRINPICH NATION — учёт редких видов";

        public static readonly Color Green = Color.FromArgb(46, 110, 66);
        public static readonly Color DarkGreen = Color.FromArgb(28, 70, 42);
        public static readonly Color LightBack = Color.FromArgb(242, 247, 243);
        public static readonly Color Red = Color.FromArgb(176, 58, 46);

        private static readonly Image EyeOpenIcon = CreateEyeIcon(false);
        private static readonly Image EyeClosedIcon = CreateEyeIcon(true);

        /// <summary>Применяет шрифт, цвет фона и стиль кнопок / таблиц ко всей форме.</summary>
        public static void Apply(Form form)
        {
            form.Font = new Font("Segoe UI", 10F);
            form.BackColor = LightBack;
            form.StartPosition = FormStartPosition.CenterScreen;
            StyleChildren(form);
        }

        private static void StyleChildren(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                var button = control as Button;
                if (button != null) StyleButton(button);

                var grid = control as DataGridView;
                if (grid != null) StyleGrid(grid);

                StyleChildren(control);
            }
        }

        private static void StyleButton(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.ForeColor = Color.White;
            button.Cursor = Cursors.Hand;

            // Tag задаёт вид кнопки: "danger" — красная, "menu" — пункт меню, "eye" — глазик у пароля
            switch (button.Tag as string)
            {
                case "danger":
                    button.BackColor = Red;
                    break;
                case "menu":
                    button.BackColor = DarkGreen;
                    button.TextAlign = ContentAlignment.MiddleLeft;
                    button.Padding = new Padding(15, 0, 0, 0);
                    button.FlatAppearance.MouseOverBackColor = Green;
                    break;
                case "eye":
                    button.BackColor = Color.White;
                    button.ForeColor = DarkGreen;
                    button.FlatAppearance.BorderSize = 1;
                    button.FlatAppearance.BorderColor = Color.Silver;
                    button.FlatAppearance.MouseOverBackColor = LightBack;
                    break;
                default:
                    button.BackColor = Green;
                    break;
            }
        }

        /// <summary>
        /// Привязывает кнопку-глазик к конкретному полю ввода пароля.
        /// </summary>
        public static void SetupPasswordEye(Button eyeButton, TextBox passwordBox, ToolTip tip = null)
        {
            eyeButton.Tag = "eye";
            eyeButton.Text = "";
            eyeButton.TabStop = false;
            eyeButton.ImageAlign = ContentAlignment.MiddleCenter;
            StyleButton(eyeButton);

            void UpdateView()
            {
                bool hidden = passwordBox.UseSystemPasswordChar;
                eyeButton.Image = hidden ? EyeOpenIcon : EyeClosedIcon;
                if (tip != null) tip.SetToolTip(eyeButton, hidden ? "Показать пароль" : "Скрыть пароль");
            }

            UpdateView();
            eyeButton.Click += (s, e) =>
            {
                passwordBox.UseSystemPasswordChar = !passwordBox.UseSystemPasswordChar;
                UpdateView();
                passwordBox.Focus();
            };
        }

        private static Image CreateEyeIcon(bool crossed)
        {
            var bmp = new Bitmap(20, 16);
            using (var g = Graphics.FromImage(bmp))
            using (var pen = new Pen(DarkGreen, 1.6f))
            using (var brush = new SolidBrush(DarkGreen))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.DrawBezier(pen, 2, 8, 6, 2, 14, 2, 18, 8);
                g.DrawBezier(pen, 2, 8, 6, 14, 14, 14, 18, 8);
                g.FillEllipse(brush, 7.5f, 5.5f, 5f, 5f);
                if (crossed)
                {
                    g.DrawLine(pen, 3, 14, 17, 2);
                }
            }
            return bmp;
        }

        private static void StyleGrid(DataGridView grid)
        {
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.RowHeadersVisible = false;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Green;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.ColumnHeadersHeight = 34;
            grid.RowTemplate.Height = 28;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 215, 190);
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 250, 247);
        }

        // ---------- Сообщения ----------

        public static void Info(string text)
        {
            MessageBox.Show(text, AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Error(string text)
        {
            MessageBox.Show(text, AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool Confirm(string text)
        {
            return MessageBox.Show(text, AppTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                   == DialogResult.Yes;
        }

        /// <summary>
        /// Показывает ошибку рядом с полем (красный значок с подсказкой).
        /// Если текст пустой, ошибка убирается. Возвращает true, если ошибка есть.
        /// </summary>
        public static bool ShowFieldError(ErrorProvider provider, Control field, string message)
        {
            provider.SetError(field, message ?? "");
            return message != null;
        }
    }
}
