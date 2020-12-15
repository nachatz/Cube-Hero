using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StatBars : MonoBehaviour
{
    private Slider _slider;
    private Text _text;
	// Use this for initialization
	void Start ()
    {
        if (gameObject.name == "HealthBar")
            _slider = GetComponent<Slider>();
        if (gameObject.name == "Name")
            _text = GetComponent<Text>();

		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(gameObject.name == "HealthBar")
            _slider.value = GameObject.Find("Player").GetComponent<PlayerStats>().Health;
        if (gameObject.name == "Name")
            _text.text = GameObject.Find("GameControl").GetComponent<Controller>().Name;
    }
}
