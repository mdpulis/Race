using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EAE.Race.Player
{
    /// <summary>
    /// Controls the player
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class PlayerController : MonoBehaviour
    {
        public Transform Models;
        public Transform FlipRotationPoint;

        //public modifiable variables
        public float BoardSpeed = 3.0f;
        public float RotateSpeed = 30.0f;
        public float BoostMod = 2.0f;
        public float straightDeadZone;

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

        private float startRotation = 0.0f;
        private float endRotation = 0.0f;

        private float distToGround=1f;
        private bool isGrounded;

        //visual components
        public AnimationManager anim;
        private TimedEffect speedEffect;
        public PlayerVoiceManager playerVoice;
       

        #region Setup
        private void Awake()
        {
            racing = true;
            //this.GetComponent<Rigidbody>().centerOfMass = CenterOfMass.position;
            anim = GetComponentInChildren<AnimationManager>();
            speedEffect = Camera.main.GetComponentInChildren<TimedEffect>();
            playerVoice = GetComponent<PlayerVoiceManager>();
        }


        #endregion Setup


        private void Update()
        {
            CheckGrounded();           
            if (!flipping && Input.GetKeyDown(KeyCode.W) && !isGrounded)
            {
                StartFlip();
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
                currentBoostTime += Time.fixedDeltaTime;
                if(currentBoostTime > MAX_BOOST_TIME)
                {
                    EndBoost();
                }
            }

            if(flipping)
            {
                currentFlipTime += Time.fixedDeltaTime;

                float rotVal = (Time.fixedDeltaTime / MAX_FLIP_TIME) * 360.0f;
                Models.RotateAround(FlipRotationPoint.position, Models.right, rotVal);


                if (currentFlipTime > MAX_FLIP_TIME)
                {
                    EndFlip();
                    Models.localRotation = Quaternion.Euler(0, 0, 0);
                    Models.localPosition = new Vector3(0, 0, 0);
                }
            }

        }


        #region Movement
        public void setMovingLeft(bool state)
        {
            this.movingLeft = state;
        }

        public void setMovingRight(bool state)
        {
            this.movingRight = state;
        }
        #endregion

        #region Grounded
        public void CheckGrounded()
        {           
            isGrounded = Physics.Raycast(transform.position +  new Vector3(0,distToGround,0), -Vector3.up, distToGround + 0.1f);
        }

        public bool IsGrounded()
        {
            return isGrounded;
        }
        #endregion


        #region Boost
        /// <summary>
        /// Starts the boost for the player
        /// </summary>
        public void StartBoost()
        {
            currentBoostTime = 0.0f;
            boosting = true;

            //Visual Effects
            anim.TriggerState(AnimationManager.states.Win);
            speedEffect.triggerEffect();
            playerVoice.TriggerVoiceEffect(PlayerVoiceManager.Emotion.Excited);
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

        #region Flip
        /// <summary>
        /// Starts the flip for the player
        /// </summary>
        public void StartFlip()
        {
            currentFlipTime = 0.0f;
            flipping = true;

            startRotation = Models.localEulerAngles.x;
            endRotation = startRotation + 360.0f;
        }

        /// <summary>
        /// Ends the flip for the player
        /// </summary>
        public void EndFlip()
        {
            currentFlipTime = 0.0f;
            flipping = false;
        }
        #endregion Flip

    }
}