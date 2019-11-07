using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EAE.Race.Player;

[RequireComponent(typeof(PlayerController))]
public class AutoRighting : MonoBehaviour
{
    public float rightingSpeed;

    private Vector3 targetRotation = new Vector3(0,0,0);
    private Quaternion targetQuaternion;
    private PlayerController pc;
   
    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
