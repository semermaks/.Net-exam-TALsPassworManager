using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

namespace TALsPassworManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader(TbName.Text))
                {
                    User.Login = TbName.Text;
                    string[] str = (Decrypt(sr.ReadLine())).Split(' ');
                    if (str[4] == PbPassword.Password/* + '\n'*/)
                    {
                        User.Name = str[0];
                        User.Surname = str[1];
                        User.FatherName = str[2];
                        User.DateOFBirthday = DateTime.Parse(str[3]);
                        User.Password = str[4];
                        while (!sr.EndOfStream)
                        {
                            str = (Decrypt(sr.ReadLine())).Split(' ');
                            User.Passwords.Add(str[0], str[1]);
                        }
                        PasswordsWindow pw = new PasswordsWindow();
                        pw.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Password wrong, try again.", "Password error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Login not found, try again.", "Login error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Info Eror: {ex.Message}", "Reading error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Tutorial tut = new Tutorial();
            tut.ShowDialog();
            RegisterWindow regWin = new RegisterWindow();
            regWin.ShowDialog();
        }

        private void TbName_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                PbPassword.Password = "";
                PbPassword.Focus();
            }
        }

        private void PbPassword_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            btnLogin.Focus();
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
        private const int Keysize = 256;
        private const int DerivationIterations = 1000;
        public static string Decrypt(string cipherText, string passPhrase = "TALs The Best Programm")
        {
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }
    }
}
