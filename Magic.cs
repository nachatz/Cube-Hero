using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    private float _magicSpeed = 0.2f;
    private bool _right;
    private Player _player;
    private float _lifeTime = 5f;
    

    // Use this for initialization
    void Start ()
    {
        Destroy(gameObject, _lifeTime);
        _player = GameObject.Find("Player").GetComponent<Player>();
        switch (_player.right)
        {
            case true:
                _right = true;
                break;
            case false:
                _right = false;
                break;
        }
        transform.position = _player.transform.position;
        Physics2D.IgnoreCollision(GameObject.Find("Player").GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        switch (_right)
        {
            case true:
                transform.position = new Vector2(transform.position.x + _magicSpeed, transform.position.y);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0f, 90f);
                break;
            case false:
                transform.position = new Vector2(transform.position.x - _magicSpeed, transform.position.y);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180f, 90f);
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.GetComponent<GeneralEnemy>().TakeDamage(coll.gameObject.GetComponent<GeneralEnemy>().CalculateDamage);
        }
    }
}
