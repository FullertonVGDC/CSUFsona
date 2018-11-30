using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class player_range_attack_basic : MonoBehaviour
{

    public int speed = 5;
    public float max_distance = 7f;
    public KeyCode range_attack_hotkey = KeyCode.C;
    Coroutine current_attack;

    //How long(in milliseconds) does it take for hotkey_holded_iterator to increase by 1
    private float charging_attack_tick_delay = 0.1f;

    private int hotkey_holded_iterator;

    private GameObject current_projectile;


    public  Vector3 offset_of_char_holding = new Vector3(-1f, 0.5f, 0);

    Vector3 target_location;

    /* I don't know how we want to implement the charging mechanic 
     * My assumption is that we are doing three levels weak, medium and strong 
     * If assumption is wrong than this part of the code has to change
     * DEFAULT VALUES
     * Medium = 1 second of charging ( hotkey_holded_iterator = 10)
     * Strong = 3 second of charging ( hotkey_holded_iterator = 30)
     * Anything below medium is weak and anything above strong will just remain strong
     */

    public int min_medium_charge_time = 10, min_strong_charge_time = 30;



    public GameObject projectile_prefab;
    private Projectile projectile_script;

    // Use this for initialization
    void Start()
    {
 

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(range_attack_hotkey))
        {
            current_projectile = (GameObject)Instantiate(projectile_prefab, transform.position + offset_of_char_holding, Quaternion.identity);
            projectile_script = current_projectile.GetComponent<Projectile>();
            current_attack = StartCoroutine(Charging_Attack());
            target_location = current_projectile.transform.position + new Vector3(max_distance, 0, 0);
        }

        if (Input.GetKeyUp(range_attack_hotkey))
        {
            Shoot_projectile();
        }

    }
    
    IEnumerator Charging_Attack()
    {
        hotkey_holded_iterator = 0;
        while (true)
        {
            if (hotkey_holded_iterator < min_medium_charge_time)
            {
                current_projectile.GetComponent<SpriteRenderer>().color = Color.green;
            }
            else if (hotkey_holded_iterator >= min_medium_charge_time && hotkey_holded_iterator < min_strong_charge_time)
            {
                current_projectile.GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            else
            {
                current_projectile.GetComponent<SpriteRenderer>().color = Color.red;
            }
            //print(hotkey_holded_iterator);
            yield return new WaitForSeconds(charging_attack_tick_delay);
            hotkey_holded_iterator += 1;
        }
    }

    private void Shoot_projectile()
    {
        StopCoroutine(current_attack);

        projectile_script.Set_target_location(target_location);
        projectile_script.Set_speed(speed);
        projectile_script.Projectile_thrown();

    }

}



