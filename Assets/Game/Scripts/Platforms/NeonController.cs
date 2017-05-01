using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeonController : MonoBehaviour {
    
    private SpriteRenderer[] sprites;
    private bool turnOn, turnOff;
    private float speed;

	// Use this for initialization
	void Start () {

        sprites = GetComponentsInChildren<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {


		
	}

    public void TurnOn(float speed)
    {
        this.speed = speed;
        turnOn = true;
        turnOff = false;
    }

    public void TurnOff(float speed)
    {
        this.speed = speed;
        turnOff = true;
    }
}
