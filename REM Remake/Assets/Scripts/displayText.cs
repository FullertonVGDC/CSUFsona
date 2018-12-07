using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayText : MonoBehaviour {

    string text1 = "Am I... up in the clouds?";
    bool display;// = false;

	// Use this for initialization
	void Start () {
        display = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
  
  
    private void OnGUI()
    {
        if(display == true)
        {
            GUI.Box(new Rect(Screen.width/3, Screen.height-90, 500, 50), text1);
        }
    }
}
