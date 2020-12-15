using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bows : MonoBehaviour, IWeapon
{
    private delegate void Positioner();
    private Positioner _objectSetup;
    private SpriteRenderer _whichBow;
    private Player _player;
    [SerializeField] private Sprite[] _sprs = new Sprite[3];
    private const float _sheathAngle = -58.5f;
    private const float _moveAngle = 0f;
    private const float _bowOffset = 1 / 4f;
    private const float _bowSheathPos = 1 / 3f;
    private const float _bowPos = 1 / 2f;

    // Use this for initialization
    void Start ()
    {
         _objectSetup = Follow; _objectSetup += CheckSprite;
        _player = GameObject.Find("Player").GetComponent<Player>();
        _whichBow = GetComponent<SpriteRenderer>();

        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        _objectSetup();


    }

    public void CheckSprite()
    {
        if (GameObject.Find("Player").GetComponent<PlayerStats>().BowsLevel >= 20 && GameObject.Find("Player").GetComponent<PlayerStats>().BowsLevel < 40)
            _whichBow.sprite = _sprs[1];
        else if (GameObject.Find("Player").GetComponent<PlayerStats>().BowsLevel >= 40)
            _whichBow.sprite = _sprs[2];
        else
            _whichBow.sprite = _sprs[0];
    }

    public void Follow()
    {
        if (MovingRight())
        {
            transform.position = new Vector3(_player.transform.position.x + _bowPos + _player.move * _bowOffset, _player.transform.position.y, -1f);
            SetTransform();
        }
        else if (MovingLeft())
        {
            transform.position = new Vector3(_player.transform.position.x - _bowPos + _player.move * _bowOffset, _player.transform.position.y, -1f);
            SetTransform();
        }
        else
            SheathWeapon();


        if (MovingRight())
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0f, transform.eulerAngles.z);
        else if (MovingLeft())
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180f, transform.eulerAngles.z);
        else
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    public void SetTransform()
    {
        if (_player.move >= 0.1f || _player.move <= -0.1f)
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, _moveAngle);
    }

    public void SheathWeapon()
    {
        if (Input.GetKey(KeyCode.RightControl))
        {
            switch (_player.right)
            {
                case true:
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, _moveAngle);
                    transform.position = new Vector3(_player.transform.position.x + _bowPos + _player.move * _bowOffset, _player.transform.position.y, -1f);
                    break;
                case false:
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, _moveAngle);
                    transform.position = new Vector3(_player.transform.position.x - _bowPos + _player.move * _bowOffset, _player.transform.position.y, -1f);
                    break;
            }

        }
        else 
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, _sheathAngle);

            switch (_player.right)
            {
                case true:
                    transform.position = new Vector3(_player.transform.position.x + _bowSheathPos, _player.transform.position.y - _bowSheathPos, -1f);
                    break;
                case false:
                    transform.position = new Vector3(_player.transform.position.x - _bowSheathPos, _player.transform.position.y - _bowSheathPos, -1f);
                    break;
            }
        }

    }

    private bool MovingRight()
    {
        return true ? _player.move >= 0.1f : false;
    }
    private bool MovingLeft()
    {
        return true ? _player.move <= -0.1f : false;
    }
}
