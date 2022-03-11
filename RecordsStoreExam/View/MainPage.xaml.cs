using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private int _page = 1;
        private int _totalPages = 0;

        public MainPage()
        {
            InitializeComponent();
            Width = SystemParameters.WorkArea.Width;
            Height = SystemParameters.WorkArea.Height - 100;


            var fullFilePath = @"https://media.discordapp.net/attachments/800002248096481330/944157945032224828/unknown.png?width=617&height=683";
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
            bitmap.EndInit();
            Image1.Source = bitmap;
            Image2.Source = bitmap;
            Image3.Source = bitmap;
            Image4.Source = bitmap;
            Image5.Source = bitmap;
            Image6.Source = bitmap;

            for(int i = 0; i < 30; i++)
            {
                Label label = new Label();
                label.FontSize = 36;
                label.Width = 400;
                label.Height = 60;
                label.HorizontalContentAlignment = HorizontalAlignment.Center;
                label.FontWeight = FontWeights.Bold;
                label.HorizontalAlignment = HorizontalAlignment.Center;
                label.VerticalAlignment= VerticalAlignment.Top;
                label.MouseEnter += Label_MouseEnter;
                label.MouseLeave += Label_MouseLeave;
                label.Content = i;
                DockPanel.SetDock(label, Dock.Top);
                PerformersDockTable.Children.Add(label);
            }
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(70, 70, 70));
            ((Label)sender).Background = brush;
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            SolidColorBrush brush = new SolidColorBrush(Color.FromRgb(99, 99, 99));
            ((Label)sender).Background = brush;
        }

        private void LabelGoTo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Regex regex = new Regex(@"^\d+$"); // digits only
            if(regex.IsMatch(TextBoxGoTo.Text))
            {

            }
            else
            {
                MessageBox.Show("Incorrect input!");
            }
        }

        private void LabelNext_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void LabelPrevious_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
