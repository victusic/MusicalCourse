using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        string code = Convert.ToString(new Random().Next(0, 4)) + Convert.ToString(new Random().Next(0, 9)) + Convert.ToString(new Random().Next(2, 5)) +
            Convert.ToString(new Random().Next(0, 1)) + Convert.ToString(new Random().Next(7, 8)) + Convert.ToString(new Random().Next(6, 9)) + 
            Convert.ToString(new Random().Next(2, 4));
        string code2 = Convert.ToString(new Random().Next(7, 9)) + Convert.ToString(new Random().Next(1, 4)) + Convert.ToString(new Random().Next(3, 6)) +
           Convert.ToString(new Random().Next(4, 5)) + Convert.ToString(new Random().Next(1, 9)) + Convert.ToString(new Random().Next(0, 7)) +
           Convert.ToString(new Random().Next(3, 8));
        public RegistrationPage()
        {
            InitializeComponent();
            Application.Current.MainWindow.ResizeMode = System.Windows.ResizeMode.NoResize;
            Application.Current.MainWindow.WindowState = System.Windows.WindowState.Normal;
            Application.Current.MainWindow.Width = 1280;
            Application.Current.MainWindow.Height = 720;
            Reg_BtnGo.Visibility = Visibility.Hidden;
            RegPhone_BtnGo.Visibility = Visibility.Hidden;
        }

        private void HyperBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new AutorisationPage());
        }

        private void Reg_BtnLogo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Reg_BtnGo_Click(object sender, RoutedEventArgs e)
        {
            if (code2 == RegBox_code.Text)
            {
                MessageBox.Show("Регистрация прошла успешно", "Регистрация выполнена", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Код указан неверный", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegMail_BtnGo_Click(object sender, RoutedEventArgs e)
        {            
            
            MessageBox.Show("Для подтверждения ваших введённых данных мы используем двухфакторную аутентификацию. " +
                "Мы отправим вам сообщение на почту с кодом, который нужно ввести в поле, затем отправим вам сообщение на номер телефона", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            MessageBox.Show("Сообщение отправленно на почту: " + RegBox_Mail.Text + code, "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);


            // отправитель - устанавливаем адрес и отображаемое в письме имя
            /*MailAddress from = new MailAddress("dlya_d_raboty_raboty@mail.ru", "Sound Production");
            // кому отправляем
            MailAddress to = new MailAddress(RegBox_Mail.Text);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Тест";
            // текст письма
            m.Body = code;
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("dlya_d_raboty_raboty@mail.ru", "DHDKI55544DIEJDO5854565");
            smtp.EnableSsl = true;
            smtp.Send(m);*/

            RegPhone_BtnGo.Visibility = Visibility.Visible;
            RegMail_BtnGo.Visibility = Visibility.Hidden;
        }
        private void RegPhone_BtnGo_Click(object sender, RoutedEventArgs e)
        {
            if (code == RegBox_code.Text)
            {
                MessageBox.Show("Почта подтверждена, теперь мы вам отправим новый код на ваш указанный номер телефона, продолжить?",
                    "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
                MessageBox.Show("Сообщение отправленно на номер телефона: " + RegBox_Phone.Text + code2, "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);



                RegPhone_BtnGo.Visibility = Visibility.Hidden;
                Reg_BtnGo.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Код указан неверный", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
