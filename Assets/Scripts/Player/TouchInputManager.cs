using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EAE.Race.Player
{
    /// <summary>
    /// Handles touch inputs for the player
    /// </summary>
    public class TouchInputManager : MonoBehaviour
    {
        private Camera playerCamera;

        private float screenWidth;
        private float screenHeight;

        private void Awake()
        {
            playerCamera = GameObject.Find("Main Camera").GetComponent<Camera>(); //TODO fix string lookup

            screenWidth = Screen.width;
            screenHeight = Screen.height;
        }


        private void Update()
        {
            if(Input.touchCount > 0)
            {

            }
        }


    }
}