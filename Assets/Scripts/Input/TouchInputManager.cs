using EAE.Race.Player;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EAE.Race.InputMethods
{
    /// <summary>
    /// Data related to a touch event
    /// </summary>
    class TouchData
    {
        public int FingerID;
        public Vector2 StartPosition;
        public float TimeAlive;
        public bool RightSide;
    }

    /// <summary>
    /// Handles touch inputs for the player
    /// </summary>
    public class TouchInputManager : MonoBehaviour
    {
        private Camera playerCamera;

        private PlayerController playerController;

        private float screenWidth;
        private float screenHeight;

        //private Dictionary<Touch, TouchData> activeTouchesDictionary;
        private List<TouchData> activeTouchDatasList;

        private bool usingGyroControls = true;

        private const float SWIPE_DISTANCE = 125.0f;

        private void Awake()
        {
            playerCamera = GameObject.Find("Main Camera").GetComponent<Camera>(); //TODO fix string lookup

            playerController = GameObject.FindObjectOfType<PlayerController>(); //TODO fix if multiple

            screenWidth = Screen.width;
            screenHeight = Screen.height;

            activeTouchDatasList = new List<TouchData>();
        }


        private void Update()
        {
            for(int i = 0; i < activeTouchDatasList.Count; i++)
            {
                activeTouchDatasList[i].TimeAlive += Time.deltaTime;
            }

            if (Input.touchCount > 0)
            {
                foreach(Touch currentTouch in Input.touches)
                {
                    if(currentTouch.phase == TouchPhase.Began)
                    {
                        Debug.Log("adding touch!");
                        TouchData touchData = new TouchData();
                        touchData.StartPosition = currentTouch.position;
                        touchData.TimeAlive = 0.0f;
                        touchData.FingerID = currentTouch.fingerId;

                        if(!usingGyroControls)
                        {
                            if (currentTouch.position.x < (screenWidth / 2)) //left side
                            {
                                playerController.setMovingLeft(true);
                                touchData.RightSide = false;
                            }
                            else //right side
                            {
                                playerController.setMovingRight(true);
                                touchData.RightSide = true;
                            }
                        }

                        activeTouchDatasList.Add(touchData);
                        //activeTouchesDictionary.Add(currentTouch, touchData);
                    }
                    else if(currentTouch.phase == TouchPhase.Ended)
                    {
                        TouchData startingTouchData = activeTouchDatasList.Where(x => x.FingerID == currentTouch.fingerId).FirstOrDefault();
                        if(startingTouchData == null)
                        {
                            Debug.LogWarning("DID NOT FIND STARTING TOUCH DATA FOR ID: " + currentTouch.fingerId);
                        }

                        Vector2 startPosition = startingTouchData.StartPosition;//activeTouchesDictionary[currentTouch].StartPosition;
                        Vector2 endPosition = currentTouch.position;
                        Vector2 delta = endPosition - startPosition;

                        Debug.Log("start x: " + startPosition.x + ", start y: " + startPosition.y + ", end x: " + endPosition.x + ", end y: " + endPosition.y);

                        float dist = Mathf.Sqrt(Mathf.Pow(delta.x, 2) + Mathf.Pow(delta.y, 2));
                        float angle = Mathf.Atan(delta.y / delta.x) * (180.0f / Mathf.PI);
                        float duration = startingTouchData.TimeAlive;//activeTouchesDictionary[currentTouch].TimeAlive;
                        float speed = dist / duration;

                        float xDiff = endPosition.x - startPosition.x;
                        float yDiff = endPosition.y - startPosition.y;

                        if (angle < 0)
                            angle = angle * -1.0f;

                        Debug.Log("xDiff: " + xDiff + ", yDiff: " + yDiff + ", angle: " + angle + ", speed: " + speed);


                        if (speed > 100)
                        {
                            //Down to up
                            if (yDiff > SWIPE_DISTANCE)
                            {
                                Debug.Log("down to up");

                                if (playerController.CanJump())
                                    playerController.Jump();
                                else if (playerController.CanFlip())
                                    playerController.StartFlip();
                            }
                            //Up to down
                            else if (yDiff < SWIPE_DISTANCE * -1.0f)
                            {
                                Debug.Log("up to down");

                                if (playerController.CanSlide())
                                    playerController.StartSlide();
                            }
                        }
                        
                        if(!usingGyroControls)
                        {
                            if (!startingTouchData.RightSide) //left side
                            {
                                playerController.setMovingLeft(false);
                            }
                            else //right side
                            {
                                playerController.setMovingRight(false);
                            }
                        }

                        Debug.Log("removing touch!");
                        activeTouchDatasList.Remove(startingTouchData);
                        //activeTouchesDictionary.Remove(currentTouch);
                    }
                }
            }
        }

        /// <summary>
        /// Turns the gyro controls on or off
        /// </summary>
        public void SetGyroOnOff(bool onOff)
        {
            usingGyroControls = onOff;
        }

    }
}