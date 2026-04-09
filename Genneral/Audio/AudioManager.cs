using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public PlayAudioEvent FxEvent;
    public PlayAudioEvent BGMEvent;
    public AudioSource BGM;
    public AudioSource Effect;

    public void OnEnable()
    {
        FxEvent.OnEventRaised += OnFxEvent;
        BGMEvent.OnEventRaised += OnBGMEvent;
    }


    private void OnDisable()
    {
        FxEvent.OnEventRaised -= OnFxEvent;
        BGMEvent.OnEventRaised -= OnBGMEvent;
    }

    private void OnBGMEvent(AudioClip clip)
    {
        BGM.clip = clip;
        BGM.Play();
    }

    private void OnFxEvent(AudioClip clip)
    {
        Effect.clip = clip;
        Effect.Play();
    }

}
