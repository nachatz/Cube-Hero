using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpText : MonoBehaviour
{

    private TextMesh _text;
    [SerializeField] private string _message;
    [SerializeField] private float _minPos;
    [SerializeField] private float _maxPos;

    // Use this for initialization
    void Start()
    {
        _text = GetComponent<TextMesh>();
    }

    private void FixedUpdate()
    {
        if (GameObject.Find("Player").GetComponent<Player>().transform.position.x >= _minPos && GameObject.Find("Player").GetComponent<Player>().transform.position.x <= _maxPos)
            _text.text = _message;
        else
            _text.text = "";
    }
}
