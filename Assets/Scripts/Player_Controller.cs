using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller: MonoBehaviour {

    public float moveSpeed;
    private Animator anim;
    public Vector2 last_move;
    private bool player_moving;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        player_moving = false;

        if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) 
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            last_move = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            player_moving = true;
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            last_move = new Vector2(0f, Input.GetAxisRaw("Vertical"));
                player_moving = true;
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetFloat("LastMoveX", last_move.x);
        anim.SetFloat("LastMoveY", last_move.y);
        anim.SetBool("PlayerMoving", player_moving);

    }
}
