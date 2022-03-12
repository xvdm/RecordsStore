using Microsoft.EntityFrameworkCore;
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
    public partial class MainPage : Page
    {
        private int _page = 0;
        private int _totalPages = 0;
        private const int _recordsOnPage = 6;

        private List<Performer> _performers = new();
        private List<SortingOption> _sortingOptions = new();

        private SolidColorBrush _brushDefault = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        private SolidColorBrush _brushSelected = new SolidColorBrush(Color.FromRgb(200, 200, 200));

        private readonly List<Record> _allRecordsList = new();
        private List<Record> _currentRecordsPerformerList = new();
        private List<Record> _currentRecordsList = new();
        private List<Band> _bandsList = new();

        public MainPage()
        {
            InitializeComponent();
            Width = SystemParameters.WorkArea.Width;
            Height = SystemParameters.WorkArea.Height - 100;

            FillSortingOptions();
            using (MusicStoreContext db = new MusicStoreContext(IContextOptions.Options))
            {  
                _allRecordsList = db.Records.ToList();
                _currentRecordsPerformerList = _allRecordsList;
                _currentRecordsList = _currentRecordsPerformerList;
                _bandsList = db.Bands.ToList();

                foreach (var band in _bandsList)
                {
                    AddPerformerToSortingList(band.Name);
                }
            }
            UpdateRecordsContent();
        }

        private void FillSortingOptions()
        {
            foreach(var x in SortingDockPanel.Children)
            {
                _sortingOptions.Add(new SortingOption((Label)x, false));
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
                stackPanel.MouseEnter += StackPanel_MouseEnter;
                stackPanel.MouseLeave += StackPanel_MouseLeave;
                stackPanel.MouseDown += StackPanel_MouseDown;

                Grid.SetColumn(stackPanel, column);
                Grid.SetRow(stackPanel, row);

                GridRecords.Children.Add(stackPanel);

                if (++column == 3)
                {
                    column = 0;
                    row++;
                }
            }
        }

        private void UpdateRecordsContent()
        {
            ApplySortingOptions();
            int column = 0;
            int row = 0;
            GridRecords.Children.Clear();
            foreach (var record in _currentRecordsList.Skip(_page * _recordsOnPage).Take(_recordsOnPage))
            {
                AddRecordToStackPanel(record, column, row);
                if (++column == 3)
                {
                    column = 0;
                    row++;
                }
            }
            _totalPages = _currentRecordsList.Count() / _recordsOnPage;
            LabelTotal.Content = $"Pages: 0-{_totalPages}";
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

        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            ((StackPanel)sender).Background = _brushSelected;
        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            ((StackPanel)sender).Background = _brushDefault;
        }

        private void StackPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ((StackPanel)sender).Background = _brushSelected;
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
                    int id = _bandsList.Where(y => y.Name == x.Label.Content.ToString()).First().Id;
                    _currentRecordsPerformerList = _allRecordsList;
                    _currentRecordsPerformerList = _currentRecordsPerformerList.Where(x => x.IdBand == id).ToList();
                    _currentRecordsList = _currentRecordsPerformerList;
                    UpdateRecordsContent();
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
            if (_sortingOptions.Find(x => x.Label == ((Label)sender)).IsSelected == false)
            {
                ((Label)sender).Background = _brushDefault;
            }
        }

        private void LabelSorting_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (var x in _sortingOptions)
            {
                x.IsSelected = false;
                x.Label.Background = _brushDefault;
                if (x.Label == ((Label)sender))
                {
                    x.IsSelected = true;
                    x.Label.Background = _brushSelected;
                }
            }
            _currentRecordsList = _currentRecordsPerformerList;
            UpdateRecordsContent();
            LabelCurrent.Content = $"Current page: {_page}";
        }

        private void ApplySortingOptions()
        {
            foreach (var x in _sortingOptions)
            {
                if (x.IsSelected == true)
                {
                    if (x.Label.Name.ToString() == "LabelSortNameAsc")
                    {
                        _currentRecordsList.Sort((x, y) => x.Name.CompareTo(y.Name));
                    }
                    else if (x.Label.Name.ToString() == "LabelSortNameDesc")
                    {
                        _currentRecordsList.Sort((x, y) => y.Name.CompareTo(x.Name));
                    }
                    else if (x.Label.Name.ToString() == "LabelSortPriceAsc")
                    {
                        _currentRecordsList.Sort((x, y) => x.Price.CompareTo(y.Price));
                    }
                    else if (x.Label.Name.ToString() == "LabelSortPriceDesc")
                    {
                        _currentRecordsList.Sort((x, y) => y.Price.CompareTo(x.Price));
                    }
                    break;
                }
            }
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
    }
}
