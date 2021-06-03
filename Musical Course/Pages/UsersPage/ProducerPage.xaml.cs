using Musical_Course.Classes;
using Musical_Course.Database;
using Musical_Course.Pages;
using Musical_Course.Pages.UsersPage;
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

namespace Musical_Course
{
    /// <summary>
    /// Логика взаимодействия для ProducerPage.xaml
    /// </summary>
    public partial class ProducerPage : Page
    {
        public ProducerPage()
        {
            InitializeComponent();
            TimeSpan time = DateTime.Now.TimeOfDay;
            TimeSpan time0 = new TimeSpan(0, 0, 0);
            TimeSpan time6 = new TimeSpan(6, 0, 0);
            TimeSpan time12 = new TimeSpan(12, 0, 0);
            TimeSpan time18 = new TimeSpan(18, 0, 0);
            TimeSpan time24 = new TimeSpan(23, 59, 59);
            InitializeComponent();
            if (time >= time0 && time < time6)
            {
                HelloText.Text = "Доброй ночи, " + GlobalLeVar.LoginStat;
            }
            else if (time >= time6 && time < time12)
            {
                HelloText.Text = "Доброе утро, " + GlobalLeVar.LoginStat;
            }
            else if (time >= time12 && time < time18)
            {
                HelloText.Text = "Добрый день, " + GlobalLeVar.LoginStat;
            }
            else if (time >= time18 && time <= time24)
            {
                HelloText.Text = "Добрый вечер, " + GlobalLeVar.LoginStat;
            }
            else
            {
                HelloText.Text = "Здравствуйте, " + GlobalLeVar.LoginStat;
            }
            PreviewGrid.Visibility = Visibility.Visible;
            AdvertisementGrid.Visibility = Visibility.Hidden;
            GroupGrid.Visibility = Visibility.Hidden;
            VivsibleAdvertisementGrid.Visibility = Visibility.Hidden;
            //Бд
            Tts.ItemsSource = MusicalBaseEntities2.GetContext().Groups.ToList();
            Tts1.ItemsSource = MusicalBaseEntities2.GetContext().Advertisement.ToList();
            //Tts1.ItemsSource = MusicalBaseEntities2.GetContext().Advertisement.Where(p => p.Representative.ToString().ToLower().Contains(Convert.ToString(GlobalLeVar.UserIdStat))).ToList();
            Tts2.ItemsSource = MusicalBaseEntities2.GetContext().Advertisement.ToList();
        }
        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 0.3;
        }

        private void Panel0_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PreviewGrid.Visibility = Visibility.Visible;
            AdvertisementGrid.Visibility = Visibility.Hidden;
            GroupGrid.Visibility = Visibility.Hidden;
            VivsibleAdvertisementGrid.Visibility = Visibility.Hidden;
        }

        private void Panel7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Manager.Frame.Navigate(new AutorisationPage());
        }

        private void Panel2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PreviewGrid.Visibility = Visibility.Hidden;
            AdvertisementGrid.Visibility = Visibility.Visible;
            GroupGrid.Visibility = Visibility.Hidden;
            VivsibleAdvertisementGrid.Visibility = Visibility.Hidden;
        }

        private void Panel1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PreviewGrid.Visibility = Visibility.Hidden;
            AdvertisementGrid.Visibility = Visibility.Hidden;
            GroupGrid.Visibility = Visibility.Visible;
            VivsibleAdvertisementGrid.Visibility = Visibility.Hidden;
        }
        private void Tts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MusicalBaseEntities2.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 1;
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            if (Tg_Btn.IsChecked == true)
            {
                tt_ome.Visibility = Visibility.Collapsed;
                tt_home.Visibility = Visibility.Collapsed;
                tt_contacts.Visibility = Visibility.Collapsed;
                tt_messages.Visibility = Visibility.Collapsed;
                tt_nout.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_ome.Visibility = Visibility.Visible;
                tt_home.Visibility = Visibility.Visible;
                tt_contacts.Visibility = Visibility.Visible;
                tt_messages.Visibility = Visibility.Visible;
                tt_nout.Visibility = Visibility.Visible;
            }
        }

        private void Panel3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PreviewGrid.Visibility = Visibility.Hidden;
            AdvertisementGrid.Visibility = Visibility.Hidden;
            GroupGrid.Visibility = Visibility.Hidden;
            VivsibleAdvertisementGrid.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //объявления редактировать
            Manager.Frame.Navigate(new AddAdsPage((sender as Button).DataContext as Advertisement));
        }

        private void BtnDeleteAds1_Click(object sender, RoutedEventArgs e)
        {
            //объявления удалить
            var AdvertisementForRemoving = Tts1.SelectedItems.Cast<Advertisement>().ToList();

            try
            {
                MusicalBaseEntities2.GetContext().Advertisement.RemoveRange(AdvertisementForRemoving);
                MusicalBaseEntities2.GetContext().SaveChanges();
                Tts1.ItemsSource = MusicalBaseEntities2.GetContext().Advertisement.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnAddAds1_Click(object sender, RoutedEventArgs e)
        {
            //объявления добавить
            Manager.Frame.Navigate(new AddAdsPage(null));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //объявления печать
            Manager.Frame.Navigate(new PrintProducerPage((sender as Button).DataContext as Advertisement));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            //группы редактировать
            Manager.Frame.Navigate(new AddGroupManagerPage((sender as Button).DataContext as Groups));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            //группы удалить
            var GroupsForRemoving = Tts.SelectedItems.Cast<Groups>().ToList();

            try
            {
                MusicalBaseEntities2.GetContext().Groups.RemoveRange(GroupsForRemoving);
                MusicalBaseEntities2.GetContext().SaveChanges();
                Tts.ItemsSource = MusicalBaseEntities2.GetContext().Groups.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //группы добавить
            Manager.Frame.Navigate(new AddGroupManagerPage(null));
        }

        private void Tts_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Tts.ItemsSource = MusicalBaseEntities2.GetContext().Groups.ToList();
            }
        }

        private void Tts1_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                //Tts1.ItemsSource = MusicalBaseEntities2.GetContext().Advertisement.Where(p => p.Users.ToString().ToLower().Contains(Convert.ToString(GlobalLeVar.UserIdStat))).ToList();
                Tts1.ItemsSource = MusicalBaseEntities2.GetContext().Advertisement.ToList();
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SearchBox.Text))
            {
                try
                {
                    Tts2.ItemsSource = MusicalBaseEntities2.GetContext().Advertisement.Where(p =>
                    p.Users.Login.ToString().ToLower().Contains(SearchBox.Text.ToLower()) ||
                    p.Areas.Name.ToString().ToLower().Contains(SearchBox.Text.ToLower()) ||
                    p.Groups.Name.ToString().ToLower().Contains(SearchBox.Text.ToLower())).ToList();
                }
                catch
                {
                    MessageBox.Show("Ошибка в получении данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                try
                {
                    Tts2.ItemsSource = MusicalBaseEntities2.GetContext().Advertisement.ToList();
                }
                catch
                {
                    MessageBox.Show("Ошибка в получении данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
