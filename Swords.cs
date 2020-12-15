using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swords : MonoBehaviour, IWeapon
{
    private delegate void Positioner();
    private Positioner _objectSetup;
    private SpriteRenderer _whichSword;
    private Player _player;
    [SerializeField] private Sprite[] _sprs = new Sprite[5];
    private const float _sheathAngle = 96.4f;
    private const float _moveAngle = 45f;
    private const float _swordOffset = 1 / 2f;
    private SwordAttack _ss;

    // Use this for initialization
    void Start ()
    {
        // Delegate to use two functions at once
        _objectSetup += Follow; _objectSetup += SetTransform;

        _ss = GetComponent<SwordAttack>();

        _player = GameObject.Find("Player").GetComponent<Player>();
        _whichSword = GetComponent<SpriteRenderer>();
        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void LateUpdate ()
    {
        if (GameObject.Find("Player").GetComponent<PlayerStats>().SwordsLevel >= 10 && GameObject.Find("Player").GetComponent<PlayerStats>().SwordsLevel < 20)
            _whichSword.sprite = _sprs[1];
        else if (GameObject.Find("Player").GetComponent<PlayerStats>().SwordsLevel >= 20 && GameObject.Find("Player").GetComponent<PlayerStats>().SwordsLevel < 30)
            _whichSword.sprite = _sprs[2];
        else if (GameObject.Find("Player").GetComponent<PlayerStats>().SwordsLevel >= 30 && GameObject.Find("Player").GetComponent<PlayerStats>().SwordsLevel < 40)
            _whichSword.sprite = _sprs[3];
        else if (GameObject.Find("Player").GetComponent<PlayerStats>().SwordsLevel >= 40)
            _whichSword.sprite = _sprs[4];
        else
            _whichSword.sprite = _sprs[0];
    
        _objectSetup();
    }

    public void CheckSprite()
    {

    }

    public void Follow()
    {
        if (_ss._canAttack)
        {
            transform.position = new Vector3(_player.transform.position.x + _player.move * _swordOffset, _player.transform.position.y, -1f);
            if (MovingRight())
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180f, transform.eulerAngles.z);
            else if (!MovingRight())
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
        }
        else
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, _moveAngle);

            if (GameObject.Find("Player").GetComponent<Player>().transform.localScale.x == 1)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180f, transform.eulerAngles.z);
                transform.position = new Vector3(_player.transform.position.x + _player.move * _swordOffset + _swordOffset * 1.5f, _player.transform.position.y, -1f);

            }
            else if (GameObject.Find("Player").GetComponent<Player>().transform.localScale.x == -1)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
                transform.position = new Vector3(_player.transform.position.x + _player.move * _swordOffset - _swordOffset * 1.5f, _player.transform.position.y, -1f);

            }


        }
    }



    public void SetTransform()
    {
        if (_player.move >= 0.1f || _player.move <= -0.1f)
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, _moveAngle);
        else
            SheathWeapon();
    }

    public void SheathWeapon()
    {
        if (_ss._canAttack)
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, _sheathAngle);
    }


    private bool MovingRight()
    {
        return true ? _player.move >= 0.1f : false;
    }

}
