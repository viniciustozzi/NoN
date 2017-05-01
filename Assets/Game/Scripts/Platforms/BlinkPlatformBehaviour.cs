using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkPlatformBehaviour : MonoBehaviour {

    public GameObject[] platforms;
    public float timeToChange;
    public int index;

    private float time;
    
	// Use this for initialization
	void Start () {

        time = 0;

        index = 0;
        
        foreach (GameObject g in platforms)
        {
            g.SetActive(false);
        }

        platforms[index].SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {

        time += Time.deltaTime;

        if(time > timeToChange)
        {
            platforms[index].SetActive(false);
            index++;

            if (index >= platforms.Length)
                index = 0;

            platforms[index].SetActive(true);

            time = 0;
        }
	}
}
