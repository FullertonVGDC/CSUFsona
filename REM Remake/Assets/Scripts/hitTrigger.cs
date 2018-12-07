using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hitTrigger : MonoBehaviour {

    public GameObject remmy;

    void OnTriggerEnter2D(Collider2D other)
    {
       // if (other.CompareTag("Player"));
        {
            Destroy(remmy);
            //SceneManager.LoadScene("MainMenu");
        }
    }
}
