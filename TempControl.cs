using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TempControl : MonoBehaviour
{
    public string Name;


    // Use this for initialization
    void Start ()
    {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(GameObject.Find("GameControl") != null)
        {
            GameObject.Find("GameControl").GetComponent<Controller>().Name = this.Name;
            Destroy(gameObject);
        }

		
	}
    public void SetName()
    {
        if (GameObject.Find("Namer").GetComponent<InputField>().text.Trim() == "")
            Name = "Unknown";
        else
            Name = GameObject.Find("Namer").GetComponent<InputField>().text;

    }
}
