using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVoiceManager : MonoBehaviour
{
    public List<AudioClip> excitedSounds;
    private Dictionary<Emotion, List<AudioClip>> emotionToEffectMap;
    public enum Emotion
    {
        Excited      
    }
    // Start is called before the first frame update
    void Start()
    {
        InitLists();
    }
    void InitLists()
    {
        emotionToEffectMap = new Dictionary<Emotion, List<AudioClip>>();
        emotionToEffectMap.Add(Emotion.Excited,excitedSounds);
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    public void TriggerVoiceEffect(Emotion emotion)
    {
        if(emotionToEffectMap[emotion]!=null)
        {
            AudioManager.Instance.Play(emotionToEffectMap[emotion].RandomItem(), transform);
        }      
    }
   
}
