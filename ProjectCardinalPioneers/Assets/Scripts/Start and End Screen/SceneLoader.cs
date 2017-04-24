using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    GameObject _mainMenu;
    GameObject _credits;

    void Start()
    {
        _mainMenu = GameObject.Find("MainMenu");
        _credits = GameObject.Find("Credits");
        _credits.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("MainGame");
    }
    
    public void Credits()
    {
        _mainMenu.SetActive(false);
        _credits.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Back()
    {
        _mainMenu.SetActive(true);
        _credits.SetActive(false);
    }
}
