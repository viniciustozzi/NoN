using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehaviour : MonoBehaviour
{

    public AudioClip dragSound;

    private AudioSource mAudioSource;

    private void Start()
    {
        mAudioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (!mAudioSource.isPlaying)
            {
                mAudioSource.clip = dragSound;
                mAudioSource.Play();
            }
        }
    }
}
