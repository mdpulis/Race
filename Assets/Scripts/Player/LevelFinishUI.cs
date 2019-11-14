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
#if !UNITY_ANDROID
        private LeaderBoardManager leaderBoard;
#endif

        private AdVideoPlayer adVideoPlayer;

        private void Awake()
        {
            loadingScreenManager = GameObject.FindObjectOfType<LoadingScreenManager>();
#if !UNITY_ANDROID
            leaderBoard = GameObject.FindObjectOfType<LeaderBoardManager>();     
#endif
            playerData = GameObject.FindObjectOfType<PlayerData>();

            adVideoPlayer = GameObject.FindObjectOfType<AdVideoPlayer>();

            handleScore();
        }

        private void handleScore()
        {
#if !UNITY_ANDROID
            leaderBoard.RecordScore(playerData.GetTimePlayed(), true);
#endif
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