using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shurikenThrow : MonoBehaviour {
    private GameObject projectile;
    private Vector3 target_location;
    private float speed;

    private bool in_motion = false;

    // Use this for initialization
    void Start () {

        Collider2D collder = gameObject.GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if(in_motion)
        {
            transform.position = Vector3.MoveTowards(transform.position, target_location, speed * Time.deltaTime);
        }

        if(transform.position == target_location)
        {
            Destroy(gameObject);
        }
		
	}

    public void Projectile_thrown()
    {
        in_motion = true;
    }

    public void Set_target_location(Vector3 target_location)
    {
        this.target_location = target_location;
    }

    public void Set_speed(float speed)
    {
        this.speed = speed;
    }
}
