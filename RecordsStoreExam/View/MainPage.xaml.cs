using Microsoft.Win32;
using RecordsStoreExam.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private int _page = 0;


        private int _totalPages = 0;
        private int _recordsOnPage = 6;
        private List<Performer> _performers = new List<Performer>();
        private SolidColorBrush _brushDefault = new SolidColorBrush(Color.FromRgb(99, 99, 99));
        private SolidColorBrush _brushSelected = new SolidColorBrush(Color.FromRgb(70, 70, 70));

        public MainPage()
        {
            InitializeComponent();
            Width = SystemParameters.WorkArea.Width;
            Height = SystemParameters.WorkArea.Height - 100;
            

            UpdateRecordsContent();
            using (MusicStoreContext db = new MusicStoreContext(IContextOptions.Options))
            {
                foreach (var band in db.Bands)
                {
                    AddPerformerToSortingList(band.Name);
                }
            }
        }

        private void AddRecordToStackPanel(Record record, int column, int row)
        {
            if (record != null)
            {
                var image = new Image();
                image.Width = 250;
                image.Height = 250;
                image.Source = GetBitmapForImage(record.PhotoUri);

                var label1 = new Label();
                label1.Content = record.Name;
                label1.FontSize = 26;
                label1.FontWeight = FontWeights.Bold;
                label1.HorizontalAlignment = HorizontalAlignment.Center;

                var label2 = new Label();
                label2.Content = ((int)record.Price) + " uah";
                label2.FontSize = 20;
                label2.FontWeight = FontWeights.Bold;
                label2.HorizontalAlignment = HorizontalAlignment.Center;

                var stackPanel = new StackPanel();
                stackPanel.Children.Add(image);
                stackPanel.Children.Add(label1);
                stackPanel.Children.Add(label2);

                Grid.SetColumn(stackPanel, column);
                Grid.SetRow(stackPanel, row);

                GridRecords.Children.Add(stackPanel);

                column++;
                if (column == 3)
                {
                    column = 0;
                    row++;
                }
            }
        }

        private void UpdateRecordsContent(string performer = null)
        {
            using (MusicStoreContext db = new MusicStoreContext(IContextOptions.Options)) { 
                int column = 0;
                int row = 0;
                int id;
                GridRecords.Children.Clear();
                if (performer == null)
                {
                    foreach (var record in db.Records.Skip(_page * _recordsOnPage).Take(_recordsOnPage))
                    {
                        AddRecordToStackPanel(record, column, row);

                        column++;
                        if (column == 3)
                        {
                            column = 0;
                            row++;
                        }
                    }
                    _totalPages = db.Records.Count() / _recordsOnPage;
                }
                else
                {
                    id = db.Bands.Where(x => x.Name == performer).First().Id;
                    foreach (var record in db.Records.Where(x => x.IdBand == id).Skip(_page * _recordsOnPage).Take(_recordsOnPage))
                    {
                        AddRecordToStackPanel(record, column, row);

                        column++;
                        if (column == 3)
                        {
                            column = 0;
                            row++;
                        }
                    }
                    _totalPages = db.Records.Where(x => x.IdBand == id).Count() / _recordsOnPage;
                }

                LabelTotal.Content = $"Total pages: 0-{_totalPages}";
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

        private void AddPerformerToSortingList(string name)
        {
            Label label = new Label();
            label.FontSize = 30;
            label.Width = 400;
            label.Height = 60;
            label.HorizontalContentAlignment = HorizontalAlignment.Center;
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = VerticalAlignment.Top;
            label.MouseEnter += LabelPerformer_MouseEnter;
            label.MouseLeave += LabelPerformer_MouseLeave;
            label.MouseDown += LabelPerformer_MouseDown;
            label.Content = name;
            DockPanel.SetDock(label, Dock.Top);
            _performers.Add(new Performer(label, false));
            PerformersDockTable.Children.Add(label);
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Label)sender).Background = _brushSelected;
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Label)sender).Background = _brushDefault;
        }

        private void Label_MouseDown(object sender, MouseEventArgs e)
        {
            ((Label)sender).Background = _brushSelected;
        }

        private void LabelPerformer_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Label)sender).Background = _brushSelected;
        }

        private void LabelPerformer_MouseLeave(object sender, MouseEventArgs e)
        {
            if (_performers.Find(x => x.Label == ((Label)sender)).IsSelected == false)
            {
                ((Label)sender).Background = _brushDefault;
            }
        }

        private void LabelPerformer_MouseDown(object sender, MouseEventArgs e)
        {
            ((Label)sender).Background = _brushSelected;
            _page = 0;

            foreach (var x in _performers)
            {
                x.IsSelected = false;
                x.Label.Background = _brushDefault;
                if (x.Label == ((Label)sender))
                {
                    x.IsSelected = true;
                    x.Label.Background = _brushSelected;
                    UpdateRecordsContent(x.Label.Content.ToString());
                    LabelCurrent.Content = $"Current page: {_page}";
                }
            }
        }

        private void LabelSorting_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Label)sender).Background = _brushSelected;
        }

        private void LabelSorting_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Label)sender).Background = _brushDefault;
        }

        private void LabelSorting_MouseDown(object sender, MouseEventArgs e)
        {
            ((Label)sender).Background = _brushSelected;
        }

        private void LabelGoTo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Regex regex = new Regex(@"^\d+$"); // digits only
            if(regex.IsMatch(TextBoxGoTo.Text))
            {
                if(int.Parse(TextBoxGoTo.Text) >= 0 && int.Parse(TextBoxGoTo.Text) <= _totalPages)
                {
                    _page = int.Parse(TextBoxGoTo.Text);
                    UpdateRecordsContent();
                    LabelCurrent.Content = $"Current page: {_page}";
                }
            }
            else
            {
                MessageBox.Show("Incorrect input!");
            }
        }

        private void LabelNext_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_page < _totalPages)
            {
                _page++;
                UpdateRecordsContent();
                LabelCurrent.Content = $"Current page: {_page}";
            }
        }

        private void LabelPrevious_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_page > 0)
            {
                _page--;
                UpdateRecordsContent();
                LabelCurrent.Content = $"Current page: {_page}";
            } 
        }

        private void LabelSorting_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(((Label)sender).Name.ToString() == "LabelSortNameAsc")
            {

            }
            else if (((Label)sender).Name.ToString() == "LabelSortNameDesc")
            {

            }
            else if (((Label)sender).Name.ToString() == "LabelSortPriceAsc")
            {

            }
            else if (((Label)sender).Name.ToString() == "LabelSortPriceDesc")
            {

            }
        }
    }
}
