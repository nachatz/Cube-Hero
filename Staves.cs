using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staves : MonoBehaviour, IWeapon
{
    private delegate void ObjectSetup();
    private ObjectSetup _objectSetup;
    private Player _player;
    private const float _staveOffset = 1 / 2f;
    private const float _stavePos = 1 / 2f;
    private const float _sheathAngle = 0f;
    private const float _moveAngle = 45f;
    [SerializeField] private Sprite[] _sprs = new Sprite[3];


    // Use this for initialization
    void Start ()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _objectSetup = Follow; _objectSetup += CheckSprite;
        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        _objectSetup();

    }

    public void CheckSprite()
    {
        if (GameObject.Find("Player").GetComponent<PlayerStats>().StavesLevel >= 20 && GameObject.Find("Player").GetComponent<PlayerStats>().StavesLevel < 40)
            GetComponent<SpriteRenderer>().sprite = _sprs[1];
        else if (GameObject.Find("Player").GetComponent<PlayerStats>().StavesLevel >= 40)
            GetComponent<SpriteRenderer>().sprite = _sprs[2];
        else
            GetComponent<SpriteRenderer>().sprite = _sprs[0];
    }

    public void Follow()
    {
        if (MovingRight())
        {
            transform.position = new Vector3(_player.transform.position.x + _stavePos + _player.move * _staveOffset, _player.transform.position.y, -1f);
            SetTransform();
        }
        else if (MovingLeft())
        {
            transform.position = new Vector3(_player.transform.position.x - _stavePos + _player.move * _staveOffset, _player.transform.position.y, -1f);
            SetTransform();
        }
        else
            SheathWeapon();

        if (MovingRight())
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180f, transform.eulerAngles.z);
        else if (MovingLeft())
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0f, transform.eulerAngles.z);
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
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, _sheathAngle);

        if (Input.GetKey(KeyCode.RightControl))
        {
            switch (_player.right)
            {
                case true:
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, _moveAngle);
                    transform.position = new Vector3(_player.transform.position.x + _stavePos + _player.move * _staveOffset, _player.transform.position.y, -1f);
                    break;
                case false:
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, _moveAngle);
                    transform.position = new Vector3(_player.transform.position.x - _stavePos + _player.move * _staveOffset, _player.transform.position.y, -1f);
                    break;
            }

        }
        else
            switch (_player.right)
            {
                case true:
                    transform.position = new Vector3(_player.transform.position.x + _stavePos, _player.transform.position.y, -1f);
                    break;
                case false:
                    transform.position = new Vector3(_player.transform.position.x - _stavePos, _player.transform.position.y, -1f);
                    break;
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
