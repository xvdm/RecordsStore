using Microsoft.EntityFrameworkCore;
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

namespace RecordsStoreExam
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window, IContextOptions
    {
        public LoginWindow()
        {
            InitializeComponent();
            IContextOptions.Configure();
            using (MusicStoreContext db = new MusicStoreContext(IContextOptions.Options)) 
            { 
                if(db.Users.FirstOrDefault() != null) { } // открываю соединение с базой данных, чтобы при первом
                                                          // нажатии на "sign in" или "sign up" она не тормозила
            }
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            using (MusicStoreContext db = new MusicStoreContext(IContextOptions.Options))
            {
                var user = db.Users.ToArray().FirstOrDefault(x => x.Login == LoginTextBox.Text && x.PasswordHash == CalculateHash(PasswordTextBox.Password).ToString());
                if (user != null)
                {
                    var mainWindow = new MainWindow(user);
                    Close();
                    mainWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wrong login");
                }
            }
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text.Trim() == "" || PasswordTextBox.Password.Trim() == "")
            {
                MessageBox.Show("Empty fields");
            }
            else
            {
                using (MusicStoreContext db = new MusicStoreContext(IContextOptions.Options))
                {
                    if(db.Users.ToArray().FirstOrDefault(x => x.Login == LoginTextBox.Text) == null)
                    {
                        User user = new User();
                        user.Login = LoginTextBox.Text;
                        user.IsAdmin = false;
                        user.PasswordHash = CalculateHash(PasswordTextBox.Password).ToString();
                        db.Users.Add(user);
                        db.SaveChanges();
                        MessageBox.Show("Signed up");
                    }
                    else
                    {
                        MessageBox.Show("Such login already exists");
                    }
                }
            } 
        }

        private static UInt64 CalculateHash(string read)
        {
            UInt64 hashedValue = 3074457345618258791ul;
            for (int i = 0; i < read.Length; i++)
            {
                hashedValue += read[i];
                hashedValue *= 3074457345618258799ul;
            }
            return hashedValue;
        }
    }
}
