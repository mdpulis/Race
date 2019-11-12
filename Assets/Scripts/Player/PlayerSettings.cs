using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EAE.Race.Player
{
    /// <summary>
    /// Holds all player settings and options
    /// </summary>
    public class PlayerSettings : MonoBehaviour
    {
        public GameObject DefaultCharacter;
        public GameObject DefaultHoverboard;

        private bool usingGyroControls = true;

        private GameObject selectedCharacter = null;
        private GameObject selectedHoverboard = null;

        private void Awake()
        {
            //Make sure we don't have any extra player settings; if we already have one, we need to destroy this one
            if (GameObject.FindObjectsOfType<PlayerSettings>() != null && GameObject.FindObjectsOfType<PlayerSettings>().Length > 1)
                Destroy(this.gameObject);

            //Make sure we don't destroy our player settings
            DontDestroyOnLoad(this.gameObject);

        }

        #region Setters
        /// <summary>
        /// Sets the gyro controls to on or off
        /// </summary>
        public void SetGyroControls(bool onOff)
        {
            usingGyroControls = onOff;
        }

        /// <summary>
        /// Sets the selected character
        /// </summary>
        public void SetSelectedCharacter(GameObject newCharacter)
        {
            selectedCharacter = newCharacter;
        }

        /// <summary>
        /// Sets the selected hoverboard
        /// </summary>
        public void SetSelectedHoverboard(GameObject newHoverboard)
        {
            selectedHoverboard = newHoverboard;
        }
        #endregion Setters

        #region Getters
        /// <summary>
        /// Gets the current gyro controls setting
        /// </summary>
        public bool GetGyroControls()
        {
            return usingGyroControls;
        }

        /// <summary>
        /// Gets the selected character
        /// </summary>
        public GameObject GetSelectedCharacter()
        {
            if (selectedCharacter == null)
                return DefaultCharacter;

            return selectedCharacter;
        }

        /// <summary>
        /// Gets the selected hoverboard
        /// </summary>
        public GameObject GetSelectedHoverboard()
        {
            if (selectedHoverboard == null)
                return DefaultHoverboard;

            return selectedHoverboard;
        }
        #endregion Getters

    }
}