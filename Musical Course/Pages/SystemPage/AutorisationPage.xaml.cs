using Musical_Course.Classes;
using Musical_Course.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        public static Users table;
        public static Users tableLogin;
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
            int userId = 0;
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
                using (MusicalBaseEntities2 databd = new MusicalBaseEntities2())
                {
                    table = databd.Users.Where(l => l.Login == LoginBox_Auth.Text && l.Password == PasswordBox_Auth.Password).FirstOrDefault();
                    tableLogin = databd.Users.Where(l => l.Login == LoginBox_Auth.Text && l.Password != PasswordBox_Auth.Password).FirstOrDefault();

                    if (tableLogin != null)
                    {
                        userId = tableLogin.UserId;
                        if (userId != 0)
                        {
                            HistoriAdd(userId, false);
                        }
                    }
                    if (table != null)
                    {
                        var rol = table.Roll;
                        if (table.IsActivity == 0)
                        {
                            GlobalLeVar.LoginStat = table.Name;
                            GlobalLeVar.UserIdStat = table.UserId;
                            if (rol == 1)
                            {
                                Manager.Frame.Navigate(new AdministratorPage());
                                MessageBox.Show("Вы успешно вошли", "Вход выполнен успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                                Application.Current.MainWindow.ResizeMode = System.Windows.ResizeMode.CanResize;
                            }
                            else if (rol == 2)
                            {
                                Manager.Frame.Navigate(new ModeratorPage());
                                MessageBox.Show("Вы успешно вошли", "Вход выполнен успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                                Application.Current.MainWindow.ResizeMode = System.Windows.ResizeMode.CanResize;
                            }
                            else if (rol == 3)
                            {
                                Manager.Frame.Navigate(new ProducerPage());
                                MessageBox.Show("Вы успешно вошли", "Вход выполнен успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                                Application.Current.MainWindow.ResizeMode = System.Windows.ResizeMode.CanResize;
                                MailAddress from = new MailAddress("dlya_d_raboty_raboty@mail.ru", "Sound Production");
                                MailAddress to = new MailAddress(table.Mail);
                                MailMessage m = new MailMessage(from, to);
                                m.Attachments.Add(new Attachment("../../Resources/BackgroundMail2.jpg"));
                                m.Subject = "Вход в приложение";
                                m.Body = "С вашего аккаунта " + table.Login + " был совершён вход в систему " + DateTime.Now + " - если это не вы, обратитесь в нашу службу поддержки";
                                m.IsBodyHtml = true;
                                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);
                                smtp.Credentials = new NetworkCredential("dlya_d_raboty_raboty@mail.ru", "DHDKI55544DIEJDO5854565");
                                smtp.EnableSsl = true;
                                smtp.Send(m);
                            }
                            else if (rol == 4)
                            {
                                Manager.Frame.Navigate(new ManagerPage());
                                MessageBox.Show("Вы успешно вошли", "Вход выполнен успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                                Application.Current.MainWindow.ResizeMode = System.Windows.ResizeMode.CanResize;
                                MailAddress from = new MailAddress("dlya_d_raboty_raboty@mail.ru", "Sound Production");
                                MailAddress to = new MailAddress(table.Mail);
                                MailMessage m = new MailMessage(from, to);
                                m.Attachments.Add(new Attachment("../../Resources/BackgroundMail2.jpg"));
                                m.Subject = "Вход в приложение";
                                m.Body = "С вашего аккаунта " + table.Login + " был совершён вход в систему " + DateTime.Now + " - если это не вы, обратитесь в нашу службу поддержки";
                                m.IsBodyHtml = true;
                                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);
                                smtp.Credentials = new NetworkCredential("dlya_d_raboty_raboty@mail.ru", "DHDKI55544DIEJDO5854565");
                                smtp.EnableSsl = true;
                                smtp.Send(m);
                            }
                        }
                        else
                        {
                            HistoriAdd(userId, false);
                            MessageBox.Show("Ваш аккаунт был заблокирован, за подробностями обратититесь на нашу почту", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        if (table == null && (LoginBox_Auth.Text.Length != 0 && PasswordBox_Auth.Password.Length != 0))
                        {
                            MessageBox.Show("Вы не правильно ввели логин или пароль", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }

        public static void HistoriAdd(int userId, bool state)
        {
            try
            {
                AutorisationHistory HistoryLogin = new AutorisationHistory();
                HistoryLogin.UserId = userId;
                HistoryLogin.Date = DateTime.Now;
                HistoryLogin.State = state;
                MusicalBaseEntities2.GetContext().AutorisationHistory.Add(HistoryLogin);
                MusicalBaseEntities2.GetContext().SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new IntroPage());
        }
    }
}
