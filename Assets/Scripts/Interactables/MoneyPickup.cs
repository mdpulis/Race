using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EAE.Race.Player;

namespace EAE.Race.Interactables
{
    /// <summary>
    /// Adds money to the player
    /// </summary>
    public class MoneyPickup : MonoBehaviour
    {
        public int MoneyValue = 1;

        private bool canPickup = true;

        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<PlayerData>() != null)
            {
                canPickup = false;

                other.GetComponent<PlayerData>().AddMoney(MoneyValue);
                StartCoroutine(WaitToDestroy());
            }
        }

        /// <summary>
        /// Waits a short time before destroying this object
        /// </summary>
        private IEnumerator WaitToDestroy()
        {
            yield return new WaitForSeconds(1.0f);
            Destroy(this);
        }

    }

}