using RecordsStoreExam.Model;
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
using System.Windows.Shapes;

namespace RecordsStoreExam.View
{
    public partial class PurchaseWindow : Window
    {
        private Record _record;
        private string _bandName;
        private User _user;

        private SolidColorBrush _brushDefault = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        private SolidColorBrush _brushSelected = new SolidColorBrush(Color.FromRgb(50, 50, 50));

        public PurchaseWindow(Record record, string bandName, User user)
        {
            InitializeComponent();
            _record = record;
            _bandName = bandName;
            _user = user;
            AddRecordToStackPanel();
        }

        private void AddRecordToStackPanel()
        {
            if (_record != null)
            {
                var image = new Image();
                image.Width = 600;
                image.Height = 600;
                image.Source = GetBitmapForImage(_record.PhotoUri);

                var label1 = new Label();
                label1.Content = $"{_bandName}";
                label1.FontSize = 30;
                label1.FontWeight = FontWeights.Bold;
                label1.HorizontalAlignment = HorizontalAlignment.Center;

                var label2 = new Label();
                label2.Content = $"'{_record.Name}'";
                label2.FontSize = 30;
                label2.FontWeight = FontWeights.Bold;
                label2.HorizontalAlignment = HorizontalAlignment.Center;

                var label3 = new Label();
                label3.Content = $"{_record.PublishingYear} / {_record.TracksAmount} tracks";
                label3.FontSize = 20;
                label3.FontWeight = FontWeights.Bold;
                label3.HorizontalAlignment = HorizontalAlignment.Center;

                var label4 = new Label();
                label4.Content = ((int)_record.Price) + " uah";
                label4.FontSize = 20;
                label4.FontWeight = FontWeights.Bold;
                label4.HorizontalAlignment = HorizontalAlignment.Center;

                var label5 = new Label();
                label5.Content = "Buy";
                label5.FontSize = 30;
                label5.FontWeight = FontWeights.Bold;
                label5.HorizontalAlignment = HorizontalAlignment.Center;
                label5.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                label5.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                label5.Width = 200;
                label5.Height = 100;
                label5.VerticalContentAlignment = VerticalAlignment.Center;
                label5.HorizontalContentAlignment = HorizontalAlignment.Center;
                label5.MouseEnter += Label_MouseEnter;
                label5.MouseLeave += Label_MouseLeave;
                label5.MouseDown += Label_MouseDown;

                var stackPanel = new StackPanel();
                stackPanel.Children.Add(image);
                stackPanel.Children.Add(label1);
                stackPanel.Children.Add(label2);
                stackPanel.Children.Add(label3);
                stackPanel.Children.Add(label4);
                stackPanel.Children.Add(label5);
                

                Grid.SetColumn(stackPanel, 0);
                Grid.SetRow(stackPanel, 0);

                MainDockPanel.Children.Add(stackPanel);
            }
        }

        private BitmapImage GetBitmapForImage(string url)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(url, UriKind.Absolute);
            bitmap.EndInit();
            return bitmap;
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Label)sender).Background = _brushSelected;
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Label)sender).Background = _brushDefault;
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            using(MusicStoreContext db = new MusicStoreContext(IContextOptions.Options))
            {
                Sale sale = new Sale();
                sale.IdRecord = _record.Id;
                sale.IdUser = _user.Id;
                sale.DateOfSale = DateTime.Now;
                db.Sales.Add(sale);
                db.SaveChanges();
            }
            MessageBox.Show("Successfully purchased");
            Close();
        }
    }
}
