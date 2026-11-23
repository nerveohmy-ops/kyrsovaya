using System;
using System.Drawing;
using System.Windows.Forms;
using kyrsovaya.Data;
using kyrsovaya.Models;
using kyrsovaya.Services;

namespace kyrsovaya.Forms
{
    /// <summary>
    /// Список экскурсий национального парка.
    /// Посетители записываются на открытые экскурсии, научные сотрудники управляют ими (в т.ч. открывают и закрывают).
    /// </summary>
    public partial class ExcursionsForm : Form
    {
        private readonly ExcursionRepository _repo = new ExcursionRepository();
        private readonly bool _canManage = Session.CurrentUser.CanEditData;
        private readonly bool _isGuide = Session.CurrentUser.IsGuide;
        private bool _filtersReady;

        public ExcursionsForm()
        {
            InitializeComponent();
            Ui.Apply(this);
            SetupPermissions();
            LoadFilters();
            LoadData();
        }

        private void SetupPermissions()
        {
            // Присоединиться к экскурсии могут все, кроме гида (гида назначает научный сотрудник)
            btnBook.Visible = !_isGuide;
            btnCancelBooking.Visible = !_isGuide;

            // Кнопки управления для научного сотрудника / администратора
            btnAdd.Visible = _canManage;
            btnEdit.Visible = _canManage;
            btnOpen.Visible = _canManage;
            btnClose.Visible = _canManage;
            btnAssignGuide.Visible = _canManage;
            btnDelete.Visible = _canManage;
            btnExport.Visible = _canManage;

            // Гид смотрит назначенные ему экскурсии и список участников
            btnParticipants.Visible = _canManage || _isGuide;
            if (_isGuide)
            {
                Text = "Мои экскурсии (назначенные гиду)";
                btnParticipants.Location = new Point(15, 12);
            }

            panelBottom.Height = _canManage ? 104 : 60;
        }

        private void LoadFilters()
        {
            cmbFilter.Items.Add("Все");
            cmbFilter.Items.Add("Открытые");
            cmbFilter.Items.Add("Закрытые");
            if (!_isGuide)
            {
                cmbFilter.Items.Add("Мои записи");
            }
            cmbFilter.SelectedIndex = 0;
            _filtersReady = true;
        }

        private void LoadData()
        {
            int filterMode = cmbFilter.SelectedIndex < 0 ? 0 : cmbFilter.SelectedIndex;
            grid.DataSource = _repo.GetAll(txtSearch.Text.Trim(), filterMode, Session.CurrentUser.Id, _isGuide);
            SetupColumns();
            labelCount.Text = "Найдено: " + grid.Rows.Count;
        }

        private void SetupColumns()
        {
            grid.Columns["Id"].Visible = false;
            grid.Columns["GuideId"].Visible = false;
            grid.Columns["IsOpen"].Visible = false;
            grid.Columns["IsBooked"].Visible = false;

            grid.Columns["Title"].HeaderText = "Экскурсия";
            grid.Columns["Title"].FillWeight = 130;
            grid.Columns["ZoneName"].HeaderText = "Участок";
            grid.Columns["ExcursionDate"].HeaderText = "Дата и время";
            grid.Columns["ExcursionDate"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            grid.Columns["GuideName"].HeaderText = "Гид";
            grid.Columns["BookedCount"].HeaderText = "Записано";
            grid.Columns["BookedCount"].FillWeight = 55;
            grid.Columns["MaxParticipants"].HeaderText = "Мест";
            grid.Columns["MaxParticipants"].FillWeight = 50;
            grid.Columns["StatusText"].HeaderText = "Статус";
            grid.Columns["StatusText"].FillWeight = 65;

            grid.Columns["MyBooking"].HeaderText = "Моя запись";
            grid.Columns["MyBooking"].Visible = !_isGuide;
            grid.Columns["MyBooking"].FillWeight = 80;

            grid.Columns["Description"].HeaderText = "Описание";
            grid.Columns["Description"].FillWeight = 180;
        }

        private void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string column = grid.Columns[e.ColumnIndex].Name;
            if (column == "StatusText")
            {
                bool isOpen = Convert.ToBoolean(grid.Rows[e.RowIndex].Cells["IsOpen"].Value);
                e.CellStyle.BackColor = isOpen
                    ? Color.FromArgb(212, 239, 223)
                    : Color.FromArgb(245, 183, 177);
            }
            else if (column == "MyBooking")
            {
                bool isBooked = Convert.ToInt32(grid.Rows[e.RowIndex].Cells["IsBooked"].Value) == 1;
                if (isBooked)
                {
                    e.CellStyle.BackColor = Color.FromArgb(209, 236, 241);
                }
            }
        }

        private int? SelectedId()
        {
            if (grid.CurrentRow == null) return null;
            return (int)grid.CurrentRow.Cells["Id"].Value;
        }

        // ---------- Действия клиента ----------

        private void btnBook_Click(object sender, EventArgs e)
        {
            int? id = SelectedId();
            if (id == null)
            {
                Ui.Info("Выберите экскурсию в таблице.");
                return;
            }

            string title = (string)grid.CurrentRow.Cells["Title"].Value;
            if (!Ui.Confirm("Присоединиться к экскурсии «" + title + "»?")) return;

            string error = _repo.Book(id.Value, Session.CurrentUser.Id);
            if (error != null)
            {
                Ui.Error(error);
                return;
            }

            LoadData();
            Ui.Info("Вы успешно присоединились к экскурсии!");
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            int? id = SelectedId();
            if (id == null)
            {
                Ui.Info("Выберите экскурсию в таблице.");
                return;
            }

            bool isBooked = Convert.ToInt32(grid.CurrentRow.Cells["IsBooked"].Value) == 1;
            if (!isBooked)
            {
                Ui.Info("Вы не записаны на выбранную экскурсию.");
                return;
            }

            string title = (string)grid.CurrentRow.Cells["Title"].Value;
            if (!Ui.Confirm("Отменить запись на экскурсию «" + title + "»?")) return;

            _repo.CancelBooking(id.Value, Session.CurrentUser.Id);
            LoadData();
            Ui.Info("Запись отменена.");
        }

        // ---------- Действия научного сотрудника ----------

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new ExcursionEditForm(null))
            {
                if (form.ShowDialog(this) == DialogResult.OK) LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int? id = SelectedId();
            if (id == null)
            {
                Ui.Info("Выберите экскурсию в таблице.");
                return;
            }

            using (var form = new ExcursionEditForm(id))
            {
                if (form.ShowDialog(this) == DialogResult.OK) LoadData();
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            ChangeStatus(true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ChangeStatus(false);
        }

        private void ChangeStatus(bool open)
        {
            int? id = SelectedId();
            if (id == null)
            {
                Ui.Info("Выберите экскурсию в таблице.");
                return;
            }

            bool current = Convert.ToBoolean(grid.CurrentRow.Cells["IsOpen"].Value);
            if (current == open)
            {
                Ui.Info(open ? "Эта экскурсия уже открыта для записи." : "Эта экскурсия уже закрыта.");
                return;
            }

            string title = (string)grid.CurrentRow.Cells["Title"].Value;
            string question = open
                ? "Открыть запись на экскурсию «" + title + "»?"
                : "Закрыть запись на экскурсию «" + title + "»?";
            if (!Ui.Confirm(question)) return;

            _repo.SetOpen(id.Value, open);
            LoadData();
        }

        private void btnAssignGuide_Click(object sender, EventArgs e)
        {
            int? id = SelectedId();
            if (id == null)
            {
                Ui.Info("Выберите экскурсию в таблице.");
                return;
            }

            string title = (string)grid.CurrentRow.Cells["Title"].Value;
            int guideId = (int)grid.CurrentRow.Cells["GuideId"].Value;

            using (var form = new AssignGuideForm(id.Value, title, guideId))
            {
                if (form.ShowDialog(this) == DialogResult.OK) LoadData();
            }
        }

        private void btnParticipants_Click(object sender, EventArgs e)
        {
            int? id = SelectedId();
            if (id == null)
            {
                Ui.Info("Выберите экскурсию в таблице.");
                return;
            }

            int guideId = (int)grid.CurrentRow.Cells["GuideId"].Value;
            if (!_canManage && guideId != Session.CurrentUser.Id)
            {
                Ui.Info("Вы можете смотреть участников только на тех экскурсиях, где назначены гидом.");
                return;
            }

            string title = (string)grid.CurrentRow.Cells["Title"].Value;
            int max = (int)grid.CurrentRow.Cells["MaxParticipants"].Value;

            using (var form = new ExcursionParticipantsForm(id.Value, title, max))
            {
                form.ShowDialog(this);
            }
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int? id = SelectedId();
            if (id == null)
            {
                Ui.Info("Выберите экскурсию в таблице.");
                return;
            }

            string title = (string)grid.CurrentRow.Cells["Title"].Value;
            if (!Ui.Confirm("Удалить экскурсию «" + title + "»?")) return;

            try
            {
                _repo.Delete(id.Value);
                LoadData();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (Db.IsForeignKeyError(ex))
                    Ui.Error("Нельзя удалить экскурсию, на которую уже записаны посетители.\nСначала закройте её или снимите участников.");
                else
                    throw;
            }
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && _canManage) btnEdit_Click(sender, e);
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            if (_filtersReady) LoadData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbFilter.SelectedIndex = 0;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            CsvExporter.Export(grid, "Экскурсии");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
