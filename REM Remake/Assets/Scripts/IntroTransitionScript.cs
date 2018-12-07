using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroTransitionScript : MonoBehaviour {

    public void nextScene()
    {
        SceneManager.LoadScene("Intro2");
    }
    public void nextScene2()
    {
        SceneManager.LoadScene("FinalIntro");
    }
    public void finalScene()
    {
        SceneManager.LoadScene("gameScene");
    }

    public void goodEnding()
    {
        SceneManager.LoadScene("GoodEnd");
    }

    public void goodEndingpt2()
    {
        SceneManager.LoadScene("GoodEndpt2");
    }

    public void toMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void badEnding2()
    {
        SceneManager.LoadScene("BadEndpt2");
    }
}
