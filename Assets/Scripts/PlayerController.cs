using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10;
    [SerializeField]
    private bool isFirstPlayer;
    [SerializeField]
    private Rigidbody2D body;

    float GetYAxis()
    {
        if(isFirstPlayer)
        {
            if(Input.GetKey(KeyCode.W)) return 1f;
            if(Input.GetKey(KeyCode.S)) return -1f;
        }
        else 
        {
            if(Input.GetKey(KeyCode.UpArrow)) return 1f;
            if(Input.GetKey(KeyCode.DownArrow)) return -1f;
        }
        return 0;
    }

    void Move()
    {
        float verticalInput = GetYAxis();
        body.velocity = new Vector2(0, verticalInput * speed);
    }

    void FixedUpdate()
    {
        Move();
    }
}
