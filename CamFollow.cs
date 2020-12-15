using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    private Player _player;
    private Controller _cont;
    private Vector2 _mapPos;
    private const float _offSet = 4.45f;


    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _cont = GameObject.Find("GameControl").GetComponent<Controller>();
        DontDestroyOnLoad(gameObject);
    }

    void FixedUpdate()
    {
        Follow();
    }

    private void Follow()
    {

        _mapPos = _cont.MapPosition();

        transform.position = new Vector3(Mathf.Clamp(_player.transform.position.x, _mapPos.x + _offSet, -_mapPos.x - _offSet), Mathf.Clamp(_player.transform.position.y, 0f, 200f), -10f);

    }


}
