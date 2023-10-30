using System.Windows;
using System.Windows.Input;

namespace TALsPassworManager
{
    /// <summary>
    /// Interaction logic for PasswordsWindow.xaml
    /// </summary>
    public partial class PasswordsWindow : Window
    {
        public PasswordsWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Lbox.Items.Clear();
            foreach (var password in User.Passwords)
            {
                Lbox.Items.Add($"{password.Key}, Password({password.Value.Length} sym).");
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            AddSocialPassword socialPassword = new AddSocialPassword();
            socialPassword.ShowDialog();
            Grid_Loaded(sender, e);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnUserData_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow reg = new RegisterWindow(12);
            reg.ShowDialog();
        }

        private void Lbox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string key = Lbox.SelectedItem.ToString().Split(',')[0];
            foreach (var password in User.Passwords)
            {
                if (password.Key == key)
                {
                    AddSocialPassword addSocialPassword = new AddSocialPassword(password.Key, password.Value);
                    addSocialPassword.ShowDialog();
                    Grid_Loaded(sender, e);
                    return;
                }
            }
        }
    }
}
