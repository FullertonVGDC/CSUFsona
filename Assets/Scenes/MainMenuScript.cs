using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization

    public void startlevel()
    {
        SceneManager.LoadScene("Scene", LoadSceneMode.Single);
    }

    public void quitegame()
    {
        Application.Quit();
    }

    public void credits()
    {
        SceneManager.LoadScene("CreditScene", LoadSceneMode.Single);
    }
}
