using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeLevelOneMusic : MonoBehaviour {

    void Start()
    {
        AudioClip clip = AudioManager.Instance.PlayFirstPart1();

        Invoke("PlayPart2", clip.length - 0.5f);
    }

    void PlayPart2()
    {
        AudioManager.Instance.PlayFirstPart2();
    }
}
