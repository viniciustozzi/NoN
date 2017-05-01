using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBehaviour : MonoBehaviour {

    public Transform returnSpawn;

    private Rigidbody2D m_rig;

    private void Start()
    {
        m_rig = GetComponent<Rigidbody2D>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Death")
        {
            transform.position = returnSpawn.position;
            m_rig.velocity = Vector3.zero;
        }
    }
}
