using System.Windows;
using System.Windows.Media;

namespace TALsPassworManager
{
    /// <summary>
    /// Interaction logic for AddSocialPassword.xaml
    /// </summary>
    public partial class AddSocialPassword : Window
    {
        string socNetwork;
        public AddSocialPassword()
        {
            InitializeComponent();
            btnCreate.Click += btnCreate_Click;
        }

        public AddSocialPassword(string socNetw, string pass)
        {
            InitializeComponent();

            btnDelete.Visibility = Visibility.Visible;
            btnDelete.IsEnabled = true;
            btnCreate.Content = "Save password Settings";
            Social.Text = socNetw;
            Password.Password = pass;
            btnCreate.Click += BtnCreate_Click2;
            socNetwork = socNetw;
            Window.Title = pass;
        }

        private void BtnCreate_Click2(object sender, RoutedEventArgs e)
        {
            if (socNetwork == Social.Text)
            {
                User.Passwords[socNetwork] = Password.Password;
            }
            else
            {
                User.Passwords.Remove(socNetwork);
                User.Passwords.Add(Social.Text, Password.Password);
            }
            User.SaveToFile();
            Close();
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            User.Passwords.Remove(socNetwork);
            User.SaveToFile();
            Close();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(socNetwork))
            {
                int Mistakes = 0;
                if (Social.Text == "" || Social.Text == "google")
                {
                    Social.Background = Brushes.LightCoral;
                    Social.Text = "google";
                    Mistakes++;
                }

                if (Password.Password == "" || Password.Password == "Password")
                {
                    if (PasswordChecker.ChechPass(Password.Password))
                    {
                        Password.Background = Brushes.LightCoral;
                        Password.Password = "Password";
                        Mistakes++;
                    }
                    else
                    {
                        Password.Background = Brushes.LightCoral;
                        Password.Password = "Password";
                        MessageBox.Show("Your password is too Week, read tutorial and try again");
                        Tutorial tt = new Tutorial();
                        tt.ShowDialog();
                    }
                }
                if (Mistakes == 0)
                {
                    User.Passwords.Add(Social.Text, Password.Password);
                    User.SaveToFile();
                    Close();
                }
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Social_GotFocus(object sender, RoutedEventArgs e)
        {
            Social.Text = "";
        }
        private void Social_GotFocus2(object sender, RoutedEventArgs e)
        {
            Password.Password = "";
        }

    }
}
