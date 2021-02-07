using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoPlayScript : MonoBehaviour
{
    public VideoPlayer vid;
    private bool videoLoop = false;


    void Start()
    {
        vid.Play();
        StartCoroutine(LoadScene());
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        videoLoop = true;
    }

    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("MainScene");
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
            vid.Play();
            vid.loopPointReached += CheckOver;

            if (asyncOperation.progress >= 0.9f && videoLoop == true)
            {
                    asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
