using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxColl;
    private Animator anim;
    private SpriteRenderer sprite;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask jumpGround;
    
    [SerializeField] private AudioSource jumpSound;

    private enum MoveState{idle, running, jump, fall}

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxColl = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSound.Play();
        }
        UpdateAnimation();

    }

    private void UpdateAnimation()
    {
        MoveState state;
        if (dirX > 0f)
        {
            state  = MoveState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state  = MoveState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MoveState.idle;
        }

        if( rb.velocity.y > .1f ){
            state = MoveState.jump;
        }else if(rb.velocity.y < -.1f){
            state = MoveState.fall;
        }

        anim.SetInteger("state", (int)state);
    }


    private bool isGrounded(){
        return Physics2D.BoxCast(boxColl.bounds.center, boxColl.bounds.size, 0f, Vector2.down, .1f, jumpGround);
    }
}
