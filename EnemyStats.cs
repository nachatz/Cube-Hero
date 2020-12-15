using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private GameObject _statBar;
    private GameObject _statBarAlive;
    private bool _spawned;

	// Update is called once per frame
	void FixedUpdate ()
    {
        if (!_spawned)
        {
            _statBarAlive = Instantiate(_statBar, new Vector3(transform.position.x - 0.8f, transform.position.y + 1f), Quaternion.identity, transform);
            if (GameObject.Find("Player").GetComponent<PlayerStats>().TruLevel < 5)
                _statBarAlive.GetComponent<TextMesh>().color = Color.red;
            else
                _statBarAlive.GetComponent<TextMesh>().color = Color.black;

            _statBarAlive.GetComponent<TextMesh>().text = "Lvl: " + 5 + "   " + 5 + "/" + 5 + "   [" + 5 + "]";
        }

    _statBarAlive.GetComponent<TextMesh>().text = "Lvl: " + 5 + "   " + 5 + "/" + 5 + "   [" + 5 + "]";
	}
}
