using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float move;
    [SerializeField] private AudioClip _jumpSFX;
    private AudioSource _play;
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _jumpHeight = 5f;
    private Vector2 _mapPos;
    private Vector3 _scale;

    private Rigidbody2D _physics;
    private GroundCheck _onGround;
    private Controller _cont;
    public bool moving;
    public bool right;

	// Use this for initialization
	void Start ()
    {
        _cont = GameObject.Find("GameControl").GetComponent<Controller>();
        _onGround = GameObject.Find("GroundCheck").GetComponent<GroundCheck>();
        _physics = GetComponent<Rigidbody2D>();
        _scale = transform.localScale;
        _play = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update ()
    {
        if(GameObject.Find("SR_confirm(Clone)") == null)
            Movement();
	}

    private void Movement()
    {
        transform.localScale = _scale;
        move = Input.GetAxis("Horizontal");
        Vector2 playerMove = new Vector2(move * _movementSpeed, _physics.velocity.y);
        _physics.velocity = playerMove;
        _mapPos = _cont.MapPosition();
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, _mapPos.x, -_mapPos.x), transform.position.y);
        if (move >= 0.01f) { right = true; _scale.x = 1f; }
        else if (move <= -0.01f) { right = false; _scale.x = -1f; }

        if (Input.GetKeyDown(KeyCode.Space) && _onGround.onGround)
        {
            _physics.velocity = new Vector2(_physics.velocity.x, _jumpHeight);
            _onGround.onGround = false;
            _play.PlayOneShot(_jumpSFX);
        }
        if (move == 0)
            moving = false;
        else
            moving = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            GameObject.Find("Player").GetComponent<PlayerStats>().TakeDamage(collision.gameObject.GetComponent<GeneralEnemy>().Damage());
    }
}
