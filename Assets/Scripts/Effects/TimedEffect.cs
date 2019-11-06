using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedEffect : MonoBehaviour
{      
    public float effectLength;//how long does this effect last for

    private float effectTimer = 0.0f;
    void Start()
    {        
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        effectTimer += Time.deltaTime;
        if(effectTimer>effectLength)
        {
            effectTimer = 0;
            gameObject.SetActive(false);
        }
        
    }

    public void triggerEffect()
    {
        gameObject.SetActive(true);
    }
}
