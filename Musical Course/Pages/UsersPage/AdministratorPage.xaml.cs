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
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Musical_Course
{
    /// <summary>
    /// Логика взаимодействия для AdministratorPage.xaml
    /// </summary>
    public partial class AdministratorPage : Page
    {
        private MusicalBaseEntities2 _contextS = new MusicalBaseEntities2();
        public AdministratorPage()
        {
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
            UsersGrid.Visibility = Visibility.Hidden;
            GroupGrid.Visibility = Visibility.Hidden;
            AreaGrid.Visibility = Visibility.Hidden;
            AutorisationHistoryGrid.Visibility = Visibility.Hidden;
            RegistrationHistoryGrid.Visibility = Visibility.Hidden;
            //Бд
            Tts.ItemsSource = MusicalBaseEntities2.GetContext().Advertisement.ToList();
            Tts1.ItemsSource = MusicalBaseEntities2.GetContext().Users.ToList();
            Tts2.ItemsSource = MusicalBaseEntities2.GetContext().Groups.ToList();
            Tts3.ItemsSource = MusicalBaseEntities2.GetContext().Areas.ToList();
            Tts4.ItemsSource = MusicalBaseEntities2.GetContext().AutorisationHistory.ToList();
            Tts5.ItemsSource = MusicalBaseEntities2.GetContext().Users.ToList();
            //Диаграмма

            ChartPayments.ChartAreas.Add(new ChartArea("Main"));

            var currentSeries = new Series("Количество объявлений")
            {
                IsValueShownAsLabel = true
            };
            ChartPayments.Series.Add(currentSeries);
            //ComboUsers.ItemsSource = _contextS.Users.ToList();
            ComboChartTypes.ItemsSource = Enum.GetValues(typeof(SeriesChartType));


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
                tt_maps.Visibility = Visibility.Collapsed;
                tt_settings.Visibility = Visibility.Collapsed;
                tt_signout.Visibility = Visibility.Collapsed;
                tt_nout.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_ome.Visibility = Visibility.Visible;
                tt_home.Visibility = Visibility.Visible;
                tt_contacts.Visibility = Visibility.Visible;
                tt_messages.Visibility = Visibility.Visible;
                tt_maps.Visibility = Visibility.Visible;
                tt_settings.Visibility = Visibility.Visible;
                tt_signout.Visibility = Visibility.Visible;
                tt_nout.Visibility = Visibility.Visible;
            }
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 0.3;
        }

        private void Panel0_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PreviewGrid.Visibility = Visibility.Visible;
            AdvertisementGrid.Visibility = Visibility.Hidden;
            UsersGrid.Visibility = Visibility.Hidden;
            GroupGrid.Visibility = Visibility.Hidden;
            AreaGrid.Visibility = Visibility.Hidden;
            AutorisationHistoryGrid.Visibility = Visibility.Hidden;
            RegistrationHistoryGrid.Visibility = Visibility.Hidden;
        }

        private void Panel7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PreviewGrid.Visibility = Visibility.Hidden;
            AdvertisementGrid.Visibility = Visibility.Hidden;
            UsersGrid.Visibility = Visibility.Hidden;
            GroupGrid.Visibility = Visibility.Hidden;
            AreaGrid.Visibility = Visibility.Hidden;
            AutorisationHistoryGrid.Visibility = Visibility.Hidden;
            RegistrationHistoryGrid.Visibility = Visibility.Hidden;
            Manager.Frame.Navigate(new AutorisationPage());
        }

        private void Panel6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PreviewGrid.Visibility = Visibility.Hidden;
            AdvertisementGrid.Visibility = Visibility.Hidden;
            UsersGrid.Visibility = Visibility.Hidden;
            GroupGrid.Visibility = Visibility.Hidden;
            AreaGrid.Visibility = Visibility.Hidden;
            AutorisationHistoryGrid.Visibility = Visibility.Hidden;
            RegistrationHistoryGrid.Visibility = Visibility.Visible;
        }

        private void Panel5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PreviewGrid.Visibility = Visibility.Hidden;
            AdvertisementGrid.Visibility = Visibility.Hidden;
            UsersGrid.Visibility = Visibility.Hidden;
            GroupGrid.Visibility = Visibility.Hidden;
            AreaGrid.Visibility = Visibility.Hidden;
            AutorisationHistoryGrid.Visibility = Visibility.Visible;
            RegistrationHistoryGrid.Visibility = Visibility.Hidden;
        }

        private void Panel4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PreviewGrid.Visibility = Visibility.Hidden;
            AdvertisementGrid.Visibility = Visibility.Hidden;
            UsersGrid.Visibility = Visibility.Hidden;
            GroupGrid.Visibility = Visibility.Hidden;
            AreaGrid.Visibility = Visibility.Visible;
            AutorisationHistoryGrid.Visibility = Visibility.Hidden;
            RegistrationHistoryGrid.Visibility = Visibility.Hidden;
        }

        private void Panel3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PreviewGrid.Visibility = Visibility.Hidden;
            AdvertisementGrid.Visibility = Visibility.Hidden;
            UsersGrid.Visibility = Visibility.Hidden;
            GroupGrid.Visibility = Visibility.Visible;
            AreaGrid.Visibility = Visibility.Hidden;
            AutorisationHistoryGrid.Visibility = Visibility.Hidden;
            RegistrationHistoryGrid.Visibility = Visibility.Hidden;
        }

        private void Panel2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PreviewGrid.Visibility = Visibility.Hidden;
            AdvertisementGrid.Visibility = Visibility.Hidden;
            UsersGrid.Visibility = Visibility.Visible;
            GroupGrid.Visibility = Visibility.Hidden;
            AreaGrid.Visibility = Visibility.Hidden;
            AutorisationHistoryGrid.Visibility = Visibility.Hidden;
            RegistrationHistoryGrid.Visibility = Visibility.Hidden;
        }

        private void Panel1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PreviewGrid.Visibility = Visibility.Hidden;
            AdvertisementGrid.Visibility = Visibility.Visible;
            UsersGrid.Visibility = Visibility.Hidden;
            GroupGrid.Visibility = Visibility.Hidden;
            AreaGrid.Visibility = Visibility.Hidden;
            AutorisationHistoryGrid.Visibility = Visibility.Hidden;
            RegistrationHistoryGrid.Visibility = Visibility.Hidden;
        }
        private void Tts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*Tts.ItemsSource = MusicalBaseEntities2.GetContext().Advertisement.ToArray();
            MusicalBaseEntities2.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());*/
        }

        private void BtnAddGroup_Click(object sender, RoutedEventArgs e)
        {
            //Manager.Frame.Navigate(new AddGroupManagerPage());
        }

        private void BtnEditGroup_Click(object sender, RoutedEventArgs e)
        {
            //Manager.Frame.Navigate(new EditGroupManagerPage());
        }
        private void BtnDeleteGroup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddAds_Click(object sender, RoutedEventArgs e)
        {
            //Manager.Frame.Navigate(new AddAdsPage(null));
        }
        private void BtnDeleteAds_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditAds_Click(object sender, RoutedEventArgs e)
        {
            //Объявления
            Manager.Frame.Navigate(new ModerAdvPage((sender as Button).DataContext as Advertisement));
        }

        private void BtnEditUser_Click(object sender, RoutedEventArgs e)
        {
            Manager.Frame.Navigate(new AddUserPage((sender as Button).DataContext as Users));
        }

        private void Tts1_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                //Tts1.ItemsSource = MusicalBaseEntities.GetContext().Users.ToArray();
                MusicalBaseEntities2.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            }
        }

        private void Tts_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                //Tts1.ItemsSource = MusicalBaseEntities.GetContext().Users.ToArray();
                MusicalBaseEntities2.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            }
        }

        private void UpdateChart(object sender, SelectionChangedEventArgs e)
        {
            if (ComboChartTypes.SelectedItem is SeriesChartType currentType)
            {
                Series CurrentSeries = ChartPayments.Series.FirstOrDefault();
                CurrentSeries.ChartType = currentType;
                CurrentSeries.Points.Clear();

                var categoriesList = _contextS.Users.ToList();
                foreach(var category in categoriesList)
                {
                    CurrentSeries.Points.AddXY(category.Login, category.CountAdvertisement);
                }
            }
        }
    }
        
}
