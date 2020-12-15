using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuBar : MonoBehaviour
{
    private Dropdown _dropdown;
    [SerializeField] private GameObject _saved;
    [SerializeField] private GameObject _menu;

    // Use this for initialization
    void Start ()
    {
        _dropdown = GetComponent<Dropdown>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch (_dropdown.value)
        {
            case 0:
                break;
            case 4:
                GameObject.Find("Player").GetComponent<Player>().transform.position = new Vector2(0f, 0f);
                _dropdown.value = 0;
                break;
            case 1:
                GameObject.Find("GameSaver").GetComponent<GameSaver>().SaveGame();
                Instantiate(_saved, GameObject.Find("Gs_spawn").GetComponent<Transform>().transform);
                _dropdown.value = 0;
                break;
            case 3:
                if(SceneManager.GetActiveScene().name != "lvl_town01")
                    SceneManager.LoadScene("lvl_town01");
                _dropdown.value = 0;
                break;
            case 5:
                Application.Quit();
                break;
            case 2:
                if (GameObject.Find("StatMenu 1(Clone)") == null)
                    Instantiate(_menu, _menu.transform.position, Quaternion.identity);
                _dropdown.value = 0;
                break;
        }
		
	}


    public void Create()
    {
        Instantiate(_menu);
    }
}
