using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed, jumpForce;
    public Transform groundCheck;
    public LayerMask layer;
    public AudioClip walkingSound;

    private Animator m_anim;
    private Rigidbody2D m_rig;
    private bool facingRight;

    private AudioSource mAudioSource;
    private bool isJumping;

    void Start()
    {
        m_anim = GetComponent<Animator>();
        m_rig = GetComponent<Rigidbody2D>();
        mAudioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        float hAxis = Input.GetAxis("Horizontal");

        m_rig.velocity = new Vector2(hAxis * speed, m_rig.velocity.y);
        m_anim.SetFloat("Speed", m_rig.velocity.magnitude);
        m_anim.SetBool("Jump", isJumping);

        if (hAxis < 0 && !facingRight)
            Flip();
        else if (hAxis > 0 && facingRight)
            Flip();

        if ((hAxis * speed > 1 || hAxis * speed < -1) && CheckGround())
        {
            if (!mAudioSource.isPlaying)
            {
                mAudioSource.clip = walkingSound;
                mAudioSource.Play();
            }
        }

        if (Input.GetButtonDown("Jump") && CheckGround())
        {
            Jump();
        }
    }

    private bool CheckGround()
    {
        return Physics2D.Linecast(transform.position, groundCheck.position, layer);
    }

    private void Jump()
    {
        isJumping = true;
        transform.SetParent(null);
        m_rig.velocity = new Vector2(m_rig.velocity.x, jumpForce);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (collision.tag == "Switch")
            {
                transform.SetParent(null);
                collision.GetComponent<SwitchController>().TurnOn();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Platform")
        {
            transform.SetParent(collision.transform);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground" || collision.transform.tag == "Platform")
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.transform.tag == "Platform")
        {
            transform.SetParent(null);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
