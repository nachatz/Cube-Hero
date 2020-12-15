using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerTransform : MonoBehaviour
{

    // Use this for initialization
    void Awake()
    {
        if(GameObject.Find("Player") != null)
            if(GameObject.Find("GameControl").GetComponent<Controller>().portalRight)
                GameObject.Find("Player").GetComponent<Player>().transform.position = new Vector2(transform.position.x, transform.position.y);
            else
                GameObject.Find("Player").GetComponent<Player>().transform.position = new Vector2(-transform.position.x, transform.position.y);
    }

}
