using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class AdVideoPlayer : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;

    private Animator videoPlayerAnimator;

    void Awake()
    {
        videoPlayerAnimator = this.GetComponent<Animator>();
        //rawImage.texture = videoPlayer.texture;
    }

    public void PlayVideo()
    {
        videoPlayerAnimator.SetBool("ShowAd", true);
        videoPlayer.Play();
        StartCoroutine(EndVideo());
    }

    private IEnumerator EndVideo()
    {
        yield return new WaitForSeconds(5.0f);
        videoPlayerAnimator.SetBool("ShowAd", false);
    }
}
