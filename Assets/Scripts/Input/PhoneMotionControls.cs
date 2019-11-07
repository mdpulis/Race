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

        private PlayerController pc; 

        // Start is called before the first frame update
        void Start()
        {
            pc = GetComponent<PlayerController>();
            Debug.Log(SystemInfo.supportsGyroscope);
        }

        // Update is called once per frame
        void Update()
        {
            deviceAttitude = Input.gyro.attitude;
            processOrientation();
        }

        void processOrientation()
        {
            Debug.Log(deviceAttitude);
            Vector3 euler = deviceAttitude.eulerAngles;
            Debug.Log("x:" + euler.x + " y:" + euler.y + " z:" + euler.z);
        }
    }

}