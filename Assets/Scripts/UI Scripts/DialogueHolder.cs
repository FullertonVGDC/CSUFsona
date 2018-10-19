using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

    public string dialogue;
    private DialogueManager dman;

	// Use this for initialization
	void Start () {
        dman = FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                dman.ShowBox(dialogue);
            }
        }
    }

}
