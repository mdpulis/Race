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


        private const float SWIPE_DISTANCE = 125.0f;

        private void Awake()
        {
            playerCamera = GameObject.Find("Main Camera").GetComponent<Camera>(); //TODO fix string lookup

            playerController = GameObject.FindObjectOfType<PlayerController>(); //TODO fix if multiple

            screenWidth = Screen.width;
            screenHeight = Screen.height;

            //activeTouchesDictionary = new Dictionary<Touch, TouchData>();
            activeTouchDatasList = new List<TouchData>();
        }


        private void Update()
        {
            //if(activeTouchesDictionary.Count > 0)
            //{
            //    List<Touch> keysList = new List<Touch>(activeTouchesDictionary.Keys);
            //
            //    foreach (Touch key in keysList)
            //    {
            //        TouchData td = activeTouchesDictionary[key];
            //        td.TimeAlive += Time.deltaTime;
            //        //activeTouchesDictionary[key].TimeAlive += Time.deltaTime;
            //    }
            //}

            for(int i = 0; i < activeTouchDatasList.Count; i++)
            {
                activeTouchDatasList[i].TimeAlive += Time.deltaTime;
            }

           //for(int i = 0; i < activeTouchesDictionary.Count; i++)
           //{
           //   // activeTouchesDictionary.
           //}
           //
           //foreach(KeyValuePair<Touch, TouchData> entry in activeTouchesDictionary)
           //{
           //    entry.Value.TimeAlive += Time.deltaTime;
           //}
           //
           //foreach(TouchData touchData in activeTouchesDictionary.Values)
           //{
           //    touchData.TimeAlive += Time.deltaTime;
           //}

            //var dictionary = new Dictionary<string, double>();
            //// TODO Populate your dictionary here
            //var keys = new List<string>(dictionary.Keys);
            //foreach (string key in keys)
            //{
            //    dictionary[key] = Math.Round(dictionary[key], 3);
            //}

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
                        

                        // Left to right swipe
                        if (startPosition.y < endPosition.y)
                        {
                            //Debug.Log("Distance: " + dist + " Angle: " + angle + " Speed: " + speed);
                            if (dist > 300 && angle < 30 && speed > 300)
                            {
                                
                                //playerController.Jump();
                            }
                        }
                        //Right to left
                        else if(startPosition.y > endPosition.y)
                        {
                            if (dist > 300 && angle < 30 && speed > 300)
                            {
                                //playerController.Jump();
                            }
                        }


                        //// Up to down swipe
                        //if (startPosition.x < endPosition.x)
                        //{
                        //    //Debug.Log("Distance: " + dist + " Angle: " + angle + " Speed: " + speed);
                        //    if (dist > 300 && angle < 30 && speed > 300)
                        //    {
                        //        Debug.Log("up to down");
                        //        //playerController.Jump();
                        //    }
                        //}
                        ////Right to left
                        //else if (startPosition.x > endPosition.x)
                        //{
                        //    if (dist > 300 && angle < 30 && speed > 300)
                        //    {
                        //        Debug.Log("down to up");
                        //        //playerController.Jump();
                        //    }
                        //}



                        if (!startingTouchData.RightSide)//!activeTouchesDictionary[currentTouch].RightSide) //left side
                        {
                            playerController.setMovingLeft(false);
                        }
                        else //right side
                        {
                            playerController.setMovingRight(false);
                        }

                        Debug.Log("removing touch!");
                        activeTouchDatasList.Remove(startingTouchData);
                        //activeTouchesDictionary.Remove(currentTouch);
                    }
                }
                //if (Input.touchCount > 0  Input.GetTouch(0).phase == TouchPhase.Ended) {
                //    Vector2 endPosition = Input.GetTouch(0).position;
                //    Vector2 delta = endPosition - startPosition;
                //
                //    float dist = Mathf.Sqrt(Mathf.Pow(delta.x, 2) + Mathf.Pow(delta.y, 2));
                //    float angle = Mathf.Atan(delta.y / delta.x) * (180.0f / Mathf.PI);
                //    float duration = Time.time - startTime;
                //    float speed = dist / duration;
                //
                //    // Left to right swipe
                //    if (startPosition.y < endPosition.y)
                //    {
                //        if (angle < 0) angle = angle * 1.0f;
                //        Debug.Log("Distance: " + dist + " Angle: " + angle + " Speed: " + speed);
                //
                //        if (dist > 300  angle < 10  speed > 1000) {
                //            // Do something related to the swipe
                //        }
                //    }
                //}
                //
                //if (Input.touchCount > 0  Input.GetTouch(0).phase == TouchPhase.Began) {
                //    startPosition = Input.GetTouch(0).position;
                //    startTime = Time.time;
                //}
            }
        }


    }
}