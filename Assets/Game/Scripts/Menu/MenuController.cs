using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Sprite brilha;

    public Image imgLogo;
    public Text text;
    public AudioClip playSound;
    public AudioClip logoOn;

    private AudioSource mAudioSource;

    void Start()
    {
        text.gameObject.SetActive(false);
        AudioManager.Instance.PlayMenuMusic();

        mAudioSource = GetComponent<AudioSource>();

        Invoke("highlight", 1.5f);
    }

    public void highlight()
    {
        mAudioSource.PlayOneShot(logoOn);
        imgLogo.sprite = brilha;
        Invoke("showText", 0.8f);
    }

    public void showText()
    {
        text.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mAudioSource.clip = playSound;
            mAudioSource.Play();
            Invoke("GoToGame", 0.7f);
        }
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("TestScene");
    }
}
