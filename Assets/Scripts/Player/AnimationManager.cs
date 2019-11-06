using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class AnimationManager : MonoBehaviour
{
    public enum states
    {
        Idle,
        Twist,
        Win,
        Lose,
        Jump,
        Slide
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

        triggerDict.Add(states.Idle, "Idle");
        triggerDict.Add(states.Twist, "Twist");
        triggerDict.Add(states.Win, "Win");
        triggerDict.Add(states.Lose, "Lose");
        triggerDict.Add(states.Jump, "Jump0");
        triggerDict.Add(states.Slide, "Slide");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            TriggerState(states.Twist);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TriggerState(states.Win);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TriggerState(states.Lose);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            TriggerState(states.Jump);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            TriggerState(states.Slide);
        }
    }
    public void TriggerState(states newState)
    {
        anim.SetTrigger(triggerDict[newState]);
    }

}
