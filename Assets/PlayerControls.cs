using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public float speed = 10f;
    public float boundY = 3.5f;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        var velocity = rb2d.velocity;
        if (Input.GetKey(moveUp)) {
            velocity.y = speed;
        } else if (Input.GetKey(moveDown)) {
            velocity.y = -speed;
        } else {
            velocity.y = 0;
        }
        rb2d.velocity = velocity;

        var pos = transform.position;
        if (pos.y > 2.5f) {
            pos.y = 2.5f;
        } else if (pos.y < -2.5f) {
            pos.y = -2.5f;
        } 
        transform.position = pos;
    }
}
