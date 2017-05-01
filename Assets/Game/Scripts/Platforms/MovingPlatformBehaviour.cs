using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBehaviour : MonoBehaviour {

    public Transform[] positions;
    public float speed;

    private int index;

	// Use this for initialization
	void Start () {
        index = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
        
        transform.position = Vector3.MoveTowards(transform.position, positions[index].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, positions[index].position) < 0.2f)
        {
            index++;

            if (index >= positions.Length)
            {
                index = 0;
            }
        }

    }
}
