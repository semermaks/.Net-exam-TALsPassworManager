using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace TALsPassworManager
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }
        public RegisterWindow(int newAcc)
        {
            InitializeComponent();

            TbLogin.Text = User.Login;
            Password.Password = User.Password;
            TbName.Text = User.Name;
            TbSurname.Text = User.Surname;
            TbFatherName.Text = User.FatherName;
            DateOFBirth.DisplayDate = User.DateOFBirthday;
            btn.Content = "Save Changes";
            TbLogin.IsEnabled = false;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int Mistakes = 0;
            if (TbName.Text == "" || TbName.Text == "Name")
            {
                TbName.Background = Brushes.LightCoral;
                TbName.Text = "Name";
                Mistakes++;
                TbName.Focus();
            }
            if (TbSurname.Text == "" || TbSurname.Text == "Surname")
            {
                TbSurname.Background = Brushes.LightCoral;
                TbSurname.Text = "Surname";
                Mistakes++;
                if (Mistakes == 0) TbSurname.Focus();
            }
            if (TbFatherName.Text == "" || TbFatherName.Text == "Father name")
            {
                TbFatherName.Background = Brushes.LightCoral;
                TbFatherName.Text = "Father name";
                Mistakes++;
                if (Mistakes == 0) TbFatherName.Focus();
            }
            if (DateOFBirth.DisplayDate.Year >= DateTime.Now.Year || DateOFBirth.DisplayDate == null)
            {
                DateOFBirth.Background = Brushes.LightCoral;
                Mistakes++;
                if (Mistakes == 0) DateOFBirth.Focus();
            }
            if (TbLogin.Text == "" || TbLogin.Text == "Login")
            {
                TbLogin.Background = Brushes.LightCoral;
                TbLogin.Text = "Login";
                Mistakes++;
                if (Mistakes == 0) TbLogin.Focus();
            }
            if (Password.Password == "" || Password.Password == "Password")
            {
                Password.Background = Brushes.LightCoral;
                Password.Password = "Password";
                Mistakes++;
                if (Mistakes == 0) Password.Focus();
            }
            if (Mistakes == 0)
            {
                User.Login = TbLogin.Text;
                User.Password = Password.Password;
                User.Name = TbName.Text;
                User.Surname = TbSurname.Text;
                User.FatherName = TbFatherName.Text;
                User.DateOFBirthday = DateOFBirth.DisplayDate;
                if (ChackLogin())
                {
                    if (PasswordChecker.ChechPass(User.Password))
                    {
                        WriteToFile();
                        Close();
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
            }
        }

        private bool ChackLogin()
        {
            bool IsUnique = true;
            try
            {
                using (StreamReader sr = new StreamReader(TbLogin.Text))
                {

                }
            }
            catch (FileNotFoundException ex)
            {
            }
            return IsUnique;
        }

        private void WriteToFile()
        {
            User.SaveToFile();
        }

        private void TbName_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TbSurname.Focus();
                TbSurname.Text = "";
            }
        }

        private void TbSurname_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TbFatherName.Focus();
                TbFatherName.Text = "";
            }
        }

        private void TbFatherName_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TraversalRequest tr = new TraversalRequest(FocusNavigationDirection.Next);
                (sender as TextBox).MoveFocus(tr);
            }
        }

        private void DateOFBirth_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TbLogin.Focus();
                TbLogin.Text = "";
            }
        }

        private void TbLogin_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Password.Focus();
                Password.Password = "";
            }
        }

        private void Password_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            btn.Focus();
        }

        private void TbName_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is TextBox) (sender as TextBox).Text = "";
                else if (sender is PasswordBox) (sender as PasswordBox).Password = "";
            }
            catch
            {
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}