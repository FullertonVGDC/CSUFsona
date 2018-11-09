using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   //Used to set player movement speed
    public float moveSpeed;
    public int playerJumpPower = 1250;
    public string midjump = "n";
    //Gets components from Unity
    private Rigidbody2D myRigidbody;
    private Collider2D collide;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        collide = GetComponent<Collider2D>();
    }

    private void Update()
    {
        walk();
    }

    void walk()
    {
        float movement = Input.GetAxisRaw("Horizontal") * moveSpeed;
        myRigidbody.velocity = new Vector2(movement, myRigidbody.velocity.y);
        if (Input.GetButtonDown("Jump") && midjump == "n")
        {
            Jump();
            midjump = "y";
        }
        if (GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            midjump = "n";
        }
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
    }
}
