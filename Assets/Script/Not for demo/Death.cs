using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour {
    private void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "Enemy") {
            SceneManager.LoadScene (0);
        }
    }
}
