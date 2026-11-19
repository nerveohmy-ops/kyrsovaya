using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using kyrsovaya.Data;
using kyrsovaya.Models;
using kyrsovaya.Services;

namespace kyrsovaya.Forms
{
    /// <summary>
    /// Список редких видов: поиск, фильтры, добавление, изменение, удаление, экспорт.
    /// </summary>
    public partial class SpeciesForm : Form
    {
        private const string AllItems = "Все";
        private readonly SpeciesRepository _repo = new SpeciesRepository();
        private bool _filtersReady;

        public SpeciesForm()
        {
            InitializeComponent();
            Ui.Apply(this);
            SetupPermissions();
            LoadFilters();
            LoadData();
        }

        // Посетитель может только смотреть
        private void SetupPermissions()
        {
            bool canEdit = Session.CurrentUser.CanEditData;
            btnAdd.Visible = canEdit;
            btnEdit.Visible = canEdit;
            btnDelete.Visible = canEdit;
        }

        private void LoadFilters()
        {
            cmbKind.Items.AddRange(new object[] { AllItems, "Животное", "Растение", "Гриб" });
            cmbKind.SelectedIndex = 0;

            DataTable statuses = _repo.GetStatuses();
            DataRow all = statuses.NewRow();
            all["Id"] = 0;
            all["Name"] = AllItems;
            statuses.Rows.InsertAt(all, 0);

            cmbStatus.DisplayMember = "Name";
            cmbStatus.ValueMember = "Id";
            cmbStatus.DataSource = statuses;

            _filtersReady = true;
        }

        private void LoadData()
        {
            string kind = cmbKind.Text == AllItems ? "" : cmbKind.Text;
            int statusId = cmbStatus.SelectedValue == null ? 0 : (int)cmbStatus.SelectedValue;

            grid.DataSource = _repo.GetAll(txtSearch.Text.Trim(), kind, statusId);
            SetupColumns();
            labelCount.Text = "Найдено: " + grid.Rows.Count;
        }

        private void SetupColumns()
        {
            grid.Columns["Id"].Visible = false;
            grid.Columns["StatusCode"].Visible = false;
            grid.Columns["Name"].HeaderText = "Название";
            grid.Columns["LatinName"].HeaderText = "Латинское название";
            grid.Columns["Kind"].HeaderText = "Тип";
            grid.Columns["Status"].HeaderText = "Статус охраны";
            grid.Columns["Population"].HeaderText = "Численность";
            grid.Columns["Description"].HeaderText = "Описание";
            grid.Columns["Description"].FillWeight = 200;
        }

        // Подсвечиваем статус охраны цветом
        private void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || grid.Columns[e.ColumnIndex].Name != "Status") return;

            string code = Convert.ToString(grid.Rows[e.RowIndex].Cells["StatusCode"].Value);
            if (code == "CR") e.CellStyle.BackColor = Color.FromArgb(245, 183, 177);
            else if (code == "EN") e.CellStyle.BackColor = Color.FromArgb(250, 215, 160);
            else if (code == "VU") e.CellStyle.BackColor = Color.FromArgb(252, 243, 160);
        }

        private int? SelectedId()
        {
            if (grid.CurrentRow == null) return null;
            return (int)grid.CurrentRow.Cells["Id"].Value;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new SpeciesEditForm(null))
            {
                if (form.ShowDialog(this) == DialogResult.OK) LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int? id = SelectedId();
            if (id == null)
            {
                Ui.Info("Выберите вид в таблице.");
                return;
            }

            using (var form = new SpeciesEditForm(id))
            {
                if (form.ShowDialog(this) == DialogResult.OK) LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int? id = SelectedId();
            if (id == null)
            {
                Ui.Info("Выберите вид в таблице.");
                return;
            }

            string name = (string)grid.CurrentRow.Cells["Name"].Value;
            if (!Ui.Confirm("Удалить вид «" + name + "»?")) return;

            try
            {
                _repo.Delete(id.Value);
                LoadData();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (Db.IsForeignKeyError(ex))
                    Ui.Error("Нельзя удалить вид, по которому есть записи в журнале наблюдений.\nСначала удалите эти наблюдения.");
                else
                    throw;
            }
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && Session.CurrentUser.CanEditData) btnEdit_Click(sender, e);
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            if (_filtersReady) LoadData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbKind.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            CsvExporter.Export(grid, "Редкие_виды");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
