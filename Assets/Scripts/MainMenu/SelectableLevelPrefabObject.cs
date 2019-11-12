using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EAE.Race.Utility;
using EAE.Race.Scoring;

namespace EAE.Race.MainMenu
{
    /// <summary>
    /// The button for selecting a level
    /// </summary>
    public class SelectableLevelPrefabObject : MonoBehaviour
    {
        public Button SelectLevelButton;

        public TextMeshProUGUI LevelNameText;
        public TextMeshProUGUI BestTimeText;
        public Image LevelImage;

        private string internalSceneName = "";

        private LoadingScreenManager loadingScreenManager;

        private LeaderBoardManager leaderBoard;

        private void Awake()
        {
            if (GameObject.FindObjectOfType<LoadingScreenManager>() != null)
                loadingScreenManager = GameObject.FindObjectOfType<LoadingScreenManager>();
            else
                Debug.LogWarning("WARNING: No loading screen manager found! Can't change scenes.");

            if (GameObject.FindObjectOfType<LeaderBoardManager>() != null)
                leaderBoard = GameObject.FindObjectOfType<LeaderBoardManager>();
            else
                Debug.LogWarning("WARNING: No Leaderboard manager found! Can't populate scores.");
        }

        /// <summary>
        /// Initializes the selectable level button prefab object
        /// </summary>
        public void Initialize(string localizedLevelName, string sceneName, Sprite levelSprite, float bestTime)
        {
            LevelNameText.text = localizedLevelName;

            leaderBoard.setCurrentLevelID(localizedLevelName);
            leaderBoard.RecordScore(bestTime,true );
            if (leaderBoard.getHighScoreForLevel(localizedLevelName) < bestTime)
            {
                BestTimeText.text = "Record: " + leaderBoard.getHighScoreStringForLevel(localizedLevelName);
            }
            else
            {
                BestTimeText.text = "Record: " + Util.SecondsToMinutesSeconds(bestTime); //TODO fix
            }
           


            LevelImage.sprite = levelSprite;
            internalSceneName = sceneName;

            //SelectLevelButton.onClick.AddListener(() => SelectLevel());
        }

        /// <summary>
        /// Selects this level
        /// </summary>
        public void SelectLevel()
        {
            if (loadingScreenManager != null)
            {
                leaderBoard.setCurrentLevelID(LevelNameText.text);
                loadingScreenManager.LoadLevel(internalSceneName);
            }              
            else
            {
                Debug.LogWarning("WARNING: No loading screen manager found! Can't change scenes.");
            }
               
        }


    }
}