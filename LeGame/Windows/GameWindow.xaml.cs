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

namespace LeGame.Windows
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public Classes.CurrentPlayer thePlayer;
        private Classes.CurrentPlayer _thePlayer;

        public GameWindow(int currentPlayer)
        {
            Classes.CurrentPlayer thePlayer = new Classes.CurrentPlayer();
            InitializeComponent();
            //subscribe a method to be exectued when event is raised <-- doesnt get triggered when loadPlayer gets called? Is it because the reference gets changed? and not the actual ID property??
            thePlayer.IDChanged += new Classes.CurrentPlayer.IDChangedHandler(TargetMethodThatGetsTriggered);
            thePlayer = LoadPlayer(currentPlayer);
            LoadUI(thePlayer);
            MessageBox.Show(thePlayer.playerID.ToString());
        }

        private Classes.CurrentPlayer LoadPlayer(int _id)
        {
            Classes.Connection connection = new Classes.Connection();
            if (connection.LoadPlayerFromDataBase(_id, out _thePlayer))
            {
                return _thePlayer;
            }
            else
            {
                MessageBox.Show("Failed to load player");
                return null;
            }
        }

        private void LoadUI(Classes.CurrentPlayer player)
        {
            healthLabel.Content = player.currentHealth + " / " + player.maxHealth;
            weightLabel.Content = player.maxWeight;        
        }

        public void TargetMethodThatGetsTriggered(int _id)
        {
            MessageBox.Show("Event raised " + _id.ToString());
        }

    }
}
