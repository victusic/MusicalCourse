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
    /// Логика взаимодействия для AddGroupManagerPage.xaml
    /// </summary>
    public partial class AddGroupManagerPage : Page
    {
        private Groups _currentGroups = new Groups();
        public AddGroupManagerPage(Groups selectedGroups)
        {
            InitializeComponent();
            Application.Current.MainWindow.ResizeMode = System.Windows.ResizeMode.NoResize;
            Application.Current.MainWindow.WindowState = System.Windows.WindowState.Normal;
            Application.Current.MainWindow.Width = 1280;
            Application.Current.MainWindow.Height = 720;

            if (selectedGroups != null)
            {
                _currentGroups = selectedGroups;
            }

            DataContext = _currentGroups;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentGroups.Name)))
            {
                errors.AppendLine("Заполните поле названия");
            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentGroups.DescriptionAreas)))
            {
                errors.AppendLine("Заполните поле с желаемой ареной");
            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentGroups.Description)))
            {
                errors.AppendLine("Заполните поле описания");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            _currentGroups.Producer = GlobalLeVar.UserIdStat;
            if (_currentGroups.BandId == 0)
            {
                try
                {
                    MusicalBaseEntities2.GetContext().Groups.Add(_currentGroups);
                    MusicalBaseEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else if (_currentGroups.BandId == _currentGroups.BandId)
            {
                try
                {
                    MusicalBaseEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
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
