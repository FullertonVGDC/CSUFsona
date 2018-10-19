using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour {

    public GameObject dialogue_box;
    public Text dialogue_text;
    public string dialogue;
    public bool player_in_range;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyUp(KeyCode.Space) && player_in_range)
        {
            if (dialogue_box.activeInHierarchy)
            {
                dialogue_box.SetActive(false);
            } else
            {
                dialogue_box.SetActive(true);
                dialogue_text.text = dialogue;
            }
        }

	}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player in range.");

            player_in_range = true;

        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left range.");

            player_in_range = false;
            dialogue_box.SetActive(false);

        }
    }

}
