using System;
using System.Data;
using System.Windows.Forms;
using kyrsovaya.Data;
using kyrsovaya.Services;

namespace kyrsovaya.Forms
{
    /// <summary>
    /// Окно добавления / изменения вида. Если id == null, вид добавляется.
    /// </summary>
    public partial class SpeciesEditForm : Form
    {
        private readonly SpeciesRepository _repo = new SpeciesRepository();
        private readonly int? _id;

        public SpeciesEditForm(int? id)
        {
            InitializeComponent();
            Ui.Apply(this);
            _id = id;

            cmbKind.Items.AddRange(new object[] { "Животное", "Растение", "Гриб" });
            cmbKind.SelectedIndex = 0;

            cmbStatus.DisplayMember = "Name";
            cmbStatus.ValueMember = "Id";
            cmbStatus.DataSource = _repo.GetStatuses();

            if (_id == null)
            {
                Text = "Новый вид";
            }
            else
            {
                Text = "Изменение вида";
                FillFields();
            }
        }

        private void FillFields()
        {
            DataRow row = _repo.GetById(_id.Value);
            txtName.Text = (string)row["Name"];
            txtLatin.Text = (string)row["LatinName"];
            cmbKind.SelectedItem = (string)row["Kind"];
            cmbStatus.SelectedValue = (int)row["StatusId"];
            numPopulation.Value = (int)row["Population"];
            txtDescription.Text = row["Description"] == DBNull.Value ? "" : (string)row["Description"];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            string name = txtName.Text.Trim();
            string latin = txtLatin.Text.Trim();
            string description = txtDescription.Text.Trim();
            int statusId = (int)cmbStatus.SelectedValue;
            int population = (int)numPopulation.Value;

            if (_id == null)
                _repo.Add(name, latin, cmbKind.Text, statusId, population, description);
            else
                _repo.Update(_id.Value, name, latin, cmbKind.Text, statusId, population, description);

            DialogResult = DialogResult.OK;
        }

        private bool ValidateFields()
        {
            bool hasError = false;

            string nameError = null;
            string name = txtName.Text.Trim();
            if (name == "") nameError = "Введите название вида";
            else if (name.Length > 100) nameError = "Название не длиннее 100 символов";
            else if (_repo.NameExists(name, _id ?? 0)) nameError = "Вид с таким названием уже есть";
            hasError |= Ui.ShowFieldError(errorProvider, txtName, nameError);

            string latinError = null;
            if (txtLatin.Text.Trim() == "") latinError = "Введите латинское название";
            else if (txtLatin.Text.Length > 100) latinError = "Название не длиннее 100 символов";
            hasError |= Ui.ShowFieldError(errorProvider, txtLatin, latinError);

            string descError = txtDescription.Text.Length > 500 ? "Описание не длиннее 500 символов" : null;
            hasError |= Ui.ShowFieldError(errorProvider, txtDescription, descError);

            return !hasError;
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
