using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EAE.Race.MainMenu
{
    [CreateAssetMenu(fileName = "HoverboardInfo", menuName = "MainMenu/HoverboardInfo", order = 2)]
    /// <summary>
    /// The info for a hoverboard
    /// </summary>
    public class HoverboardInfo : ScriptableObject
    {
        public string HoverboardNameEN;

        public Sprite HoverboardSprite;
        public GameObject HoverboardModel;

        public bool LockedByDefault;
        public int ElonCoinCost;
        public float DollarCost;


        /// <summary>
        /// Returns the localized name for the hoverboard
        /// </summary>
        public string GetLocalizedHoverboardName()
        {
            return HoverboardNameEN;
        }

        /// <summary>
        /// Returns the English name for the hoverboard
        /// </summary>
        public string GetEnglishHoverboardName()
        {
            return HoverboardNameEN;
        }
    }
}