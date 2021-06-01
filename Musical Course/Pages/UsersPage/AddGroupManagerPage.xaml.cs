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
        public AddGroupManagerPage()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            try
            {
                MessageBox.Show("Информация сохранена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.Frame.GoBack();
        }

        private void BtnAdd_PhotoOne_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_PhotoTwo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_PhotoThree_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_PhotoFour_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_PhotoFive_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
