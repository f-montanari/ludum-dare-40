using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

    public float velocity = 3f;
    public float jumpForce = 10f;
    public float gravityMultiplier = 1.25f;
    public float gravityTreshold = 0.5f;
    public AudioSource mainAudio;
    public AudioClip jumpClip;
    public AudioClip deathClip;

    private bool grounded = true;
    private Collider2D interaction;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Movement
        float xInput = Input.GetAxis("Horizontal");
        Vector2 currentVelocity = new Vector2(xInput * velocity, rb.velocity.y);
        rb.velocity = currentVelocity;

        if(Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity += Vector2.up * jumpForce;
            grounded = false;
            mainAudio.clip = jumpClip;
            mainAudio.Play();
        }

        if(rb.velocity.y <= gravityTreshold)
        {
            rb.velocity += Vector2.down * gravityMultiplier;
        }

        // Interaction
        if(Input.GetButtonDown("Interact") && interaction != null)
        {
            InteractableComponent inte = interaction.gameObject.GetComponent<InteractableComponent>();
            inte.InteractStart();
        }

        if (Input.GetButtonUp("Interact") && interaction != null)
        {
            InteractableComponent inte = interaction.gameObject.GetComponent<InteractableComponent>();
            inte.InteractStop();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        if(collision.gameObject.tag == "Enemy")
        {
            Death();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        InteractableComponent inter = collision.GetComponent<InteractableComponent>();
        if (inter != null)
        {
            interaction = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision == interaction)
        {
            interaction = null;
        }
    }

    private void Death()
    {
        mainAudio.clip = deathClip;
        mainAudio.Play();
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        Destroy(this);
    }
}
