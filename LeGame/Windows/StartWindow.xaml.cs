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

namespace LeGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        private int id;

        public StartWindow()
        {
            InitializeComponent();
        }

        private void CreateCharacterBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            Classes.Connection connection = new Classes.Connection();
            if (connection.CheckLogin(characterNameTxtBox.Text, passwordPassBox.Password, out id))
            {
                Windows.GameWindow gameWindow = new Windows.GameWindow(id);
                this.Visibility = Visibility.Collapsed;
                gameWindow.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Login failed. Try again");
                return;
            }
        }
    }
}
