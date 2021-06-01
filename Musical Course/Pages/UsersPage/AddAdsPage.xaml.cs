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
        public AddAdsPage()
        {
            InitializeComponent();
        }

        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.Frame.GoBack();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
