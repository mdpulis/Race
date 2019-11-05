using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace EAE.Race.Player
{
    /// <summary>
    /// Represents the player's own UI
    /// </summary>
    public class PlayerUI : MonoBehaviour
    {
        public TextMeshProUGUI TimeText;
        public TextMeshProUGUI MoneyText;

        /// <summary>
        /// Sets the time text
        /// </summary>
        public void SetTimeText(float timePlayed)
        {
            var ss = Convert.ToInt32(timePlayed % 60).ToString("00");
            var mm = (Math.Floor(timePlayed / 60)).ToString("00");
            TimeText.text = "Time: " + mm + ":" + ss;
        }

        /// <summary>
        /// Sets the money text
        /// </summary>
        public void SetMoneyText(int money)
        {
            MoneyText.text = "Gold: " + money.ToString();
        }
    }
}