using EAE.Race.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EAE.Race.Scoring;

namespace EAE.Race.Player
{
    /// <summary>
    /// The UI screen that appears when finishing a level
    /// </summary>
    public class LevelFinishUI : MonoBehaviour
    {
        private LoadingScreenManager loadingScreenManager;
        private PlayerData playerData;
        private LeaderBoardManager leaderBoard;

        private AdVideoPlayer adVideoPlayer;

        private void Awake()
        {
            loadingScreenManager = GameObject.FindObjectOfType<LoadingScreenManager>();
            leaderBoard = GameObject.FindObjectOfType<LeaderBoardManager>();          
            playerData = GameObject.FindObjectOfType<PlayerData>();

            adVideoPlayer = GameObject.FindObjectOfType<AdVideoPlayer>();

            handleScore();
        }

        private void handleScore()
        {
            leaderBoard.RecordScore(playerData.GetTimePlayed(), true);
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

        /// <summary>
        /// Displays an ad
        /// </summary>
        public void DisplayVideoAd()
        {
            if (adVideoPlayer != null)
                adVideoPlayer.PlayVideo();
        }



    }
}