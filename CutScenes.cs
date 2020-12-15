using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScenes : MonoBehaviour
{

    private float _time;
    [SerializeField] private float _changeSceneTime;
    [SerializeField] private string _scene;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _time = _time + Time.deltaTime;
        if (_time > _changeSceneTime)
            SceneManager.LoadScene(_scene);
    }
}
