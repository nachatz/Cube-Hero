using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static bool _alive;
	// Use this for initialization
	void Start ()
    {
        if (!_alive)
        {
            _alive = true;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
		
	}
	


}
