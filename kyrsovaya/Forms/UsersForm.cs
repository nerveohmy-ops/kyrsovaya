using System;
using System.Data;
using System.Windows.Forms;
using kyrsovaya.Data;
using kyrsovaya.Models;
using kyrsovaya.Services;

namespace kyrsovaya.Forms
{
    /// <summary>
    /// Управление пользователями: администратор меняет любые роли и удаляет записи,
    /// научный сотрудник назначает пользователям роль «Гид».
    /// </summary>
    public partial class UsersForm : Form
    {
        private readonly UserRepository _repo = new UserRepository();
        private readonly bool _isAdmin = Session.CurrentUser.IsAdmin;

        public UsersForm()
        {
            InitializeComponent();
            Ui.Apply(this);

            if (!_isAdmin)
            {
                Text = "Назначение гидов";
                btnDelete.Visible = false;
            }

            cmbRole.DisplayMember = "Name";
            cmbRole.ValueMember = "Id";
            cmbRole.DataSource = _repo.GetRoles(!_isAdmin);

            LoadData();
        }

        private void LoadData()
        {
            grid.DataSource = _repo.GetAll();
            grid.Columns["Id"].Visible = false;
            grid.Columns["RoleId"].Visible = false;
            grid.Columns["Login"].HeaderText = "Логин";
            grid.Columns["FullName"].HeaderText = "Фамилия и имя";
            grid.Columns["Email"].HeaderText = "Email";
            grid.Columns["Phone"].HeaderText = "Телефон";
            grid.Columns["RoleName"].HeaderText = "Роль";
        }

        private void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && grid.Columns[e.ColumnIndex].Name == "Phone" && e.Value != null)
            {
                e.Value = PhoneHelper.Format(e.Value.ToString().Trim());
                e.FormattingApplied = true;
            }
        }

        // Выбирает в списке ролей роль выделенного пользователя
        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null) return;
            int roleId = (int)grid.CurrentRow.Cells["RoleId"].Value;
            if (!_isAdmin && (roleId == RoleIds.Admin || roleId == RoleIds.Scientist))
            {
                cmbRole.SelectedIndex = -1;
                return;
            }
            cmbRole.SelectedValue = roleId;
        }

        private void btnSetRole_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null) return;

            int userId = (int)grid.CurrentRow.Cells["Id"].Value;
            if (userId == Session.CurrentUser.Id)
            {
                Ui.Error("Нельзя менять роль самому себе.");
                return;
            }

            int currentRoleId = (int)grid.CurrentRow.Cells["RoleId"].Value;
            if (!_isAdmin && (currentRoleId == RoleIds.Admin || currentRoleId == RoleIds.Scientist))
            {
                Ui.Error("Научный сотрудник не может менять роль администратора или другого научного сотрудника.");
                return;
            }

            if (cmbRole.SelectedValue == null)
            {
                Ui.Info("Выберите роль из списка.");
                return;
            }

            _repo.UpdateRole(userId, (int)cmbRole.SelectedValue);
            LoadData();
            Ui.Info("Роль изменена. Пользователю нужно войти заново, чтобы изменения вступили в силу.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null) return;

            int userId = (int)grid.CurrentRow.Cells["Id"].Value;
            if (userId == Session.CurrentUser.Id)
            {
                Ui.Error("Нельзя удалить самого себя.");
                return;
            }

            string login = (string)grid.CurrentRow.Cells["Login"].Value;
            if (!Ui.Confirm("Удалить пользователя «" + login + "»?")) return;

            try
            {
                _repo.Delete(userId);
                LoadData();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (Db.IsForeignKeyError(ex))
                    Ui.Error("Нельзя удалить пользователя, который связан с наблюдениями или экскурсиями.");
                else
                    throw;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
