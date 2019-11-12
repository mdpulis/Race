using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAnimation : MonoBehaviour
{

    [SerializeField]
    public Vector3 rotationSpeed = new Vector3(0f, 0f, 0f);
    public float bounceSpeed;
    public float bounceHeight;

    private float yCenter;
    // Start is called before the first frame update
    void Start()
    {
        yCenter = transform.position.y;   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, 
                                        yCenter + Mathf.PingPong(Time.time * bounceSpeed, bounceHeight) - bounceHeight / 2f, 
                                        transform.position.z);//move on y axis only
    }
}
