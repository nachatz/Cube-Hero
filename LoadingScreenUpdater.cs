using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenUpdater : MonoBehaviour
{
    private string[] _tips = new string[6];
    // Use this for initialization
    void Start()
    {
        _tips[0] = "Always make sure to save your progress!";
        _tips[1] = "Your TruLevel will increase your overall damage!";
        _tips[2] = "There is nothing permanent except change.";
        _tips[3] = "You can't blame gravity for falling in love.";
        _tips[4] = "A secret weapon? Nah..";
        _tips[5] = "The only true wisdom is in knowing you know nothing.";

        if (gameObject.name == "Loading(Clone)")
        {
            GameObject.Find("NameText").GetComponent<Text>().text = GameObject.Find("TempControl").GetComponent<TempControl>().Name;
            GameObject.Find("Tip").GetComponent<Text>().text = _tips[(int)Random.Range(0f, 5f)];
        }
        else if (gameObject.name == "Loading_MM(Clone)")
        {
            GameObject.Find("Name").GetComponent<Text>().text = PlayerPrefs.GetString("Name");
            GameObject.Find("Tip").GetComponent<Text>().text = _tips[(int)Random.Range(0f, 5f)];
        }
    }


}
