using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EAE.Race.Player;

namespace EAE.Race.Interactables
{
    /// <summary>
    /// If the player interacts with this, speeds them up
    /// </summary>
    public class BoostPad : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            PlayerController pc = other.GetComponent<PlayerController>();
            if ( pc!= null)
            {
                pc.StartBoost();               
            }         
        }
    }

}