using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Npc_Transporter : MonoBehaviour
{
    public Dropdown _places;



    private void FixedUpdate()
    {
        Transport(_places.value);
    }


    public void Transport(int n)
    {
        switch (n)
        {
            case 0:
                break;
            case 1:
                SceneManager.LoadScene("Kyfe_01");
                _places.value = 0;
                break;
            case 2:
                SceneManager.LoadScene("Orelia_01");
                _places.value = 0;
                break;
                //case 3:
                //    _playerSpr.color = Color.clear;
                //    _places.value = 0;
                //    break;
                //case 4:
                //    _playerSpr.color = Color.blue;
                //    _places.value = 0;
                //    break;
        }
    }
}
