using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EAE.Race.Player
{
    /// <summary>
    /// Controls the player
    /// </summary>
    public class PlayerController : MonoBehaviour
    {

        //public modifiable variables
        public float BoardSpeed = 3.0f;
        public float RotateSpeed = 30.0f;
        public float BoostMod = 2.0f;



        //private gameplay variables
        private bool racing = false;

        private bool movingLeft = false;
        private bool movingRight = false;

        private bool boosting = false;


        #region Setup
        private void Awake()
        {
            racing = true;
        }

        #endregion Setup

        // Update is called once per frame
        void Update()
        {
            if (!racing)
                return;

            if (movingLeft || Input.GetKey(KeyCode.A))
            {
                //transform.Translate(Vector3.left * boardSpeed * Time.deltaTime);
                transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
            }
            else if (movingRight || Input.GetKey(KeyCode.D))
            {
                //transform.Translate(Vector3.right * boardSpeed * Time.deltaTime);
                transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
            }

            if (!boosting)
                transform.Translate(Vector3.forward * BoardSpeed * Time.deltaTime);
            else
                transform.Translate(Vector3.forward * BoardSpeed * BoostMod * Time.deltaTime);

            //CollisionFlags.Sides
        }


        #region Boost
        /// <summary>
        /// Starts the boost for the player
        /// </summary>
        public void StartBoost()
        {
            boosting = true;
        }

        /// <summary>
        /// Ends the boost for the player
        /// </summary>
        public void EndBoost()
        {
            boosting = false;
        }
        #endregion Boost

    }
}