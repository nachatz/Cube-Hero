using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    private Transform _mapEdge;
    public string WeaponAlive { get; private set; }
    public string Name;
    private static bool _alive;
    public bool portalRight { get; private set; }
    // Use this for initialization
    void Start()
    {
        if (!_alive)
        {
            DontDestroyOnLoad(gameObject);
            _alive = true;
        }
        else
            Destroy(gameObject);
    }


    public Vector2 MapPosition()
    {
        _mapEdge = GameObject.Find("First").GetComponent<Transform>();

        return _mapEdge.transform.position;
    }

    private void FixedUpdate()
    {
        GameObject.Find("Stats").GetComponent<PlayerStatsDisplayer>().SetText();
        print(WeaponAlive);
        if (GameObject.Find("Swords(Clone)") != null)
        {
            WeaponAlive = "Swords";
        }
        else if (GameObject.Find("Bows(Clone)") != null)
        {
            WeaponAlive = "Bows";
        }
        else if (GameObject.Find("Staves(Clone)") != null)
        {
            WeaponAlive = "Staves";
        }
        else
            WeaponAlive = null;


        if (GameObject.Find("Player").GetComponent<Player>().transform.position.x > 0f)
            portalRight = true;
        else
            portalRight = false;

    }

    public void SetName()
    {
        if (GameObject.Find("Namer").GetComponent<Text>().text == "What's my name...")
            Name = "Unknown";
        else
            Name = GameObject.Find("Namer").GetComponent<Text>().text;

    }
    public void SetNameLoad(string name)
    {
        this.Name = name;
      

    }
}
