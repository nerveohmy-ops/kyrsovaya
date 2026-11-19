using System;
using System.Windows.Forms;
using kyrsovaya.Data;
using kyrsovaya.Services;

namespace kyrsovaya.Forms
{
    /// <summary>
    /// Список посетителей, записавшихся на выбранную экскурсию.
    /// </summary>
    public partial class ExcursionParticipantsForm : Form
    {
        private readonly ExcursionRepository _repo = new ExcursionRepository();
        private readonly int _excursionId;
        private readonly int _maxParticipants;

        public ExcursionParticipantsForm(int excursionId, string title, int maxParticipants)
        {
            InitializeComponent();
            Ui.Apply(this);
            _excursionId = excursionId;
            _maxParticipants = maxParticipants;

            labelHeader.Text = "Экскурсия: " + title;
            LoadData();
        }

        private void LoadData()
        {
            grid.DataSource = _repo.GetParticipants(_excursionId);
            grid.Columns["Id"].Visible = false;
            grid.Columns["Login"].HeaderText = "Логин";
            grid.Columns["FullName"].HeaderText = "Фамилия и имя";
            grid.Columns["Phone"].HeaderText = "Телефон";
            grid.Columns["Email"].HeaderText = "Email";
            grid.Columns["BookedAt"].HeaderText = "Дата записи";
            grid.Columns["BookedAt"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";

            labelCount.Text = "Записано: " + grid.Rows.Count + " из " + _maxParticipants;
        }

        private void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && grid.Columns[e.ColumnIndex].Name == "Phone" && e.Value != null)
            {
                e.Value = PhoneHelper.Format(e.Value.ToString().Trim());
                e.FormattingApplied = true;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null)
            {
                Ui.Info("Выберите участника в таблице.");
                return;
            }

            string name = (string)grid.CurrentRow.Cells["FullName"].Value;
            if (!Ui.Confirm("Снять участника «" + name + "» с экскурсии?")) return;

            int bookingId = (int)grid.CurrentRow.Cells["Id"].Value;
            _repo.RemoveBooking(bookingId);
            LoadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            CsvExporter.Export(grid, "Участники_экскурсии");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
