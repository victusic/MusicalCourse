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
    /// Логика взаимодействия для PrintManagerPage.xaml
    /// </summary>
    public partial class PrintManagerPage : Page
    {
        private Advertisement _currentAdvertisement = new Advertisement();
        public PrintManagerPage(Advertisement selectedAdvertisement)
        {
            InitializeComponent();
            if (selectedAdvertisement != null)
            {
                _currentAdvertisement = selectedAdvertisement;
            }

            DataContext = _currentAdvertisement;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.Frame.GoBack();
        }
    }
}
