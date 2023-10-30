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

namespace TALsPassworManager
{
    /// <summary>
    /// Interaction logic for Tutorial.xaml
    /// </summary>
    public partial class Tutorial : Window
    {
        public Tutorial()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            tb.Text = "Before you create an account in our program, we want to tell you how to create\npasswords correctly:\n\n" + "* Passwords must be long(at least 10 characters), must contain capital letters, numbers\nand various symbols\n\n" + "* Never use your personal data(First name, last name, age...) when creating a password\n\n" + "* The password should not have a pattern.\n\n" + "* This program will Teach you, Analyze and Store your passwords Locally.\n\n";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
