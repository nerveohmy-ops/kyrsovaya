using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using kyrsovaya.Data;
using kyrsovaya.Models;
using kyrsovaya.Services;

namespace kyrsovaya.Forms
{
    /// <summary>
    /// Главная кнопочная форма. Набор кнопок зависит от роли пользователя.
    /// Результат ShowDialog: Retry — выйти из аккаунта, Cancel — закрыть программу.
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly SpeciesRepository _species = new SpeciesRepository();
        private readonly ObservationRepository _observations = new ObservationRepository();
        private readonly ExcursionRepository _excursions = new ExcursionRepository();
        private readonly UserInfo _user = Session.CurrentUser;

        private string[] _photos = new string[0];
        private int _photoIndex;

        public MainForm()
        {
            InitializeComponent();
            Ui.Apply(this);
            panelMenu.BackColor = Ui.DarkGreen;
            ApplyRolePermissions();
            ShowWelcome();
            LoadBackground();
            StartSlideshow();
        }

        /// <summary>Скрывает пункты меню, которые недоступны роли пользователя.</summary>
        private void ApplyRolePermissions()
        {
            btnObservations.Visible = _user.CanEditData;
            btnUsers.Visible = _user.CanEditData;
            if (!_user.IsAdmin)
            {
                btnUsers.Text = "Назначение гидов";
            }
            // Зоны видны всем, но редактировать их может только администратор (проверяется в ZonesForm)
        }

        private void ShowWelcome()
        {
            labelWelcome.Text = "Добро пожаловать, " + _user.FirstName + "!";
            labelRole.Text = "Роль: " + _user.RoleName;
            RefreshStats();
        }

        private void RefreshStats()
        {
            labelSpeciesCount.Text = "Видов в базе: " + _species.CountAll();
            labelThreatened.Text = "Под угрозой: " + _species.CountThreatened();
            labelObservations.Text = "Наблюдений: " + _observations.CountAll();
            labelExcursions.Text = _user.IsGuide
                ? "Назначено вам экскурсий: " + _excursions.CountForGuide(_user.Id)
                : "Открытых экскурсий: " + _excursions.CountOpen();
        }

        private void LoadBackground()
        {
            string path = Path.Combine(Application.StartupPath, "Images", "Fon_menu.jpg");
            if (File.Exists(path))
            {
                panelContent.BackgroundImage = Image.FromFile(path);
                panelContent.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        // ---------- Слайд-шоу фотографий сотрудников ----------

        private void StartSlideshow()
        {
            string folder = Path.Combine(Application.StartupPath, "Images", "Personal");
            if (!Directory.Exists(folder)) return;

            _photos = Directory.GetFiles(folder, "*.jpg");
            if (_photos.Length == 0) return;

            ShowPhoto();
            timerSlideshow.Start();
        }

        private void ShowPhoto()
        {
            // Копируем в Bitmap, чтобы файл не оставался заблокированным
            using (var original = Image.FromFile(_photos[_photoIndex]))
            {
                var old = pictureStaff.Image;
                pictureStaff.Image = new Bitmap(original);
                if (old != null) old.Dispose();
            }
        }

        private void timerSlideshow_Tick(object sender, EventArgs e)
        {
            _photoIndex = (_photoIndex + 1) % _photos.Length;
            ShowPhoto();
        }

        // ---------- Переходы на другие формы ----------

        private void OpenDialog(Form form)
        {
            using (form)
            {
                form.ShowDialog(this);
            }
            // После возврата данные могли измениться
            ShowWelcome();
        }

        private void btnSpecies_Click(object sender, EventArgs e)
        {
            OpenDialog(new SpeciesForm());
        }

        private void btnObservations_Click(object sender, EventArgs e)
        {
            OpenDialog(new ObservationsForm());
        }

        private void btnExcursions_Click(object sender, EventArgs e)
        {
            OpenDialog(new ExcursionsForm());
        }

        private void btnZones_Click(object sender, EventArgs e)
        {
            OpenDialog(new ZonesForm());
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            OpenDialog(new UsersForm());
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            OpenDialog(new ProfileForm());
        }

        private void menuGuide_Click(object sender, EventArgs e)
        {
            OpenDialog(new AboutForm(true));
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            OpenDialog(new AboutForm(false));
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (Ui.Confirm("Закрыть программу?"))
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timerSlideshow.Stop();
        }
    }
}
