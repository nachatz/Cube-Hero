using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_01 : GeneralEnemy
{

    private Rigidbody2D _physics;
    private bool _onGround;
    private float _speed;
    private Controller _cont;
    private Vector2 _mapPos;
    private bool _spawned;

    [SerializeField] private GameObject _statBar;
    private GameObject _statBarAlive;

    private void Awake()
    {
        transform.position = new Vector2(Random.Range(-15f, 15f), transform.position.y);

    }

    // Use this for initialization
    void Start ()
    {
        _health = 120;
        _resistance = 4;
        _level = 5;
        damage = 6;
        _healthStat = _health;

        _cont = GameObject.Find("GameControl").GetComponent<Controller>();
        _physics = GetComponent<Rigidbody2D>();
        _speed = Random.Range(-3f, 3f);
        StartCoroutine(Movement());
        StartCoroutine(Jump());
    }

    private void FixedUpdate()
    {
        if(transform.position.y < -10f)
            transform.position = new Vector2(Random.Range(-15f, 15f), 20f);


        _mapPos = _cont.MapPosition();
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, _mapPos.x, -_mapPos.x), transform.position.y);
        _physics.velocity = new Vector2(_speed, _physics.velocity.y);

        if (!_spawned)
        {
            _spawned = true;
            _statBarAlive = Instantiate(_statBar, new Vector3(transform.position.x - 0.8f, transform.position.y + 1f), Quaternion.identity, transform);
            if (GameObject.Find("Player").GetComponent<PlayerStats>().TruLevel < _level)
                _statBarAlive.GetComponent<TextMesh>().color = Color.red;
            else
                _statBarAlive.GetComponent<TextMesh>().color = Color.blue;

            _statBarAlive.GetComponent<TextMesh>().text = "Lvl: " + 5 + "   " + 5 + "/" + 5 + "   [" + 5 + "]";
        }

        _statBarAlive.GetComponent<TextMesh>().text = "Lvl: " + _level + "   " + _health + "/" + _healthStat + "   [" + _resistance + "]";

    }


    IEnumerator Movement()
    {
        yield return new WaitForSeconds(Random.Range(0f, 10f));
        _speed = Random.Range(-3f, 3f);
        StartCoroutine(Movement());

    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(Random.Range(5f, 15f));
        _physics.AddForce(Vector2.up * 250f);
        StartCoroutine(Jump());

    }

}
