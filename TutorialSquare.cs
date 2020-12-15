using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSquare : MonoBehaviour
{
    public bool Jumped { get; private set; }
    public bool Moved { get; private set; }
    public bool OnGround { get; private set; }

    private void Start()
    {
        OnGround = true;
        Moved = false;
        Jumped = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -6.6f, 6.6f), transform.position.y);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) )
        {
            transform.position = new Vector2(transform.position.x - 0.1f, transform.position.y);
            Moved = true;

        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector2(transform.position.x + 0.1f, transform.position.y);
            Moved = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && OnGround && Moved || Input.GetKeyDown(KeyCode.UpArrow) && OnGround && Moved)
        {
            OnGround = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y + 5f);
            Jumped = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnGround = true;
    }

}
