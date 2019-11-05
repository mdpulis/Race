using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EAE.Race.Player
{
    /// <summary>
    /// Holds all player data such as time played and points
    /// </summary>
    public class PlayerData : MonoBehaviour
    {
        private int money = 0;


        /// <summary>
        /// Adds money to the player
        /// </summary>
        public void AddMoney(int addedMoney)
        {
            money += addedMoney;
        }

        /// <summary>
        /// Gets the amount of money the player has
        /// </summary>
        public int GetMoney()
        {
            return money;
        }

    }
}