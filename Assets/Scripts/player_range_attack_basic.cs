using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_range_attack_basic : MonoBehaviour
{

   // public int speed;
   // public float max_distance;
    public KeyCode range_attack_hotkey;
    Coroutine current_attack;

    //How long(in milliseconds) does it take for hotkey_holded_iterator to increase by 1
    private float charging_attack_tick_delay = 0.1f;
    private int hotkey_holded_iterator;


    /* I don't know how we want to implement the charging mechanic 
     * My assumption is that we are doing three levels weak, medium and strong 
     * If assumption is wrong than this part of the code has to change
     * DEFAULT VALUES
     * Medium = 1 second of charging ( hotkey_holded_iterator = 10)
     * Strong = 3 second of charging ( hotkey_holded_iterator = 30)
     * Anything below medium is weak and anything above strong will just remain strong
     */

    public int min_medium_charge_time = 10, min_strong_charge_time = 30;

    public GameObject projectile;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(range_attack_hotkey))
        { 
            current_attack = StartCoroutine(Charging_Attack());
        }

        if (Input.GetKeyUp(range_attack_hotkey))
        {
            print("hotkey released");
            StopCoroutine(current_attack);
            print("hotkey_holded_iterator = " + hotkey_holded_iterator);
        }
    }

    IEnumerator Charging_Attack()
    {
        hotkey_holded_iterator = 0;
        while (true)
        {
            print(hotkey_holded_iterator);
            yield return new WaitForSeconds(charging_attack_tick_delay);
            hotkey_holded_iterator += 1;
        }
    }

    private void shoot_projectile()
    {

    }

}



