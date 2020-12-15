using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatMenu : MonoBehaviour
{

    private Text _stats;
    [SerializeField] private string aso;
    private PlayerStats _player;

	// Use this for initialization
	void Start ()
    {
        _stats = GetComponent<Text>();

        aso = gameObject.name;
        _player = GameObject.Find("Player").GetComponent<PlayerStats>();


    }
	
	// Update is called once per frame
	void Update ()
    {
        switch (aso)
        {
            case "SwordsStats":
                _stats.text = "Swords\nLevel: " + _player.SwordsLevel + "\nDamage: " + _player.SwordsLevel * 80;               
                break;
            case "StavesStats":
                _stats.text = "Staves\nLevel: " + _player.StavesLevel + "\nDamage: " + _player.StavesLevel * 20;
                break;
            case "BowsStats":
                _stats.text = "Bows\nLevel: " + _player.BowsLevel + "\nDamage: " + _player.BowsLevel * 50;
                break;
        }

		
	}

}
