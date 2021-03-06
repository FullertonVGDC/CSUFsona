﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {
    float walkSpeed = 9;
    Rigidbody2D rigid;
    float lockPos = 0;
    float jumpForce = 20;
    int jumpCount = 0;
    int maxJumps = 1;
    public bool isOnGround = false;
    public bool isDoubleJump = true;

    public GameObject shurikenPrefab;
    public Transform shurikenSpawn;
    public Camera myCam;

    private Animator anim;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
        //player = GetComponent<Animator>();
        jumpCount = maxJumps;
        anim = gameObject.GetComponent<Animator>();
        
		
	}

    // Update is called once per frame
    void Update() {

        Walk();
        transform.rotation = Quaternion.Euler(lockPos, lockPos, lockPos);
       // Jump(); doesn't do jack no more
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
        CameraView();
        Animation();
        BadEnding();
    }

    private void Walk()
    {
        float movement = Input.GetAxis("Horizontal") * walkSpeed;
        bool pressed = Input.GetButton("Horizontal");
        rigid.velocity = new Vector3(movement, rigid.velocity.y, 0);

    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isDoubleJump)
            {
                isDoubleJump = false;
                rigid.velocity = new Vector2(0, jumpForce);
            }
            //if(isOnGround)
            {
                isOnGround = false;
                isDoubleJump = true;
                rigid.velocity = new Vector2(0, jumpForce);

            }


           // rigid.velocity = new Vector2(0, jumpForce);
            //jumpCount = 1;
           // isGrounded = false;

           // waitTime();

        }
        
    }
/*
    private void waitTime()
    {
        int i = 3;
        i--;
        if(i == 0)
        {
            isGrounded = true;
            i = 3;
        }
    }*/
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ("Ground") && isGrounded == false)
        {
            isGrounded = true;
        }
    }
    */
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            jumpCount = maxJumps;
        }
    }
    */
    void Fire()
    {
        var shuriken = (GameObject)Instantiate(shurikenPrefab, shurikenSpawn.position, shurikenSpawn.rotation);

        shuriken.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);//shuriken.transform.forward * 6;

        Destroy(shuriken, 2.0f);
    }

    void CameraView()
    {
        if (rigid.position.x > 10)
        {
            myCam.orthographicSize = 10;
           // myCam.fieldOfView = 100;
        } else
        {
            myCam.orthographicSize = 7;
        }
    }

    void Animation()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetBool("rightKeyPressed", true);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool("rightKeyPressed", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetBool("leftKeyPressed", true);
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetBool("leftKeyPressed", false);
        }
    }

    public void BadEnding()
    {
        if (rigid.position.y < -100)
        {
            SceneManager.LoadScene("BadEnd");
        }
    }
}
