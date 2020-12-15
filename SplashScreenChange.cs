using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenChange : MonoBehaviour
{
    private float _time;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        _time = _time + Time.deltaTime;
        if (_time > 5)
            SceneManager.LoadScene("OpeningScene");
	}
}
