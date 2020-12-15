using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private string WhatScene;
    private float _min;
    private float _max;

    private void Start()
    {
        _min = transform.position.x - 1f;
        _max = transform.position.x + 1f;
    }

    private void FixedUpdate()
    {
        if (GameObject.Find("Player") != null)
            if(GameObject.Find("Player").GetComponent<Player>().transform.position.x >= _min && GameObject.Find("Player").GetComponent<Player>().transform.position.x <= _max)
                if (Input.GetKeyDown(KeyCode.UpArrow))
                    SceneManager.LoadScene(WhatScene);
    }
}
