using Musical_Course.Classes;
using Musical_Course.Database;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для AutorisationPage.xaml
    /// </summary>
    public partial class AutorisationPage : Page
    {
        public AutorisationPage()
        {
            InitializeComponent();
            Application.Current.MainWindow.ResizeMode = System.Windows.ResizeMode.NoResize;
            Application.Current.MainWindow.WindowState = System.Windows.WindowState.Normal;
            Application.Current.MainWindow.Width = 1280;
            Application.Current.MainWindow.Height = 720;
        }

        private void HyperGo_Click(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new RegistrationPage());
        }

        private void Log_BtnGo_Click(object sender, RoutedEventArgs e)
        {
            if (LoginBox_Auth.Text.Length == 0 || PasswordBox_Auth.Password.Length == 0)
            {
                if (LoginBox_Auth.Text.Length == 0 && PasswordBox_Auth.Password.Length == 0)
                {
                    MessageBox.Show("Введите пароль и логин", "Предупреждение входа", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (PasswordBox_Auth.Password.Length == 0)
                {
                    MessageBox.Show("Введите пароль", "Предупреждение входа", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (LoginBox_Auth.Text.Length == 0)
                {
                    MessageBox.Show("Введите логин", "Предупреждение входа", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                int userId = 0;
                int errors = 0;
                try
                {
                    foreach (var user in MusicalBaseEntities1.GetContext().Users)
                    {
                        if (LoginBox_Auth.Text == user.Login && PasswordBox_Auth.Password == user.Password)
                        {
                            userId = user.UserId;
                            GlobalLeVar.LoginStat = user.Name;
                            if (user.Roll == 1)
                            {
                                Manager.Frame.Navigate(new AdministratorPage());
                                MessageBox.Show("Вы успешно вошли", "Вход выполнен успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                                Application.Current.MainWindow.ResizeMode = System.Windows.ResizeMode.CanResize;
                            }
                            else if (user.Roll == 2)
                            {
                                Manager.Frame.Navigate(new ModeratorPage());
                                MessageBox.Show("Вы успешно вошли", "Вход выполнен успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                                Application.Current.MainWindow.ResizeMode = System.Windows.ResizeMode.CanResize;
                            }
                            else if (user.Roll == 3)
                            {
                                Manager.Frame.Navigate(new ProducerPage());
                                MessageBox.Show("Вы успешно вошли", "Вход выполнен успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                                Application.Current.MainWindow.ResizeMode = System.Windows.ResizeMode.CanResize;
                            }
                            else if (user.Roll == 4)
                            {
                                Manager.Frame.Navigate(new ManagerPage());
                                MessageBox.Show("Вы успешно вошли", "Вход выполнен успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                                Application.Current.MainWindow.ResizeMode = System.Windows.ResizeMode.CanResize;
                            }
                            errors = 0;
                            break;
                        }
                        else if (LoginBox_Auth.Text == user.Login)
                        {
                            errors += 2;
                            userId = user.UserId;
                        }
                        else
                        {
                            errors++;
                        }
                    }
                    if (errors == 0)
                    {
                        HistoriAdd(true, userId);
                    }
                    else
                    {
                        if (errors == 2)
                        {
                            HistoriAdd(false, userId);
                        }
                        MessageBox.Show("Jib,rf d[jlf");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        public static void HistoriAdd(bool state, int user_id)
        {
            try
            {
                AutorisationHistory HistoryLogin = new AutorisationHistory();
                HistoryLogin.UserId = user_id;
                HistoryLogin.Date = DateTime.Now;
                HistoryLogin.State = state;
                MusicalBaseEntities1.GetContext().AutorisationHistory.Add(HistoryLogin);
                MusicalBaseEntities1.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
