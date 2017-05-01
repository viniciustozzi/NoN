using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffPlayformBehaviour : MonoBehaviour {

    public float timeToOff;
    public Light[] lights;
    
    public float time, timeToBlink;

	// Use this for initialization
	void Start () {

        lights = GetComponentsInChildren<Light>();
        time = 0;

        timeToBlink = time / 4;
	}
	
	// Update is called once per frame
	void Update () {

        time += Time.deltaTime;

        if (time > timeToBlink)
        {
            Blink();
        }

        if (time > timeToOff)
        {
            time = 0;
            GameController.lastSwitch.TurnOff();
        }

	}

    public void Blink()
    {
        foreach (Light l in lights)
        {
            l.intensity = 10;
        }

        Invoke("StopBlink", .1f);

        timeToBlink += (timeToOff - timeToBlink) / 4;
    }

    public void StopBlink()
    {
        foreach (Light l in lights)
        {
            l.intensity = 4;
        }
    }
}
