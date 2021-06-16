using AmRoMessageDialog;
using Musical_Course.Database;
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
        private Users _currentUser = new Users();

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

            DataContext = _currentUser;
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
            var messageBox = new AmRoMessageBox
            {
                Background = "#222222",
                TextColor = "#ffffff",
                IconColor = "#3399ff",
                RippleEffectColor = "#000000",
                ClickEffectColor = "#1F2023",
                ShowMessageWithEffect = true
            };
            StringBuilder errors = new StringBuilder();

            if (code2 == RegBox_code.Text)
            {
                if (errors.Length > 0)
                {
                    messageBox.Show(errors.ToString(), "Информация");
                    return;
                }
                if (_currentUser.UserId == 0)
                {
                    try
                    {
                        _currentUser.IsActivity = 0;
                        _currentUser.CountAdvertisement = 0;
                        _currentUser.RegistrationDate = DateTime.Now;
                        MusicalBaseEntities2.GetContext().Users.Add(_currentUser);
                        MusicalBaseEntities2.GetContext().SaveChanges();
                        messageBox.Show("Регистрация прошла успешно", "Регистрация выполнена");
                        Manager.Frame.Navigate(new AutorisationPage());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
            else
            {
                messageBox.Show("Код указан неверный", "Ошибка регистрации");
            }
        }

        private void RegMail_BtnGo_Click(object sender, RoutedEventArgs e)
        {
            var messageBox = new AmRoMessageBox
            {
                Background = "#222222",
                TextColor = "#ffffff",
                IconColor = "#3399ff",
                RippleEffectColor = "#000000",
                ClickEffectColor = "#1F2023",
                ShowMessageWithEffect = true
            };
            StringBuilder errors = new StringBuilder();
          
            if (string.IsNullOrWhiteSpace(_currentUser.Login))
            {
                errors.AppendLine("Введите логин");
            }
            if (string.IsNullOrWhiteSpace(_currentUser.Password))
            {
                errors.AppendLine("Введите пароль");
            }
            if (string.IsNullOrWhiteSpace(_currentUser.Mail))
            {
                errors.AppendLine("Введите адрес почты");
            }
            if (string.IsNullOrWhiteSpace(_currentUser.Phone))
            {
                errors.AppendLine("Введите  номер смарфтона");
            }
            if (string.IsNullOrWhiteSpace(_currentUser.Name))
            {
                errors.AppendLine("Введите ваше имя");
            }
            if (string.IsNullOrWhiteSpace(_currentUser.Surname))
            {
                errors.AppendLine("Введите вашу фамилию");
            }
            if (string.IsNullOrWhiteSpace(_currentUser.Patronymic))
            {
                errors.AppendLine("Введите ваше отчество");
            }
            //тесты
            
            //комбобокс
            if (List.Text == "Продюссер группы")
            {
                _currentUser.Roll = 3;
            }
            else if (List.Text == "Менеджер площадки")
            {
                _currentUser.Roll = 4;
            }
            if (_currentUser.Roll == 0)
            {
                messageBox.Show("Укажите роль", "Ошибка регистрации");
            }

            if (errors.Length > 0)
            {
                messageBox.Show(errors.ToString());
                return;
            }
            else
            {
                if (_currentUser.Password.Length < 8)
                {
                    messageBox.Show("Пароль короткий");
                }
                else if (!_currentUser.Password.Any(Char.IsDigit))
                {
                    messageBox.Show("Добавьте в пароль цифры");
                }
                else if (_currentUser.Password.Intersect("#$%^&_").Count() == 0)
                {
                    messageBox.Show("Добавьте в пароль специальные символы");
                }
                else
                {
                    try
                    {
                        string MailChek = "SELECT * FROM Users WHERE Mail ='" + _currentUser.Mail + "'";
                        var sql1 = MusicalBaseEntities2.GetContext().Users.SqlQuery(MailChek).ToArray();
                        string LoginChek = "SELECT * FROM Users WHERE Login ='" + _currentUser.Login + "'";
                        var sql2 = MusicalBaseEntities2.GetContext().Users.SqlQuery(LoginChek).ToArray();
                        string PhoneCheck = "SELECT * FROM Users WHERE Phone ='" + _currentUser.Phone + "'";
                        var sql3 = MusicalBaseEntities2.GetContext().Users.SqlQuery(PhoneCheck).ToArray();
                        if (sql1.Length != 0 || sql2.Length != 0 || sql3.Length != 0)
                        {
                            if (sql1.Length != 0)
                            {
                                messageBox.Show("Введённая вами почта уже присутсвует", "Ошибка регистрации");
                            }
                            if (sql2.Length != 0)
                            {
                                messageBox.Show("Введённый вами логин уже занят", "Ошибка регистрации");
                            }
                            if (sql3.Length != 0)
                            {
                                messageBox.Show("Введённый вами номер телефона уже используется", "Ошибка регистрации");
                            }
                            //MessageBox.Show("Введённый вами данные, а имеено некоторые из них: почта логин или номер телефона уже используются", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            messageBox.Show("Для подтверждения ваших введённых данных мы используем двухфакторную аутентификацию. " +
                                "Мы отправим вам сообщение на почту с кодом, который нужно ввести в поле, затем отправим вам сообщение на номер телефона", "Регистрация");
                            messageBox.Show("Сообщение отправленно на почту: " + RegBox_Mail.Text, "Регистрация");


                            // отправитель - устанавливаем адрес и отображаемое в письме имя
                            MailAddress from = new MailAddress("dlya_d_raboty_raboty@mail.ru", "Sound Production");
                            // кому отправляем
                            MailAddress to = new MailAddress(RegBox_Mail.Text);
                            // создаем объект сообщения
                            MailMessage m = new MailMessage(from, to);
                            //m.Attachments.Add(new Attachment("../../Resources/BackgroundMail.jpg"));
                            // тема письма
                            m.Subject = "Регистрация аккаунта";
                            // текст письма
                            m.Body = "Код для входа: " + code;
                            // письмо представляет код html
                            m.IsBodyHtml = true;
                            // адрес smtp-сервера и порт, с которого будем отправлять письмо
                            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);
                            // логин и пароль
                            smtp.Credentials = new NetworkCredential("dlya_d_raboty_raboty@mail.ru", "DHDKI55544DIEJDO5854565");
                            smtp.EnableSsl = true;
                            smtp.Send(m);

                            RegPhone_BtnGo.Visibility = Visibility.Visible;
                            RegMail_BtnGo.Visibility = Visibility.Hidden;
                        }
                    }
                    catch (Exception en)
                    {
                        messageBox.Show(en.Message.ToString());
                    }
                }
                
            }
        }
        private void RegPhone_BtnGo_Click(object sender, RoutedEventArgs e)
        {
            var messageBox = new AmRoMessageBox
            {
                Background = "#222222",
                TextColor = "#ffffff",
                IconColor = "#3399ff",
                RippleEffectColor = "#000000",
                ClickEffectColor = "#1F2023",
                ShowMessageWithEffect = true
            };
            if (code == RegBox_code.Text)
            {
                messageBox.Show("Почта подтверждена, теперь мы вам отправим новый код на ваш указанный номер телефона, продолжить?",
                    "Регистрация");
                messageBox.Show("Сообщение отправленно на номер телефона: " + RegBox_Phone.Text, "Регистрация");

                //Отправка сообщения на смартфон

                string myApiKey = "C5562597-9547-B1FE-7688-82E8462AA560"; //API ключ
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://sms.ru/sms/send?api_id=" + myApiKey + "&to=" + _currentUser.Phone + "&msg=" + code2 + "&json=1");

                httpWebRequest.ContentType = "text/json";
                httpWebRequest.Method = "POST";//GET
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();


                RegPhone_BtnGo.Visibility = Visibility.Hidden;
                Reg_BtnGo.Visibility = Visibility.Visible;
            }
            else
            {
                messageBox.Show("Код указан неверный", "Ошибка регистрации");
            }
        }

        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new IntroPage());
        }
    }
}
