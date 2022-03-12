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
    /// <summary>
    /// Логика взаимодействия для ChangeLoginWindow.xaml
    /// </summary>
    public partial class ChangeLoginWindow : Window
    {
        private User _user;

        private SolidColorBrush _brushDefault = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        private SolidColorBrush _brushSelected = new SolidColorBrush(Color.FromRgb(50, 50, 50));

        public ChangeLoginWindow(User user)
        {
            InitializeComponent();
            _user = user;
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
            if (LoginTextBox.Text.Length > 0 && LoginTextBox.Text.Trim().Length == LoginTextBox.Text.Length)
            {
                using (MusicStoreContext db = new MusicStoreContext(IContextOptions.Options))
                {
                    db.Users.Where(x => x.Id == _user.Id).First().Login = LoginTextBox.Text.Trim();
                    db.SaveChanges();
                }
            }       
            Close();
        }
    }
}
