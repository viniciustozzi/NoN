using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    private Transform mPlayer;

    void Start()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = new Vector3(mPlayer.position.x, mPlayer.position.y, transform.position.z);
    }

}
