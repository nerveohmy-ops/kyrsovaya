using System.IO;
using System.Text;
using System.Windows.Forms;

namespace kyrsovaya.Services
{
    /// <summary>
    /// Выгрузка таблицы с формы в CSV-файл (открывается в Excel).
    /// </summary>
    public static class CsvExporter
    {
        public static void Export(DataGridView grid, string defaultName)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "CSV файлы (*.csv)|*.csv";
                dialog.FileName = defaultName + ".csv";
                if (dialog.ShowDialog() != DialogResult.OK) return;

                var text = new StringBuilder();

                // Заголовки видимых столбцов
                foreach (DataGridViewColumn column in grid.Columns)
                {
                    if (column.Visible) text.Append(Escape(column.HeaderText)).Append(';');
                }
                text.AppendLine();

                // Строки
                foreach (DataGridViewRow row in grid.Rows)
                {
                    foreach (DataGridViewColumn column in grid.Columns)
                    {
                        if (!column.Visible) continue;
                        object value = row.Cells[column.Index].FormattedValue;
                        text.Append(Escape(value == null ? "" : value.ToString())).Append(';');
                    }
                    text.AppendLine();
                }

                // UTF-8 с BOM, иначе Excel покажет кракозябры вместо русских букв
                File.WriteAllText(dialog.FileName, text.ToString(), new UTF8Encoding(true));
                Ui.Info("Файл сохранён:\n" + dialog.FileName);
            }
        }

        private static string Escape(string value)
        {
            return "\"" + value.Replace("\"", "\"\"") + "\"";
        }
    }
}
