using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CameraFollower : MonoBehaviour {
    public Transform follower;
    public Vector3 offset;
    protected Vector3 velocity;
    protected float smoothTime = 0.5f;
    // Start is called before the first frame update
    void Start ( ) {

    }

    // Update is called once per frame
    void LateUpdate ( ) {
        Vector3 temp= new Vector3(follower.position.x,follower.position.y,offset.z);
        Vector3 newPos = Vector3.SmoothDamp (transform.position, temp, ref velocity, smoothTime);
        transform.position = newPos;
    }
}
