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
        private float timePlayed = 0.0f;

        private PlayerUI playerUI;

        private void Awake()
        {
            playerUI = GameObject.FindObjectOfType<PlayerUI>();
        }

        private void Update()
        {
            timePlayed += Time.deltaTime;

            if(playerUI != null)
            {
                playerUI.SetTimeText(timePlayed);
            }
        }


        /// <summary>
        /// Adds money to the player
        /// </summary>
        public void AddMoney(int addedMoney)
        {
            money += addedMoney;
            playerUI.SetMoneyText(money);
        }

        /// <summary>
        /// Gets the amount of money the player has
        /// </summary>
        public int GetMoney()
        {
            return money;
        }

        /// <summary>
        /// Gets the time played
        /// </summary>
        public float GetTimePlayed()
        {
            return timePlayed;
        }

    }
}