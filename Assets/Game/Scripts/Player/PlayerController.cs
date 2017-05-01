using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed, jumpForce;
    public Transform groundCheck;
    public LayerMask layer;

    private Animator m_anim;
    private Rigidbody2D m_rig;
    
	void Start () {

        m_anim = GetComponent<Animator>();
        m_rig = GetComponent<Rigidbody2D>();
		
	}
	
    private void FixedUpdate()
    {
        m_rig.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, m_rig.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            CheckGround();
        }
    }

    private void CheckGround()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, layer))
        {
            transform.SetParent(null);
            m_rig.AddForce(transform.up * jumpForce);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (collision.tag == "Switch")
            {
                collision.GetComponent<SwitchController>().TurnOn();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Platform")
        {
            transform.SetParent(collision.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.tag == "Platform")
        {
            transform.SetParent(null);
        }
    }
}
