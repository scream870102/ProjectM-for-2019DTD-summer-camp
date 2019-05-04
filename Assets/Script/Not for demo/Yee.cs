using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Yee : MonoBehaviour {

    public float speed;
    public Rigidbody2D rb;
    bool bFacingRight;
    void Start ( ) {
        bFacingRight = false;
    }

    void Update ( ) {
        if (rb != null) {
            Vector2 movement = bFacingRight?Vector2.right : Vector2.left;
            rb.velocity = movement * speed * Time.deltaTime;
        }

    }

    private void OnTriggerExit2D (Collider2D other) {
        if (other.gameObject.tag == "Ground")
            Flip ( );
    }
    
    void Flip ( ) {
        bFacingRight = !bFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
