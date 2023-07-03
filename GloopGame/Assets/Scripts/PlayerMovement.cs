using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField]
    private LayerMask jumpableGround;

    private float dirX = 0f;

    [SerializeField]
    private float moveSpeed = 7f;

    [SerializeField]
    private float jumpForce = 14f;

    private enum MovementState
    {
        idle,
        running,
        jumping,
        falling
    }

    [SerializeField]
    private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        // Check if the Rigidbody is static, if it is, then the player is dead and can't move
        // This will stop console errors from appearing when the player dies
        if (rb.bodyType != RigidbodyType2D.Static)
        {
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
            UpdateAnimationState();
        }

    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (Input.GetButtonDown("Jump") && Isgrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSoundEffect.Play();
        }

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool Isgrounded()
    {
        return Physics2D.BoxCast(
            coll.bounds.center,
            coll.bounds.size,
            0f,
            Vector2.down,
            .1f,
            jumpableGround
        );
    }
}
