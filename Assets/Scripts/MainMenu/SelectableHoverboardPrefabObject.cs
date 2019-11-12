using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EAE.Race.Utility;

namespace EAE.Race.MainMenu
{
    /// <summary>
    /// The button for selecting a Hoverboard
    /// </summary>
    public class SelectableHoverboardPrefabObject : MonoBehaviour
    {
        private static SelectableHoverboardPrefabObject currentlySelectedHoverboard;


        public Button SelectHoverboardButton;

        public TextMeshProUGUI HoverboardNameText;
        public Image HoverboardImage;

        public GameObject HoverboardSelectedCheckmarkImage;

        public GameObject LockedPanel;
        public GameObject CostToBuyPanel;
        public TextMeshProUGUI ElonCoinCostText;
        public TextMeshProUGUI DollarCostText;


        private string hoverboardName = "";
        private GameObject hoverboardModel;
        private bool unlocked = false;


        /// <summary>
        /// Initializes the selectable level button prefab object
        /// </summary>
        public void Initialize(string localizedHoverboardName, Sprite hoverboardSprite, bool locked, int elonCoinCost, float dollarCost, GameObject charModel)
        {
            hoverboardName = localizedHoverboardName;
            hoverboardModel = charModel;

            HoverboardNameText.text = localizedHoverboardName;
            HoverboardImage.sprite = hoverboardSprite;

            ElonCoinCostText.text = elonCoinCost.ToString();
            DollarCostText.text = "$" + dollarCost.ToString();

            if(locked)
            {
                LockedPanel.SetActive(true);
                CostToBuyPanel.SetActive(true);
                unlocked = false;
            }
            else
            {
                LockedPanel.SetActive(false);
                CostToBuyPanel.SetActive(false);
                unlocked = true;
            }

            HoverboardSelectedCheckmarkImage.SetActive(false);
        }

        /// <summary>
        /// Selects this hoverboard
        /// </summary>
        public void SelectHoverboard()
        {
            if (!unlocked)
                return;

            if (currentlySelectedHoverboard != null)
                currentlySelectedHoverboard.TurnOnOffSelectedCheckmark(false);

            currentlySelectedHoverboard = this;
            this.TurnOnOffSelectedCheckmark(true);
        }


        /// <summary>
        /// Turns the selected Hoverboard checkmark on or off
        /// </summary>
        public void TurnOnOffSelectedCheckmark(bool onOff)
        {
            HoverboardSelectedCheckmarkImage.SetActive(onOff);
        }

        /// <summary>
        /// Unlocks this hoverboard for use
        /// </summary>
        public void UnlockHoverboard()
        {
            LockedPanel.SetActive(false);
            CostToBuyPanel.SetActive(false);
            unlocked = true;
        }


        #region Getters
        /// <summary>
        /// Returns if this is unlocked
        /// </summary>
        public bool IsUnlocked()
        {
            return unlocked;
        }
        #endregion Getters

    }
}