using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LeGame.Classes
{
    public class CurrentPlayer
    {
            //Create a delegate
        public delegate void IDChangedHandler(int _id);
            //Create the event referencing the delegate
        public event IDChangedHandler IDChanged;

        public string characterName { get; set; }

        public int currentHealth { get; set; }
        public int maxHealth { get; set; }
        public int maxWeight { get; set; }
        public int strenght { get; set; }
        public int improvisation { get; set; }
        public int speed { get; set; }
        public int intelligence { get; set; }

        public int equippedWeapon { get; set; }

            //Logic for handeling all the Player loading
        private int _playerID;
            //Raises an event that the playerID property has been changed.
        public int playerID
        {
            get { return _playerID; }
            set
            {
                _playerID = value;
                //Raise an event when the playerID gets changed
                if (IDChanged != null)
                {
                    this.IDChanged(_playerID);

                }
            }
        }
    }   
}
