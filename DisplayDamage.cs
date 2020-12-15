using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    public float lifeTime = 1f;
    public float speed = 0.1f;


	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + speed);
	}

    public void SetValue(int d)
    {
        GetComponent<TextMesh>().text = d.ToString();
    }

}
