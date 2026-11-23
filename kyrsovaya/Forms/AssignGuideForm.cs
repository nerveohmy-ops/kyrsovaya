using System;
using System.Windows.Forms;
using kyrsovaya.Data;
using kyrsovaya.Services;

namespace kyrsovaya.Forms
{
    /// <summary>
    /// Небольшое окно для назначения гида на выбранную экскурсию.
    /// </summary>
    public partial class AssignGuideForm : Form
    {
        private readonly ExcursionRepository _repo = new ExcursionRepository();
        private readonly int _excursionId;

        public AssignGuideForm(int excursionId, string excursionTitle, int currentGuideId)
        {
            InitializeComponent();
            Ui.Apply(this);
            _excursionId = excursionId;

            labelExcursion.Text = "Экскурсия: " + excursionTitle;
            cmbGuide.DisplayMember = "FullName";
            cmbGuide.ValueMember = "Id";
            cmbGuide.DataSource = _repo.GetGuides();
            cmbGuide.SelectedValue = currentGuideId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbGuide.SelectedValue == null) return;
            _repo.SetGuide(_excursionId, (int)cmbGuide.SelectedValue);
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
