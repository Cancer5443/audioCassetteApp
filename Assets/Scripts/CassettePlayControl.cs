using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CassettePlayControl : MonoBehaviour
{
    public GameObject leftTapeHolder;
    public GameObject rightTapeHolder;
    private bool isPlaying = false;
    private bool ff = false;
    private bool rew = false;

    public void Play()
    {
        isPlaying = true;
        ff = false;
        rew = false;
        StartCoroutine("PlayAnim");
    }
    public void Pause()
    {
        isPlaying = false;
        ff = false;
        rew = false;
        StopAllCoroutines();
    }
    public void FF()
    {
        isPlaying = false;
        ff = true;
        rew = false;
        StartCoroutine("FaFo");
    }
    public void Rew()
    {
        isPlaying = false;
        ff = false;
        rew = true;
        StartCoroutine("Rewind");
    }


    private IEnumerator PlayAnim()
    {
        while (isPlaying == true)
        {
            leftTapeHolder.transform.Rotate(new Vector3(0, 360, 0), 1f, Space.Self);
            rightTapeHolder.transform.Rotate(new Vector3(0, 360, 0), 1f, Space.Self);
            yield return null;
        }
    }
    private IEnumerator FaFo()
    {
        while (ff == true)
        {
            leftTapeHolder.transform.Rotate(new Vector3(0, 360, 0), 10f, Space.Self);
            rightTapeHolder.transform.Rotate(new Vector3(0, 360, 0), 10f, Space.Self);
            yield return null;
        }
    }
    private IEnumerator Rewind()
    {
        while (rew == true)
        {
            leftTapeHolder.transform.Rotate(new Vector3(0, -360, 0), 10f, Space.Self);
            rightTapeHolder.transform.Rotate(new Vector3(0, -360, 0), 10f, Space.Self);
            yield return null;
        }
    }
}