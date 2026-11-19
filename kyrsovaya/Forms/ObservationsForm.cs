using System;
using System.Data;
using System.Windows.Forms;
using kyrsovaya.Data;
using kyrsovaya.Services;

namespace kyrsovaya.Forms
{
    /// <summary>
    /// Журнал наблюдений (доступен администратору и научным сотрудникам).
    /// </summary>
    public partial class ObservationsForm : Form
    {
        private readonly ObservationRepository _repo = new ObservationRepository();
        private readonly ZoneRepository _zones = new ZoneRepository();
        private bool _filtersReady;

        public ObservationsForm()
        {
            InitializeComponent();
            Ui.Apply(this);
            LoadFilters();
            LoadData();
        }

        private void LoadFilters()
        {
            DataTable zones = _zones.GetAll();
            DataRow all = zones.NewRow();
            all["Id"] = 0;
            all["Name"] = "Все участки";
            zones.Rows.InsertAt(all, 0);

            cmbZone.DisplayMember = "Name";
            cmbZone.ValueMember = "Id";
            cmbZone.DataSource = zones;
            _filtersReady = true;
        }

        private void LoadData()
        {
            int zoneId = cmbZone.SelectedValue == null ? 0 : (int)cmbZone.SelectedValue;
            grid.DataSource = _repo.GetAll(txtSearch.Text.Trim(), zoneId);

            grid.Columns["Id"].Visible = false;
            grid.Columns["ObservationDate"].HeaderText = "Дата";
            grid.Columns["ObservationDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            grid.Columns["SpeciesName"].HeaderText = "Вид";
            grid.Columns["ZoneName"].HeaderText = "Участок";
            grid.Columns["Quantity"].HeaderText = "Кол-во";
            grid.Columns["Author"].HeaderText = "Наблюдатель";
            grid.Columns["Notes"].HeaderText = "Примечание";
            grid.Columns["Notes"].FillWeight = 200;
            labelCount.Text = "Найдено: " + grid.Rows.Count;
        }

        private int? SelectedId()
        {
            if (grid.CurrentRow == null) return null;
            return (int)grid.CurrentRow.Cells["Id"].Value;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new ObservationEditForm(null))
            {
                if (form.ShowDialog(this) == DialogResult.OK) LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int? id = SelectedId();
            if (id == null)
            {
                Ui.Info("Выберите запись в таблице.");
                return;
            }

            using (var form = new ObservationEditForm(id))
            {
                if (form.ShowDialog(this) == DialogResult.OK) LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int? id = SelectedId();
            if (id == null)
            {
                Ui.Info("Выберите запись в таблице.");
                return;
            }

            if (!Ui.Confirm("Удалить выбранное наблюдение?")) return;

            _repo.Delete(id.Value);
            LoadData();
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) btnEdit_Click(sender, e);
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            if (_filtersReady) LoadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            CsvExporter.Export(grid, "Журнал_наблюдений");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
