using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour {

    public GameObject[] turnOn;
    public GameObject[] turnOff;
    public float speed;

    public bool on, off, turned;
    public List<SpriteRenderer> spritesNeon = new List<SpriteRenderer>();
    public List<SpriteRenderer> spritesNeoff = new List<SpriteRenderer>();

	// Use this for initialization
	void Start () {

        FillSprite();
		
	}
	
	// Update is called once per frame
	void Update () {

        if(on)
        {
            for (int i = 0, j = 0; i < spritesNeon.Count || j < spritesNeoff.Count ; i++, j++)
            {
                if (i < spritesNeon.Count)
                {
                    spritesNeon[i].color += new Color(0, 0, 0, speed * Time.deltaTime);

                    if (spritesNeon[i].color.a >= 1)
                    {
                        on = false;
                        DesligarOff();
                    }
                }

                if (j < spritesNeoff.Count)
                {
                    spritesNeoff[i].color -= new Color(0, 0, 0, speed * Time.deltaTime);
                }
            }
        }

        else if(off)
        {
            foreach(SpriteRenderer s in spritesNeon)
            {
                s.color -= new Color(0, 0, 0, speed * Time.deltaTime);

                if(s.color.a <= 0)
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

        if (turned)
        {
            if (GameController.lastSwitch != null)
                GameController.lastSwitch.TurnOff();

            GameController.lastSwitch = this;
            on = true;
            Ligar();
        }
        else
        {
            GameController.lastSwitch = null;
            off = true;
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
                s.color = new Color(s.color.r, s.color.g, s.color.b, 0);
            }

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
        off = true;
    }
}
