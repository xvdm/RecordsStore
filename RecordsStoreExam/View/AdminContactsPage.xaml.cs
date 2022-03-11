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

namespace RecordsStoreExam.View
{
    /// <summary>
    /// Логика взаимодействия для AdminContactsPage.xaml
    /// </summary>
    public partial class AdminContactsPage : Page
    {
        public AdminContactsPage()
        {
            InitializeComponent();
            Width = SystemParameters.WorkArea.Width;
            Height = SystemParameters.WorkArea.Height - 100;
        }
    }
}
