using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGame.Classes
{
    public class Connection
    {
        public bool CheckLogin(string _charName, string _pass, out int _id)
        {
            //Connect to the database using EntityFramework
            using (DBEntity.GameDataBase data = new DBEntity.GameDataBase())
            {
                //Selecting the player from the database that matches the charactername and password provided by the user
                DBEntity.Player loggedPlayer = data.Players.FirstOrDefault(p => p.CharacterName == _charName && p.Password == _pass);
                if (loggedPlayer != null)
                {
                    _id = loggedPlayer.ID;
                    data.Dispose();
                    return true;
                }
                else
                {
                    _id = 0;
                    data.Dispose();
                    return false;
                }
            }
        }

        public bool LoadPlayerFromDataBase(int playerID, out CurrentPlayer currentPlayer)
        {
            using (DBEntity.GameDataBase loadFromThis = new DBEntity.GameDataBase())
            {
                DBEntity.Player loadedPlayer = loadFromThis.Players.FirstOrDefault(p => p.ID == playerID);
                if (loadedPlayer != null)
                {
                    Classes.CurrentPlayer updatedPlayer = new CurrentPlayer();
                    updatedPlayer.playerID = loadedPlayer.ID;
                    updatedPlayer.currentHealth = loadedPlayer.CurrentHP;
                    updatedPlayer.maxHealth = loadedPlayer.MaxHP;
                    updatedPlayer.maxWeight = loadedPlayer.MaxWeight;
                    updatedPlayer.strenght = loadedPlayer.Strenght;
                    updatedPlayer.improvisation = loadedPlayer.Improvisation;
                    updatedPlayer.speed = loadedPlayer.Speed;
                    updatedPlayer.intelligence = loadedPlayer.Intelligence;
                    updatedPlayer.characterName = loadedPlayer.CharacterName;
                    currentPlayer = updatedPlayer;
                    return true;
                }
                else
                {
                    CurrentPlayer failed = new CurrentPlayer();
                    currentPlayer = failed;
                    return false;
                }
            }
        }


        public bool ConnectInventory()
        {
            return true;
        }
    }
}
