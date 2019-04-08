using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    protected Animator animator = null;
    protected PlayerMovement movement = null;
    [HideInInspector]
    public string State;
    // Start is called before the first frame update
    private void Awake ( ) {
        animator = GetComponent<Animator> ( );
        movement = GetComponent<PlayerMovement> ( );
    }
    void Start ( ) {

    }

    // Update is called once per frame
    void Update ( ) {
        Render ( );
        switch (State) {
            case "IDLE":
                animator.SetBool ("PlayerJump", false);
                animator.SetBool ("PlayerRun", false);
                break;
            case "JUMP":
                animator.SetBool ("PlayerJump", true);
                break;
            case "WALK":
                animator.SetBool ("PlayerRun", true);
                break;
            default:
                break;
        }
    }
    protected void Render ( ) {
        Vector3 temp = transform.localScale;
        temp.x = movement.IsPlayerFacingRight?  Mathf.Abs (temp.x) : -Mathf.Abs (temp.x);
        transform.localScale = temp;
    }
}
