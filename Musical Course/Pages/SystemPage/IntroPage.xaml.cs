using Musical_Course.Pages.SystemPage;
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

namespace Musical_Course.Pages
{
    /// <summary>
    /// Логика взаимодействия для IntroPage.xaml
    /// </summary>
    public partial class IntroPage : Page
    {
        public IntroPage()
        {
            InitializeComponent();
        }

        private void BtnGo_Click(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new AutorisationPage());
        }

        private void BtnAboutGo_Click(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new AboutProgramPage());
        }
    }
}
