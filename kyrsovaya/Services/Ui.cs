using System.Drawing;
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

            // Tag задаёт вид кнопки: "danger" — красная, "menu" — пункт бокового меню
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
                default:
                    button.BackColor = Green;
                    break;
            }
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
