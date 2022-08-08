using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class streamVideo : MonoBehaviour
{
    public RawImage rawImage;
    public AudioSource audioSource;
    public VideoPlayer videoPlayer;
    private bool oneTime;


    IEnumerator playVideo()
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.2f);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
        }
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
    }


    private void Update()
    {
        if (gameObject.activeSelf && !oneTime)
        {
            StartCoroutine(playVideo());
        }
    }
}
