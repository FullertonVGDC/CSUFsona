using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BossBehavior : MonoBehaviour {
    public GameObject enemyprojectile;
    Coroutine current_attack;

    public int speed = 5;
    public float max_distance = 7f;

    private GameObject current_projectile;

    private Rigidbody2D rb;
    private Collider2D cd;
    private Projectile projectile_script;
    private Vector3 target_location;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<Collider2D>();
        InvokeRepeating("Shoot_Projectile", 0.1f, 1);
	}
	
	// Update is called once per frame
	void Update () {

        walk();
    }
    private void walk()
    {
        float movement = -1f * 5f;
        rb.velocity = new Vector2(movement, rb.velocity.y);
        
    }
    private void Shoot_Projectile()
    {
            current_projectile = (GameObject)Instantiate(enemyprojectile, transform.position + new Vector3(-1, 1, 0), Quaternion.identity);
            projectile_script = current_projectile.GetComponent<Projectile>();
            target_location = current_projectile.transform.position + new Vector3(-max_distance, 0, 0);
            projectile_script.Set_target_location(target_location);
            projectile_script.Set_speed(speed);
            projectile_script.Projectile_thrown();
    }
}
