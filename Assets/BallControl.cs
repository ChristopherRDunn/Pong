using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        // If the ball manages to get past the collision on the top/bottom walls, reset it
        var pos = transform.position;
        if (pos.y > 10f || pos.y < -10f) {
            rb2d.velocity = Vector2.zero;
            transform.position = Vector2.zero;
            StartGame();
        }
    }

    void StartGame() {
        float rand = Random.Range(0, 2);
        float randY = Random.Range(-20, 20);

        if (rand == 0) {
            rb2d.AddForce(new Vector2(20, randY));
        } else {
            rb2d.AddForce(new Vector2(-20, randY));
        }
    }

    void ResetBall() {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame() {
        ResetBall();
        StartGame();
    }

    void OnCollisionEnter2D (Collision2D coll) {
        if (coll.collider.CompareTag("Player")) {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = vel;
        }
    }
}
