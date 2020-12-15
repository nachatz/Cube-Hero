using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    private float _arrowSpeed = 0.5f;
    private float _lifeTime = 15f;
    private Player _player;
    private Vector3 _scale;
    private bool _right;
    [SerializeField] private Sprite[] _sprs = new Sprite[3];
    private SpriteRenderer _whichArrow;




    // Use this for initialization
    void Start ()
    {
        _whichArrow = GetComponent<SpriteRenderer>();
        Physics2D.IgnoreCollision(GameObject.Find("Player").GetComponent<Collider2D>(), GetComponent<Collider2D>());
        _player = GameObject.Find("Player").GetComponent<Player>();
        Destroy(gameObject, _lifeTime);
        _scale = transform.localScale;
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
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Shoot();
        CheckSprite();
        transform.localScale = _scale;
    }

    private void Shoot()
    {
        switch (_right)
        {
            case true:
                transform.position = new Vector2(transform.position.x + _arrowSpeed, transform.position.y);
                _scale.x = 6f;
                break;
            case false:
                transform.position = new Vector2(transform.position.x - _arrowSpeed, transform.position.y);
                _scale.x = -6f;
                break;
        }

    }

    private void CheckSprite()
    {
        if (GameObject.Find("Player").GetComponent<PlayerStats>().BowsLevel >= 20 && GameObject.Find("Player").GetComponent<PlayerStats>().BowsLevel < 40)
            _whichArrow.sprite = _sprs[1];
        else if (GameObject.Find("Player").GetComponent<PlayerStats>().BowsLevel >= 40)
            _whichArrow.sprite = _sprs[2];
        else
            _whichArrow.sprite = _sprs[0];
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.GetComponent<GeneralEnemy>().TakeDamage(coll.gameObject.GetComponent<GeneralEnemy>().CalculateDamage);
        }
        Destroy(gameObject);
    }
}
