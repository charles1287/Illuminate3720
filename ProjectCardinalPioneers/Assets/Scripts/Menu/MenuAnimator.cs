using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAnimator : MonoBehaviour
{

    GameObject _player;

    Button[] _buttons;
    bool _menuOn = false;
    float _menuSpeed = 0.1f;

    void Awake()
    {
        _player = GameObject.Find("Player");

        _buttons = GetComponentsInChildren<Button>(true);
        transform.localScale = Vector3.zero;
    }

    //Turns off when player goes a certain distance away
    void Update()
    {
        if(_menuOn && Vector2.Distance(_player.transform.position, transform.position) > 10)
            StartCoroutine("TurnOff");
    }

    //Callback for when the icon is clicked
    //Opens or closes the menu smoothly
    public void IconClicked()
    {
        if (!_menuOn)
        {
            StartCoroutine("TurnOn");
        }
        else
        {
            StartCoroutine("TurnOff");
        }
    }

    void Set_buttonsInteractable(bool interactable)
    {
        for(int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].interactable = interactable;
        }
    }

    IEnumerator TurnOn()
    {
        StopCoroutine("TurnOff");
        _menuOn = true;

        while(transform.localScale.x < 1)
        {
            transform.localScale += new Vector3(_menuSpeed, _menuSpeed);
            yield return null;
        }
        Set_buttonsInteractable(true);
        transform.localScale = Vector3.one;
    }

    IEnumerator TurnOff()
    {
        StopCoroutine("TurnOn");
        _menuOn = false;
        Set_buttonsInteractable(false);

        while (transform.localScale.x > 0)
        {
            transform.localScale -= new Vector3(_menuSpeed, _menuSpeed);
            yield return null;
        }
        transform.localScale = Vector3.zero;
    }
}
