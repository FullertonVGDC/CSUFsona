using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsBackground : MonoBehaviour {


	// Use this for initialization
	void Start () {
       
		
	}
	
	// Update is called once per frame
	void Update () {
        //spin
        // transform.Rotate(Vector3.right * Time.deltaTime);
        // transform.Rotate(Vector3.up * Time.deltaTime, Space.World);
        transform.Rotate(new Vector3(0, 0, 1));
	}
}
