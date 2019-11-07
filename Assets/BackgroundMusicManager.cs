using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public List<AudioClip> songs;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        if (songs != null)
        {
            AudioManager.Instance.PlayLoop(songs.RandomItem(), transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
