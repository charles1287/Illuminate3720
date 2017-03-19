using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRefHandler : MonoBehaviour {

    GameObject player;

    GameObject _water;
    GameObject _ice;
    GameObject _power;
    GameObject _fuel;
    GameObject _food;

    public GameObject Menu;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Interact()
    {
        player.GetComponent<PlayerController>().enabled = false;
        Menu.SetActive(true);
    }

    public void Exit()
    {
        player.GetComponent<PlayerController>().enabled = true;
        Menu.SetActive(false);
    }
    
}
