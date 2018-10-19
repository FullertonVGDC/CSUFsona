using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dbox;
    public Text dtext;

    public bool dialogue_active;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (dialogue_active && Input.GetKeyDown(KeyCode.Space))
        {
            dbox.SetActive(false);
            dialogue_active = false;
        }
	}

    public void ShowBox(string dialogue)
    {
        dialogue_active = true;
        dbox.SetActive(true);
        dtext.text = dialogue;
    }

}
