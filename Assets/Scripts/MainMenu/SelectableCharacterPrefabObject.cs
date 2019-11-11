using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EAE.Race.Utility;

namespace EAE.Race.MainMenu
{
    /// <summary>
    /// The button for selecting a character
    /// </summary>
    public class SelectableCharacterPrefabObject : MonoBehaviour
    {
        private static SelectableCharacterPrefabObject currentlySelectedCharacter;


        public Button SelectCharacterButton;

        public TextMeshProUGUI CharacterNameText;
        public Image CharacterImage;

        public GameObject CharacterSelectedCheckmarkImage;

        public GameObject LockedPanel;
        public GameObject CostToBuyPanel;
        public TextMeshProUGUI ElonCoinCostText;
        public TextMeshProUGUI DollarCostText;


        private string characterName = "";
        private GameObject characterModel;
        private bool unlocked = false;


        /// <summary>
        /// Initializes the selectable level button prefab object
        /// </summary>
        public void Initialize(string localizedCharacterName, Sprite characterSprite, bool locked, int elonCoinCost, float dollarCost, GameObject charModel)
        {
            characterName = localizedCharacterName;
            characterModel = charModel;

            CharacterNameText.text = localizedCharacterName;
            CharacterImage.sprite = characterSprite;

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

            CharacterSelectedCheckmarkImage.SetActive(false);
        }

        /// <summary>
        /// Selects this character
        /// </summary>
        public void SelectCharacter()
        {
            Debug.Log("selecting: " + characterName.ToString());

            if (!unlocked)
                return;

            if (currentlySelectedCharacter != null)
                currentlySelectedCharacter.TurnOnOffSelectedCheckmark(false);

            currentlySelectedCharacter = this;
            this.TurnOnOffSelectedCheckmark(true);

            Debug.Log("Selected " + characterName.ToString());
        }


        /// <summary>
        /// Turns the selected character checkmark on or off
        /// </summary>
        public void TurnOnOffSelectedCheckmark(bool onOff)
        {
            CharacterSelectedCheckmarkImage.SetActive(onOff);
        }

        /// <summary>
        /// Unlocks this character for use
        /// </summary>
        public void UnlockCharacter()
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