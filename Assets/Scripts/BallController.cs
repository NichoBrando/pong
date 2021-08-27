using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private float speed = 10;
    private int orientationX = 1;
    private int orientationY = 1;

    [SerializeField]
    private Rigidbody2D body;

    void GetNewYOrientation()
    {
        int newOrientation = Random.Range(-5, 3);
        if(newOrientation < 0) {
            orientationY = -1;
        }
        else {
            orientationY = 1;
        }
    }

    void ResetBall()
    {
        transform.position = new Vector3(0, 0, 0);
        speed = 10;
        orientationX = -orientationX;
        GetNewYOrientation();
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(orientationX, orientationY) * speed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            orientationX = -orientationX;
            GetNewYOrientation();
            speed += 1;
        }
        orientationY = -orientationY;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        bool wasMadeByPlayer1 = other.gameObject.tag == "Player 1" ? false : true;
        ResetBall();
        GameController gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        gameController.updateScore(wasMadeByPlayer1);
    }
}
