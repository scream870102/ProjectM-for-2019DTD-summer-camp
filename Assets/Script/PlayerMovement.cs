using System.Collections;
using System.Collections.Generic;

using UnityEngine;
//class define how player move
public class PlayerMovement : MonoBehaviour {
    //
    //
    //drag ref
    //
    //define which layer is ground
    public LayerMask groundLayer;
    //
    //
    //const
    //
    //damp for move
    private float smoothDamp = .05f;
    //ref velocity for smooth damp
    private Vector2 refVelocity = Vector2.zero;

    //
    //ref const
    public float basicSpeed;
    public float airSpeed;
    public int maxJump;
    public float jumpForce;
    public float speedBonus = 1.0f;
    public bool canAirControl;

    //
    //referrence
    protected Rigidbody2D rb = null;
    //transform for foot
    protected Transform detectGround = null;
    protected PlayerAnimation anim = null;
    //
    //
    //field
    //
    //bool for jumping state
    protected bool bJump;
    //bool for on ground
    protected bool bGround;
    public bool IsGround { get { return bGround; } }
    //store current jump time
    protected int numNowJump;
    //store horizontal velocity
    protected float moveHorizontal;
    //stoer what direction is player facing true=facing right direction false=facing left direction
    protected bool bFacingRight;
    //property for player direction
    public bool IsPlayerFacingRight { get { return bFacingRight; } }
    //set all info from props
    //set detectGround
    public void Awake ( ) {
        rb = GetComponent<Rigidbody2D> ( );
        detectGround = transform.Find ("Foot");
        anim = GetComponent<PlayerAnimation> ( );
        numNowJump = 0;
    }

    void Update ( ) {
        IsGrounded ( );
        //if player can controll get horizontal move
        //if player on ground set speed to airspeed
        if(bGround||canAirControl)
            moveHorizontal = Input.GetAxisRaw ("Horizontal") * (bGround?basicSpeed : airSpeed);
        //if player hit jump button call jump method
        if (Input.GetButtonDown ("Jump")) {
            Jump ( );
        }
    }

    //keep detect ground and call Move and Jump function 
    protected virtual void FixedUpdate ( ) {
        Move ( );
        InJump ( );
    }

    //if can jump set bJump to true bGround false plus numNowJump
    protected virtual void Jump ( ) {
        if (numNowJump < maxJump) {
            bJump = true;
            bGround = false;
            numNowJump++;
            anim.State = "JUMP";
        }
    }

    //get horiziontal velocity and move rigidbody call in fixed update
    protected virtual void Move ( ) {
        if (moveHorizontal > 0 ) {
            bFacingRight = true;
            if(anim.State!="JUMP")
                anim.State = "WALK";
        }
        else if (moveHorizontal < 0 ) {
            bFacingRight = false;
            if(anim.State!="JUMP")
                anim.State = "WALK";
        }
        else if (moveHorizontal == 0 && anim.State == "WALK") {
            anim.State = "IDLE";
        }
        Vector2 targetVelocity = new Vector2 (moveHorizontal * Time.fixedDeltaTime * speedBonus, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp (rb.velocity, targetVelocity, ref refVelocity, smoothDamp);
    }

    //if can jump add force to rigidbody  call in fixed update
    protected virtual void InJump ( ) {
        if (bJump) {
            Vector2 temp = rb.velocity;
            temp.y = 0.0f;
            rb.velocity = temp;
            rb.AddForce (new Vector2 (0f, jumpForce), ForceMode2D.Impulse);
            bJump = false;
        }
    }

    //keep detect if player is on ground if true set numOnojump to zero bGround = true
    protected void IsGrounded ( ) {
        if (detectGround != null) {
            Collider2D [ ] colliders = Physics2D.OverlapPointAll (detectGround.position, groundLayer);
            bGround = false;
            foreach (Collider2D collider in colliders) {
                if (collider != gameObject) {
                    numNowJump = 0;
                    bGround = true;
                    if (anim.State == "JUMP" && !(rb.velocity.y>.0f) ) {
                        anim.State = "IDLE";
                    }
                }
                else
                    bGround = false;
            }
        }
    }

}
