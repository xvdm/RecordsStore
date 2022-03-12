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
using RecordsStoreExam.Model;
using RecordsStoreExam.View;

namespace RecordsStoreExam
{

    

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IContextOptions
    {
        private User _user { get; set; }

        public MainWindow(User user)
        {
            _user = user;
            InitializeComponent();
            Width = SystemParameters.WorkArea.Width;
            Height = SystemParameters.WorkArea.Height;
            WindowStyle = WindowStyle.None;
            WindowState = WindowState.Maximized;
            MenuDockPanel.Width = Width;
            LabelProfile.Content = _user.Login;

            if (_user.IsAdmin == true)
            {
                frame.Navigate(new AdminMainPage());
            }
            else
            {
                frame.Navigate(new MainPage(_user));
            }
        }

        private void MenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void MenuItem_MouseMove1(object sender, RoutedEventArgs e)
        {
            
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(30, 30, 30));
            ((Label)sender).Background = brush;
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            ((Label)sender).Background = brush;
        }

        private void LabelMain_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_user.IsAdmin == true)
            {
                frame.Navigate(new AdminMainPage());
            }
            else
            {
                frame.Navigate(new MainPage(_user));
            }
        }

        private void LabelContacts_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_user.IsAdmin == true)
            {
                frame.Navigate(new AdminContactsPage());
            }
            else
            {
                frame.Navigate(new ContactsPage());
            }
        }

        private void LabelAbout_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_user.IsAdmin == true)
            {
                frame.Navigate(new AdminAboutPage());
            }
            else
            {
                frame.Navigate(new AboutPage());
            }
        }

        private void LabelProfile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            frame.Navigate(new ProfilePage());
        }
    }
}
