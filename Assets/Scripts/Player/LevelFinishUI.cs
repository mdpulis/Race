using EAE.Race.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EAE.Race.Player
{
    /// <summary>
    /// The UI screen that appears when finishing a level
    /// </summary>
    public class LevelFinishUI : MonoBehaviour
    {
        private LoadingScreenManager loadingScreenManager;
        private PlayerData playerData;

        private void Awake()
        {
            loadingScreenManager = GameObject.FindObjectOfType<LoadingScreenManager>();
            playerData = GameObject.FindObjectOfType<PlayerData>();
        }

        /// <summary>
        /// Resets the player back to the beginning of the level
        /// </summary>
        public void RetryLevel()
        {
            playerData.ResetPlayerData();
        }


        /// <summary>
        /// Returns the player to the main menu
        /// </summary>
        public void ReturnToMainMenu()
        {
            loadingScreenManager.LoadLevel("MainMenu");
        }



    }
}