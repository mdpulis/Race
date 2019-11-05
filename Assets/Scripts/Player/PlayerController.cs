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
        public Transform Models;

        //public modifiable variables
        public float BoardSpeed = 3.0f;
        public float RotateSpeed = 30.0f;
        public float BoostMod = 2.0f;


        //private gameplay variables
        private bool racing = false;

        private bool movingLeft = false;
        private bool movingRight = false;

        private bool boosting = false;
        private float currentBoostTime = 0.0f;
        private const float MAX_BOOST_TIME = 3.0f;

        private bool flipping = false;
        private float currentFlipTime = 0.0f;
        private const float MAX_FLIP_TIME = 1.0f;


        #region Setup
        private void Awake()
        {
            racing = true;

            //this.GetComponent<Rigidbody>().centerOfMass = CenterOfMass.position;
        }

        #endregion Setup


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                flipping = true;
            }
        }

        // Fixed Update is called 50 times per second
        void FixedUpdate()
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
            if(boosting)
            {
                currentBoostTime += Time.deltaTime;
                if(currentBoostTime > MAX_BOOST_TIME)
                {
                    EndBoost();
                }
            }

            if(flipping)
            {
                Models.Rotate(Vector3.right * RotateSpeed * Time.deltaTime);
            }

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
            currentBoostTime = 0.0f;
            boosting = false;
        }
        #endregion Boost

        #region Boost
        /// <summary>
        /// Starts the flip for the player
        /// </summary>
        public void StartFlip()
        {
            flipping = true;
        }

        /// <summary>
        /// Ends the flip for the player
        /// </summary>
        public void EndFlip()
        {
            currentFlipTime = 0.0f;
            flipping = false;
        }
        #endregion Boost

    }
}