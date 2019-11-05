using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class AnimationManager : MonoBehaviour
{
    public enum states
    {
        IDLE,
        TWIST,
        WIN,
        LOSE,
        JUMP,
        SLIDE
    }
    private Animator anim;
    private Dictionary<states, string> triggerDict;
    // Start is called before the first frame update
    void Start()
    {       
        anim = GetComponent<Animator>();
        InitTriggerDictionary();
    }

    private void InitTriggerDictionary()
    {
        triggerDict = new Dictionary<states, string>();

        triggerDict.Add(states.IDLE, "Idle");
        triggerDict.Add(states.TWIST, "Twist");
        triggerDict.Add(states.WIN, "Win");
        triggerDict.Add(states.LOSE, "Lose");
        triggerDict.Add(states.JUMP, "Jump0");
        triggerDict.Add(states.SLIDE, "Slide");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            TriggerState(states.TWIST);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TriggerState(states.WIN);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TriggerState(states.LOSE);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            TriggerState(states.JUMP);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            TriggerState(states.SLIDE);
        }
    }
    public void TriggerState(states newState)
    {
        anim.SetTrigger(triggerDict[newState]);
    }

}
