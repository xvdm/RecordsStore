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
    /// Логика взаимодействия для ContactsPage.xaml
    /// </summary>
    public partial class ContactsPage : Page
    {
        public ContactsPage()
        {
            InitializeComponent();
            Width = SystemParameters.WorkArea.Width;
            Height = SystemParameters.WorkArea.Height;

            InfoTextBox.Document.Blocks.Clear();
            InfoTextBox.Document.Blocks.Add(new Paragraph(new Run("Контакты")));

            InfoTextBox.Document.Blocks.Add(new Paragraph(new Run("8-800-555-3535\t\tАдрес:\ngmail@gmail.com\t\tг. Одесса улица Садовая, 3")));
            InfoTextBox.Document.Blocks.Add(new Paragraph(new Run("")));
            
        }
    }
}
