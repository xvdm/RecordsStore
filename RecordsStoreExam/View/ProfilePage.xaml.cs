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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecordsStoreExam.View
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        private User _user;

        private SolidColorBrush _brushDefault = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        private SolidColorBrush _brushSelected = new SolidColorBrush(Color.FromRgb(50, 50, 50));

        public ProfilePage(User user)
        {
            InitializeComponent();
            _user = user;
            Width = SystemParameters.WorkArea.Width;
            Height = SystemParameters.WorkArea.Height - 100;
            CurrentLoginLabel.Content = $"Your login: {_user.Login}";
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Label)sender).Background = _brushSelected;
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Label)sender).Background = _brushDefault;
        }

        private void ChangeLoginLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var changeWindow = new ChangeLoginWindow(_user);
            changeWindow.ShowDialog();
            UpdateUser();
            CurrentLoginLabel.Content = $"Your login: {_user.Login}";
        }

        private void UpdateUser()
        {
            using (MusicStoreContext db = new MusicStoreContext(IContextOptions.Options))
            {
                _user = db.Users.Where(x => x.Id == _user.Id).FirstOrDefault();
            }
        }
    }
}
