using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class OnTime : MonoBehaviour
{
    public float changeTime;
    public string sceneName;

    //public VideoPlayer video;

    private void Update()
    {

        changeTime -= Time.deltaTime;
        if (changeTime <= 0)
        {
            SceneManager.LoadScene(sceneName);
        }


        /*long playerCurrentFrame = video.GetComponent<VideoPlayer>().frame;
        long playerFrameCount = Convert.ToInt64(video.GetComponent<VideoPlayer>().frameCount);

        if (playerCurrentFrame < playerFrameCount)
        {
            print("VIDEO IS PLAYING");
        }
        else
        {
            Debug.Log("Video has ended. Changing scene...");
            SceneManager.LoadScene("Game");
        }*/



    }
}
