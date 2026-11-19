using System;
using System.Data;
using System.Windows.Forms;
using kyrsovaya.Data;
using kyrsovaya.Models;
using kyrsovaya.Services;

namespace kyrsovaya.Forms
{
    /// <summary>
    /// Окно добавления / изменения наблюдения. Если id == null, наблюдение добавляется.
    /// </summary>
    public partial class ObservationEditForm : Form
    {
        private readonly ObservationRepository _repo = new ObservationRepository();
        private readonly int? _id;

        public ObservationEditForm(int? id)
        {
            InitializeComponent();
            Ui.Apply(this);
            _id = id;

            cmbSpecies.DisplayMember = "Name";
            cmbSpecies.ValueMember = "Id";
            cmbSpecies.DataSource = new SpeciesRepository().GetNames();

            cmbZone.DisplayMember = "Name";
            cmbZone.ValueMember = "Id";
            cmbZone.DataSource = new ZoneRepository().GetAll();

            dateObservation.MaxDate = DateTime.Today; // в будущем наблюдать нельзя
            dateObservation.Value = DateTime.Today;

            if (_id == null)
            {
                Text = "Новое наблюдение";
            }
            else
            {
                Text = "Изменение наблюдения";
                FillFields();
            }
        }

        private void FillFields()
        {
            DataRow row = _repo.GetById(_id.Value);
            cmbSpecies.SelectedValue = (int)row["SpeciesId"];
            cmbZone.SelectedValue = (int)row["ZoneId"];
            DateTime date = (DateTime)row["ObservationDate"];
            dateObservation.Value = date > DateTime.Today ? DateTime.Today : date;
            numQuantity.Value = (int)row["Quantity"];
            txtNotes.Text = row["Notes"] == DBNull.Value ? "" : (string)row["Notes"];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNotes.Text.Length > 300)
            {
                Ui.ShowFieldError(errorProvider, txtNotes, "Примечание не длиннее 300 символов");
                return;
            }

            int speciesId = (int)cmbSpecies.SelectedValue;
            int zoneId = (int)cmbZone.SelectedValue;
            int quantity = (int)numQuantity.Value;
            string notes = txtNotes.Text.Trim();

            if (_id == null)
                _repo.Add(speciesId, zoneId, Session.CurrentUser.Id, dateObservation.Value, quantity, notes);
            else
                _repo.Update(_id.Value, speciesId, zoneId, dateObservation.Value, quantity, notes);

            DialogResult = DialogResult.OK;
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtNotes, "");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
