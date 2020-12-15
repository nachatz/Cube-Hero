using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc_cc : MonoBehaviour
{
    private SpriteRenderer _playerSpr;
    public Dropdown _colors;

    private void Start()
    {
        _playerSpr = GameObject.Find("Player").GetComponent<SpriteRenderer>();
    }    

    private void FixedUpdate()
    {
        ChangeColor(_colors.value);
    }


    public void ChangeColor(int n)
    {
        switch (n)
        {
            case 0:
                break;
            case 1:
                _playerSpr.color = Color.black;
                _colors.value = 0;
                break;
            case 2:
                _playerSpr.color = Color.grey;
                _colors.value = 0;
                break;
            case 3:
                _playerSpr.color = Color.clear;
                _colors.value = 0;
                break;
            case 4:
                _playerSpr.color = Color.blue;
                _colors.value = 0;
                break;
        }
    }
}
