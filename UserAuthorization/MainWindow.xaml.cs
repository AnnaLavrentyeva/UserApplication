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
using System.Windows.Media.Animation;

namespace UserAuthorization
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0;
            doubleAnimation.To = 450;
            doubleAnimation.Duration = TimeSpan.FromSeconds(3);
            regBut.BeginAnimation(Button.WidthProperty, doubleAnimation);
        }

        private void Button_Registration(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pas = textBoxPassword.Password.Trim();
            string pas2 = textBoxPassword2.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();

            if(login.Length < 5)
            {
                textBoxLogin.ToolTip = "That field is incorrect";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if(pas.Length < 5)
            {
                textBoxPassword.ToolTip = "That field is incorrect";
                textBoxPassword.Background = Brushes.DarkRed;
            }
            else if( pas != pas2)
            {
                textBoxPassword2.ToolTip = "That field is incor";
                textBoxPassword2.Background = Brushes.DarkRed;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "That field is incor";
                textBoxEmail.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                textBoxPassword.ToolTip = "";
                textBoxPassword.Background = Brushes.Transparent;
                textBoxPassword2.ToolTip = "";
                textBoxPassword2.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                User user = new User(login, email, pas);
                db.Users.Add(user);
                db.SaveChanges();

                AuthenticationWindow authWin = new AuthenticationWindow();
                authWin.Show();
                Hide();
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            AuthenticationWindow authWin = new AuthenticationWindow();
            authWin.Show();
            Hide();
        }
    }
}
