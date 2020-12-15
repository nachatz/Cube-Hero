using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int enemies = 0;
    private int _howMany = 3;
    [SerializeField] private GameObject _enemy;

	
	// Update is called once per frame
	void Update ()
    {
        if (enemies < _howMany)
        {
            Instantiate(_enemy);
            enemies++;

        }
	}
}
