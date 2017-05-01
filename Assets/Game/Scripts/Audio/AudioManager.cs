using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip menuPart;
    public AudioClip firstPart1;
    public AudioClip firstPart2;
    public AudioClip firstPart3;
    public AudioClip secondPart;
    public AudioClip thirdPart;

    private AudioSource mAudioSource;

    private static AudioManager mInstance;

    public static AudioManager Instance
    {
        get
        {
            if (mInstance == null)
                mInstance = FindObjectOfType<AudioManager>();

            if (mInstance == null)
            {
                GameObject audioManagerGo = new GameObject();
                audioManagerGo.name = "AudioManager";
                audioManagerGo.AddComponent<AudioManager>();
            }

            return mInstance;
        }
    }

    void Awake()
    {
        mAudioSource = FindObjectOfType<AudioSource>();

        if (mAudioSource == null)
            mAudioSource = gameObject.AddComponent<AudioSource>();

        DontDestroyOnLoad(this);
    }

    public void PlayMenuMusic()
    {
        mAudioSource.clip = menuPart;
        mAudioSource.loop = true;
        mAudioSource.Play();
    }

    public AudioClip PlayFirstPart1()
    {
        Debug.Log(mAudioSource == null);
        mAudioSource.PlayOneShot(firstPart1);
        return firstPart1;
    }

    public void PlayFirstPart2()
    {
        mAudioSource.clip = firstPart2;
        mAudioSource.loop = true;
        mAudioSource.Play();
    }

    public void PlayFirstPart3()
    {
        mAudioSource.PlayOneShot(firstPart3);
    }

    public void PlaySecondPart()
    {
        mAudioSource.clip = secondPart;
        mAudioSource.loop = true;
        mAudioSource.Play();
    }

    public void PlayThirdPart()
    {
        mAudioSource.clip = thirdPart;
        mAudioSource.loop = true;
        mAudioSource.Play();
    }

    #region TESTE!!!!


    //private void Update()
    //{
      
    //}


    #endregion
}