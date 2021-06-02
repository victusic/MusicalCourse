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
    /// Логика взаимодействия для AddAdsPage.xaml
    /// </summary>
    public partial class AddAdsPage : Page
    {
        private Advertisement _currentAdvertisement = new Advertisement();
        public AddAdsPage(Advertisement selectedAdvertisement)
        {
            InitializeComponent();

            if (selectedAdvertisement != null)
            {
                _currentAdvertisement = selectedAdvertisement;
            }

            DataContext = _currentAdvertisement;
        }

        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.Frame.GoBack();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentAdvertisement.Area)) || string.IsNullOrWhiteSpace(Convert.ToString(_currentAdvertisement.Group)))
            {
                errors.AppendLine("Укажите объявление, которое хотите опубликовать");
            }
            _currentAdvertisement.Representative = GlobalLeVar.UserIdStat;
            _currentAdvertisement.Moderation = 0;
            if (_currentAdvertisement.Area != 0 && _currentAdvertisement.Group != 0)
            {
                MessageBox.Show("Укажите номер только одного объявления нужного вам типа");
            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentAdvertisement.Group)))
            {
                _currentAdvertisement.TypeAdvertisement = 1;
            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentAdvertisement.Area)))
            {
                _currentAdvertisement.TypeAdvertisement = 2;
            }
            if (_currentAdvertisement.AdvertisementId == 0)
            {
                try
                {
                    MusicalBaseEntities2.GetContext().Advertisement.Add(_currentAdvertisement);
                    MusicalBaseEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена, далее она будет пройти проверку, после чего будет опубликованна в общий доступ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else if (_currentAdvertisement.AdvertisementId == _currentAdvertisement.AdvertisementId)
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
        }
    }
}
