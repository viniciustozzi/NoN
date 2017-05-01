using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeLevelOneMusic : MonoBehaviour
{

    void Start()
    {
        int rdm = Random.RandomRange(0, 3);


        switch (rdm)
        {
            case 0:
                PlayFirst();
                break;

            case 1:
                AudioManager.Instance.PlaySecondPart();
                break;

            case 2:
                AudioManager.Instance.PlayThirdPart();
                break;
        }
    }

    public void PlayFirst()
    {
        AudioClip clip = AudioManager.Instance.PlayFirstPart1();

        Invoke("PlayPart2", clip.length - 0.5f);
    }

    void PlayPart2()
    {
        AudioManager.Instance.PlayFirstPart2();
    }
}
