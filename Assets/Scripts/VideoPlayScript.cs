using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoPlayScript : MonoBehaviour
{
    public VideoPlayer vid;


    void Start()
    {
        vid.Play();
        vid.loopPointReached += CheckOver;
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        print("Video Is Over");
        SceneManager.LoadScene("MainScene");
    }
}
