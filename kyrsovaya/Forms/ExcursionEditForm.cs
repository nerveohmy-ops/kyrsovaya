using System;
using System.Data;
using System.Windows.Forms;
using kyrsovaya.Data;
using kyrsovaya.Models;
using kyrsovaya.Services;

namespace kyrsovaya.Forms
{
    /// <summary>
    /// Окно создания или редактирования экскурсии (для научного сотрудника и администратора).
    /// </summary>
    public partial class ExcursionEditForm : Form
    {
        private readonly ExcursionRepository _repo = new ExcursionRepository();
        private readonly int? _id;

        public ExcursionEditForm(int? id)
        {
            InitializeComponent();
            Ui.Apply(this);
            _id = id;

            cmbZone.DisplayMember = "Name";
            cmbZone.ValueMember = "Id";
            cmbZone.DataSource = new ZoneRepository().GetAll();

            cmbGuide.DisplayMember = "FullName";
            cmbGuide.ValueMember = "Id";
            cmbGuide.DataSource = _repo.GetGuides();

            if (_id == null)
            {
                Text = "Новая экскурсия";
                dtpDate.Value = DateTime.Today.AddDays(1);
                dtpTime.Value = DateTime.Today.AddHours(10);
                cmbGuide.SelectedValue = Session.CurrentUser.Id;
                chkIsOpen.Checked = true;
            }
            else
            {
                Text = "Изменение экскурсии";
                FillFields();
            }
        }

        private void FillFields()
        {
            DataRow row = _repo.GetById(_id.Value);
            txtTitle.Text = (string)row["Title"];
            cmbZone.SelectedValue = (int)row["ZoneId"];
            cmbGuide.SelectedValue = (int)row["GuideId"];

            DateTime date = (DateTime)row["ExcursionDate"];
            dtpDate.Value = date.Date;
            dtpTime.Value = DateTime.Today.Add(date.TimeOfDay);

            numMax.Value = (int)row["MaxParticipants"];
            chkIsOpen.Checked = (bool)row["IsOpen"];
            txtDescription.Text = row["Description"] == DBNull.Value ? "" : (string)row["Description"];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            string title = txtTitle.Text.Trim();
            int zoneId = (int)cmbZone.SelectedValue;
            int guideId = (int)cmbGuide.SelectedValue;
            DateTime fullDate = dtpDate.Value.Date + dtpTime.Value.TimeOfDay;
            // Убираем секунды, чтобы время в таблице было ровным
            fullDate = new DateTime(fullDate.Year, fullDate.Month, fullDate.Day, fullDate.Hour, fullDate.Minute, 0);
            int maxParticipants = (int)numMax.Value;
            bool isOpen = chkIsOpen.Checked;
            string description = txtDescription.Text.Trim();

            if (_id == null)
                _repo.Add(title, zoneId, guideId, fullDate, maxParticipants, isOpen, description);
            else
                _repo.Update(_id.Value, title, zoneId, guideId, fullDate, maxParticipants, isOpen, description);

            DialogResult = DialogResult.OK;
        }

        private bool ValidateFields()
        {
            bool hasError = false;

            string title = txtTitle.Text.Trim();
            string titleError = null;
            if (title == "") titleError = "Введите название экскурсии";
            else if (title.Length > 120) titleError = "Название не длиннее 120 символов";
            hasError |= Ui.ShowFieldError(errorProvider, txtTitle, titleError);

            string maxError = null;
            if (_id != null)
            {
                int booked = _repo.GetBookedCount(_id.Value);
                if (numMax.Value < booked)
                    maxError = "Уже записано участников: " + booked + ". Нельзя указать меньше.";
            }
            hasError |= Ui.ShowFieldError(errorProvider, numMax, maxError);

            string descError = txtDescription.Text.Length > 400 ? "Описание не длиннее 400 символов" : null;
            hasError |= Ui.ShowFieldError(errorProvider, txtDescription, descError);

            return !hasError;
        }

        private void Field_Changed(object sender, EventArgs e)
        {
            errorProvider.SetError((Control)sender, "");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
