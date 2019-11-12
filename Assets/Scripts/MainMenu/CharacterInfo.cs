using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EAE.Race.MainMenu
{
    [CreateAssetMenu(fileName = "CharacterInfo", menuName = "MainMenu/CharacterInfo", order = 2)]
    /// <summary>
    /// The info for a character
    /// </summary>
    public class CharacterInfo : ScriptableObject
    {
        public string CharacterNameEN;

        public Sprite CharacterSprite;
        public GameObject CharacterModel;

        public bool LockedByDefault;
        public int ElonCoinCost;
        public float DollarCost;


        /// <summary>
        /// Returns the localized name for the character
        /// </summary>
        public string GetLocalizedCharacterName()
        {
            return CharacterNameEN;
        }

        /// <summary>
        /// Returns the English name for the character
        /// </summary>
        public string GetEnglishCharacterName()
        {
            return CharacterNameEN;
        }
    }
}