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
            if (selectedAreas != null)
            {
                _currentAreas = selectedAreas;
            }

            DataContext = _currentAreas;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
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
                MessageBox.Show(errors.ToString());
                return;
            }
            _currentAreas.Representative = GlobalLeVar.UserIdStat;
            if (_currentAreas.AreaId == 0)
            {
                try
                {
                    MusicalBaseEntities2.GetContext().Areas.Add(_currentAreas);
                    MusicalBaseEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else if (_currentAreas.AreaId == _currentAreas.AreaId)
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
            Manager.Frame.GoBack();
        }

        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.Frame.GoBack();
        }
    }
}
