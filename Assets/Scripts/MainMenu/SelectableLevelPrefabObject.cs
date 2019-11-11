using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EAE.Race.Utility;

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

        private void Awake()
        {
            if (GameObject.FindObjectOfType<LoadingScreenManager>() != null)
                loadingScreenManager = GameObject.FindObjectOfType<LoadingScreenManager>();
            else
                Debug.LogWarning("WARNING: No loading screen manager found! Can't change scenes.");
        }

        /// <summary>
        /// Initializes the selectable level button prefab object
        /// </summary>
        public void Initialize(string localizedLevelName, string sceneName, Sprite levelSprite, float bestTime)
        {
            LevelNameText.text = localizedLevelName;
            BestTimeText.text = "Best " + bestTime.ToString(); //TODO fix
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
                loadingScreenManager.LoadLevel(internalSceneName);
            else
                Debug.LogWarning("WARNING: No loading screen manager found! Can't change scenes.");
        }


    }
}