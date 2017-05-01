using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{

    public GameObject[] turnOn;
    public GameObject[] turnOff;
    public float speed;
    public bool button, starton, dontChangeLast, endSwitch;
    public AudioClip switchOnAudio;
    public AudioClip switchOffAudio;
    public Transform player;
    public Animator animEnd;

    private bool on, off, turned;
    private List<SpriteRenderer> spritesNeon = new List<SpriteRenderer>();
    private List<SpriteRenderer> spritesNeoff = new List<SpriteRenderer>();

    private AudioSource mAudioSource;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        FillSprite();

        mAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (on)
        {
            for (int i = 0; i < spritesNeon.Count || i < spritesNeoff.Count; i++)
            {
                if (i < spritesNeon.Count)
                {
                    spritesNeon[i].color += new Color(0, 0, 0, speed * Time.deltaTime);

                    if (spritesNeon[i].color.a >= 1)
                    {
                        on = false;
                    }
                }

                if (i < spritesNeoff.Count)
                {
                    spritesNeoff[i].color -= new Color(0, 0, 0, speed * Time.deltaTime);

                    if (spritesNeoff[i].color.a > 0)
                        on = true;
                }
            }

            if (!on)
                DesligarOff();
        }

        else if (off)
        {
            foreach (SpriteRenderer s in spritesNeon)
            {
                s.color -= new Color(0, 0, 0, speed * Time.deltaTime);

                if (s.color.a <= 0)
                {
                    off = false;
                    DesligarOn();
                }
            }
        }
    }

    public void DesligarOn()
    {
        foreach (GameObject g in turnOn)
        {
            g.SetActive(false);
        }
    }

    public void DesligarOff()
    {
        foreach (GameObject g in turnOff)
        {
            g.SetActive(false);
        }
    }

    public void Ligar()
    {
        foreach (GameObject g in turnOn)
        {
            g.SetActive(true);
        }
    }

    public void TurnOn()
    {
        turned = !turned;

        player.GetComponent<DeathBehaviour>().returnSpawn = transform;

        if (!endSwitch)
        {

            if (turned)
            {
                if (GameController.lastSwitch != null && !dontChangeLast)
                    GameController.lastSwitch.TurnOff();

                GameController.lastSwitch = this;
                on = true;
                Ligar();

                mAudioSource.clip = switchOnAudio;
                mAudioSource.Play();
            }
            else if (!button && !turned)
            {
                GameController.lastSwitch = null;
                off = true;

                mAudioSource.clip = switchOffAudio;
                mAudioSource.Play();
            }
        }

        else
        {
            animEnd.SetTrigger("End");
        }
    }

    public void FillSprite()
    {
        foreach (GameObject t in turnOn)
        {
            SpriteRenderer[] spriteToAdd = t.GetComponentsInChildren<SpriteRenderer>();

            foreach (SpriteRenderer s in spriteToAdd)
            {
                spritesNeon.Add(s);

                if (!starton)
                    s.color = new Color(s.color.r, s.color.g, s.color.b, 0);
            }

            if (!starton)
                t.SetActive(false);
        }


        foreach (GameObject t in turnOff)
        {
            SpriteRenderer[] spriteToAdd = t.GetComponentsInChildren<SpriteRenderer>();

            foreach (SpriteRenderer s in spriteToAdd)
            {
                spritesNeoff.Add(s);
            }
        }
    }


    public void TurnOff()
    {
        turned = false;
        off = true;
    }
}
