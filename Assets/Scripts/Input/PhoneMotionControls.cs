using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EAE.Race.Player;

namespace EAE.Race.InputMethods
{
    [RequireComponent(typeof(PlayerController))]
    public class PhoneMotionControls : MonoBehaviour
    {
        public float deadzone;

        private Quaternion deviceAttitude;
        private Vector3 deviceOrigin;

        private PlayerController pc; 


        // Start is called before the first frame update
        void Start()
        {
            pc = GetComponent<PlayerController>();
            if(SystemInfo.supportsGyroscope)
            {
                Input.gyro.enabled = true;
            }
            deviceOrigin = Input.gyro.attitude.eulerAngles;
        }

        // Update is called once per frame
        void Update()
        {
            deviceAttitude = Input.gyro.attitude;
            processOrientation();
        }

        void processOrientation()
        {
            if (!SystemInfo.supportsGyroscope) { return; }
            Vector3 euler = deviceAttitude.eulerAngles;
            // Debug.Log("x:" + euler.x + " y:" + euler.y + " z:" + euler.z);
            float rotationDeltaZ = Mathf.Abs(euler.z - deviceOrigin.z);
            if(rotationDeltaZ>deadzone)
            {
                pc.setMovingLeft(false);
                pc.setMovingRight(true);
            }else if(rotationDeltaZ>deadzone)
            {
                pc.setMovingLeft(true);
                pc.setMovingRight(false);
            }
            else
            {
                pc.setMovingLeft(false);
                pc.setMovingRight(false);
            }
        }
    }

}