﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class AudioControl : MonoBehaviour
{
    public GameObject audioSource;
    public AudioClip audioClipA;
    public AudioClip audioClipB;
    private AudioSource control;
    private float fastforward = 4;
    private float rewind = -4;
    private float normal = 1;
    private bool ejected = true;

    private float audioClipTime = 0;
    private float clipATime;
    private float clipBTime;
    private float setVolume;
    public GameObject volumeNob;

    public Animator animatorHolder;
    public GameObject cassetteScriptHolder;

    void Start()
    {
        InvokeRepeating("UpdateAudioClipTime", 0, 1);
        control = audioSource.GetComponent<AudioSource>();
        control.pitch = normal;
        SetAudioSourceB();
        clipATime = 0f;
        clipBTime = 0f;
    }

    private void Update()
    {
        UpdateVolume();
        control.volume = setVolume;
        if (control.time >= control.clip.length)
        {
            control.Pause();
            animatorHolder.SetTrigger("Pause");
            cassetteScriptHolder.GetComponent<CassettePlayControl>().Pause();
        }
    }

    private void UpdateAudioClipTime()
    {
        //Debug.Log("clipTimeA: " + clipATime + " , " + "clipTimeB: " + clipBTime);
            if (control.clip == audioClipA)
            {
                clipATime = control.time;
            }
            else if (control.clip == audioClipB)
            {
                clipBTime = control.time;
            }
            audioClipTime = control.time;
    }

    public void PlayAudio()
    {
        if (ejected == false)
        {
            control.pitch = normal;
            if (control.isPlaying == false)
            {
                control.Play();
                animatorHolder.SetTrigger("Play");
                cassetteScriptHolder.GetComponent<CassettePlayControl>().Play();
            }
        }
        else
        {

        }
    }

    public void PauseAudio()
    {
        if (ejected == false)
        {
            control.pitch = normal;
            if (control.isPlaying == true)
            {
                control.Pause();
                animatorHolder.SetTrigger("Pause");
                cassetteScriptHolder.GetComponent<CassettePlayControl>().Pause();
            }
        }
        else
        {

        }
    }

    public void SetAudioSourceA()
    {
        if (ejected == true)
        {
            control.clip = audioClipA;
            audioClipTime = control.clip.length - clipBTime;
            if (audioClipTime <= 0)
            {
                control.time = 0;
            }
            else
            {
                control.time = audioClipTime;
            }
        }
    }

    public void SetAudioSourceB()
    {
        if (ejected == true)
        {
            control.clip = audioClipB;
            audioClipTime = control.clip.length - clipATime;
            if (audioClipTime <= 0)
            {
                control.time = 0;
            }
            else
            {
                control.time = audioClipTime;
            }
        }
    }

    public void FastForward()
    {
        if (ejected == false)
        {
            if (control.isPlaying == true)
            {
                control.pitch = fastforward;
                animatorHolder.SetTrigger("FF");
                cassetteScriptHolder.GetComponent<CassettePlayControl>().FF();
            }
            else if (control.isPlaying == false)
            {
                control.Play();
                control.pitch = fastforward;
                animatorHolder.SetTrigger("FF");
                cassetteScriptHolder.GetComponent<CassettePlayControl>().FF();
            }
        }
    }

    public void Rewind()
    {
        if (ejected == false)
        {
            if (control.isPlaying == true)
            {
                control.pitch = rewind;
                animatorHolder.SetTrigger("Rew");
                cassetteScriptHolder.GetComponent<CassettePlayControl>().Rew();
            }
            else if (control.isPlaying == false)
            {
                control.Play();
                control.pitch = rewind;
                animatorHolder.SetTrigger("Rew");
                cassetteScriptHolder.GetComponent<CassettePlayControl>().Rew();
            }
        }
    }

    public void UpdateVolume()
    {
        float angle;
        float volume;

        angle = volumeNob.transform.eulerAngles.z;

        volume = (100 * angle) / 179;
        setVolume = (volume*0.01f);
    }

    public void Eject()
    {
        if (ejected == false)
        {
            PauseForEject();
            ejected = true;
            animatorHolder.SetTrigger("Eject");
            cassetteScriptHolder.GetComponent<CassettePlayControl>().Pause();
        }
    }

    public void Insert()
    {
        if (ejected == true)
        {
            PauseAudio();
            ejected = false;
            animatorHolder.SetTrigger("Insert");
        }
    }

    public void PauseForEject()
    {
        cassetteScriptHolder.GetComponent<CassettePlayControl>().Pause();
        control.pitch = normal;
        if (control.isPlaying == true)
        {
            control.Pause();
        }
    }
}
