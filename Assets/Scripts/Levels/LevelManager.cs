﻿using EAE.Race.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EAE.Race.Levels
{
    /// <summary>
    /// Manages data for the level
    /// </summary>
    public class LevelManager : MonoBehaviour
    {
        public GameObject HoverboardPlayer;

        private PlayerSettings playerSettings;

        private void Awake()
        {
            playerSettings = GameObject.FindObjectOfType<PlayerSettings>();
            InitializePlayers();
        }

        /// <summary>
        /// Initializes all players
        /// </summary>
        private void InitializePlayers()
        {
            PlayerController playerController = Instantiate(HoverboardPlayer).GetComponent<PlayerController>();
            //TODO maybe set location for player here instead of PlayerController's Awake?
            playerController.SetCharacterModel(playerSettings.GetSelectedCharacter());
            playerController.SetHoverboardModel(playerSettings.GetSelectedHoverboard());

            playerController.LookForReferences();
        }



    }
}