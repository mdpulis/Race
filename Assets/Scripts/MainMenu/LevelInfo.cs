using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EAE.Race.MainMenu
{
    [CreateAssetMenu(fileName = "LevelInfo", menuName = "MainMenu/LevelInfo", order = 1)]
    /// <summary>
    /// The info for a level
    /// </summary>
    public class LevelInfo : ScriptableObject
    {
        public string SceneName;
        public string LevelNameEN;

        public Sprite LevelSprite;
        public float DefaultBestTime;

        /// <summary>
        /// Returns the localized name for the level
        /// </summary>
        public string GetLocalizedLevelName()
        {
            return LevelNameEN;
        }

        /// <summary>
        /// Returns the English name for the level
        /// </summary>
        public string GetEnglishLevelName()
        {
            return LevelNameEN;
        }

    }
}