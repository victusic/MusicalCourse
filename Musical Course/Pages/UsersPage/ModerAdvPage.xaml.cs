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
    /// Логика взаимодействия для ModerAdvPage.xaml
    /// </summary>
    public partial class ModerAdvPage : Page
    {
        private Advertisement _currentAdvertisement = new Advertisement();
        public ModerAdvPage(Advertisement selectedAdvertisement)
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

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentAdvertisement.AdvertisementId == _currentAdvertisement.AdvertisementId)
            {
                try
                {
                    MusicalBaseEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            Manager.Frame.GoBack();
        }
    }
}
