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
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        private Users _currentusers = new Users();
        public AddUserPage(Users selectedUsers)
        {
            InitializeComponent();

            if (selectedUsers != null)
            {
                _currentusers = selectedUsers;
            }

            DataContext = _currentusers;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentusers.UserId == 0)
            {
                try
                {
                    MusicalBaseEntities1.GetContext().Users.Add(_currentusers);
                    MusicalBaseEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else if (_currentusers.UserId == _currentusers.UserId)
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

        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.Frame.GoBack();
        }
    }
}
