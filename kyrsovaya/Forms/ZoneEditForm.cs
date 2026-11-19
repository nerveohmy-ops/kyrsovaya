using System;
using System.Data;
using System.Windows.Forms;
using kyrsovaya.Data;
using kyrsovaya.Services;

namespace kyrsovaya.Forms
{
    /// <summary>
    /// Окно добавления / изменения участка. Если id == null, участок добавляется.
    /// </summary>
    public partial class ZoneEditForm : Form
    {
        private readonly ZoneRepository _repo = new ZoneRepository();
        private readonly int? _id;

        public ZoneEditForm(int? id)
        {
            InitializeComponent();
            Ui.Apply(this);
            _id = id;

            if (_id == null)
            {
                Text = "Новый участок";
                return;
            }

            Text = "Изменение участка";
            DataRow row = _repo.GetById(_id.Value);
            txtName.Text = (string)row["Name"];
            numArea.Value = (decimal)row["AreaHa"];
            txtDescription.Text = row["Description"] == DBNull.Value ? "" : (string)row["Description"];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();

            string nameError = null;
            if (name == "") nameError = "Введите название участка";
            else if (name.Length > 100) nameError = "Название не длиннее 100 символов";
            else if (_repo.NameExists(name, _id ?? 0)) nameError = "Участок с таким названием уже есть";

            bool hasError = Ui.ShowFieldError(errorProvider, txtName, nameError);
            hasError |= Ui.ShowFieldError(errorProvider, txtDescription,
                txtDescription.Text.Length > 300 ? "Описание не длиннее 300 символов" : null);
            if (hasError) return;

            if (_id == null)
                _repo.Add(name, numArea.Value, txtDescription.Text.Trim());
            else
                _repo.Update(_id.Value, name, numArea.Value, txtDescription.Text.Trim());

            DialogResult = DialogResult.OK;
        }

        private void Field_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError((Control)sender, "");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
