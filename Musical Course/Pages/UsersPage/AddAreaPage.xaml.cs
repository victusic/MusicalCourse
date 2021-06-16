using AmRoMessageDialog;
using Musical_Course.Classes;
using Musical_Course.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Musical_Course.Pages.UsersPage
{
    /// <summary>
    /// Логика взаимодействия для AddAreaPage.xaml
    /// </summary>
    public partial class AddAreaPage : Page
    {
        private Areas _currentAreas = new Areas();
        public AddAreaPage(Areas selectedAreas)
        {
            InitializeComponent();
            Application.Current.MainWindow.ResizeMode = System.Windows.ResizeMode.NoResize;
            Application.Current.MainWindow.WindowState = System.Windows.WindowState.Normal;
            Application.Current.MainWindow.Width = 1280;
            Application.Current.MainWindow.Height = 720;
            if (selectedAreas != null)
            {
                _currentAreas = selectedAreas;
            }

            DataContext = _currentAreas;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var messageBox = new AmRoMessageBox
            {
                Background = "#222222",
                TextColor = "#ffffff",
                IconColor = "#3399ff",
                RippleEffectColor = "#000000",
                ClickEffectColor = "#1F2023",
                ShowMessageWithEffect = true
            };
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentAreas.Name)))
            {
                errors.AppendLine("Заполните поле названия");
            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentAreas.Town)))
            {
                errors.AppendLine("Заполните поле с городом");
            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentAreas.Description)))
            {
                errors.AppendLine("Заполните поле описания");
            }
            if (errors.Length > 0)
            {
                messageBox.Show(errors.ToString());
                return;
            }
            _currentAreas.Representative = GlobalLeVar.UserIdStat;
            if (_currentAreas.AreaId == 0)
            {
                try
                {
                    MusicalBaseEntities2.GetContext().Areas.Add(_currentAreas);
                    MusicalBaseEntities2.GetContext().SaveChanges();
                    messageBox.Show("Информация сохранена");
                }
                catch (Exception ex)
                {
                    messageBox.Show(ex.Message.ToString());
                }
            }
            else if (_currentAreas.AreaId == _currentAreas.AreaId)
            {
                try
                {
                    MusicalBaseEntities2.GetContext().SaveChanges();
                    messageBox.Show("Информация сохранена");
                }
                catch (Exception ex)
                {
                    messageBox.Show(ex.Message.ToString());
                }
            }
            Application.Current.MainWindow.ResizeMode = System.Windows.ResizeMode.CanResize;
            Manager.Frame.GoBack();
        }

        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.ResizeMode = System.Windows.ResizeMode.CanResize;
            Manager.Frame.GoBack();
        }
    }
}
