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

namespace RecordsStoreExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Width = SystemParameters.WorkArea.Width;
            Height = SystemParameters.WorkArea.Height;
            //this.WindowStyle = WindowStyle.None;
            WindowState = WindowState.Maximized;
            MenuDockPanel.Width = Width;
        }

        private void MenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void MenuItem_MouseMove1(object sender, RoutedEventArgs e)
        {
            
        }

        private void Menu_MouseEnter(object sender, MouseEventArgs e)
        {
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(0,0,0));
            Background = brush;
        }

        private void Menu_MouseLeave(object sender, MouseEventArgs e)
        {
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            Background = brush;
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
            MessageBox.Show("Main");
            frame.Navigate(new MainPage()); // открытие страницы
        }

        private void LabelShop_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Shop");
        }

        private void LabelContacts_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Contacts");
        }

        private void LabelAbout_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("About");
        }

        private void LabelProfile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Profile");
        }
    }
}
