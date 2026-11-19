using System;
using System.Windows.Forms;
using kyrsovaya.Data;
using kyrsovaya.Models;
using kyrsovaya.Services;

namespace kyrsovaya.Forms
{
    /// <summary>
    /// Участки парка. Смотреть могут все, менять — только администратор.
    /// </summary>
    public partial class ZonesForm : Form
    {
        private readonly ZoneRepository _repo = new ZoneRepository();

        public ZonesForm()
        {
            InitializeComponent();
            Ui.Apply(this);

            bool isAdmin = Session.CurrentUser.IsAdmin;
            btnAdd.Visible = isAdmin;
            btnEdit.Visible = isAdmin;
            btnDelete.Visible = isAdmin;

            LoadData();
        }

        private void LoadData()
        {
            grid.DataSource = _repo.GetAll();
            grid.Columns["Id"].Visible = false;
            grid.Columns["Name"].HeaderText = "Название участка";
            grid.Columns["AreaHa"].HeaderText = "Площадь, га";
            grid.Columns["Description"].HeaderText = "Описание";
            grid.Columns["Description"].FillWeight = 200;
        }

        private int? SelectedId()
        {
            if (grid.CurrentRow == null) return null;
            return (int)grid.CurrentRow.Cells["Id"].Value;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new ZoneEditForm(null))
            {
                if (form.ShowDialog(this) == DialogResult.OK) LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int? id = SelectedId();
            if (id == null)
            {
                Ui.Info("Выберите участок в таблице.");
                return;
            }

            using (var form = new ZoneEditForm(id))
            {
                if (form.ShowDialog(this) == DialogResult.OK) LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int? id = SelectedId();
            if (id == null)
            {
                Ui.Info("Выберите участок в таблице.");
                return;
            }

            string name = (string)grid.CurrentRow.Cells["Name"].Value;
            if (!Ui.Confirm("Удалить участок «" + name + "»?")) return;

            try
            {
                _repo.Delete(id.Value);
                LoadData();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (Db.IsForeignKeyError(ex))
                    Ui.Error("Нельзя удалить участок, на котором есть записи в журнале наблюдений.");
                else
                    throw;
            }
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && Session.CurrentUser.IsAdmin) btnEdit_Click(sender, e);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
