using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaver : MonoBehaviour
{
    public bool Loaded { get; private set; }
    //                                          0          1             2              3              4          5          6          7              8
    private string[] _stats = new string[9] { "health", "truLevel", "bowsLevel", "swordsLevel", "stavesLevel", "xpBows", "xpSwords", "xpStaves", "resistance" };
    private string _name = "Name";
    private string _saved = "IsSaved";
    private bool _alive;


    private void Start()
    {
        if (!_alive)
        {
            DontDestroyOnLoad(gameObject);
            _alive = true;
        }
        else
            Destroy(gameObject);



    }
    public void SaveGame()
    {
        if (GameObject.Find("Player") != null)
        {
            PlayerPrefs.SetInt(_stats[0], GameObject.Find("Player").GetComponent<PlayerStats>().Health);
            PlayerPrefs.SetInt(_stats[1], GameObject.Find("Player").GetComponent<PlayerStats>().TruLevel);
            PlayerPrefs.SetInt(_stats[2], GameObject.Find("Player").GetComponent<PlayerStats>().BowsLevel);
            PlayerPrefs.SetInt(_stats[3], GameObject.Find("Player").GetComponent<PlayerStats>().SwordsLevel);
            PlayerPrefs.SetInt(_stats[4], GameObject.Find("Player").GetComponent<PlayerStats>().StavesLevel);
            PlayerPrefs.SetFloat(_stats[5], GameObject.Find("Player").GetComponent<PlayerStats>().XpBows);
            PlayerPrefs.SetFloat(_stats[6], GameObject.Find("Player").GetComponent<PlayerStats>().XpSwords);
            PlayerPrefs.SetFloat(_stats[7], GameObject.Find("Player").GetComponent<PlayerStats>().XpStaves);
            PlayerPrefs.SetFloat(_stats[8], GameObject.Find("Player").GetComponent<PlayerStats>().Resistance);
            PlayerPrefs.SetString(_name, GameObject.Find("GameControl").GetComponent<Controller>().Name);
            PlayerPrefs.SetString(_saved, "YES");
        }
    }

    public void LoadGame()
    {
        GameObject.Find("Player").GetComponent<PlayerStats>().GameLoaded(_stats);
        GameObject.Find("GameControl").GetComponent<Controller>().SetNameLoad(PlayerPrefs.GetString(_name));
    }

    public void CheckLoad(GameObject _popup)
    {
        if (PlayerPrefs.GetString(_saved) == "YES")
        {
            GameObject.Find("SceneChanger").GetComponent<LoadingScreen>().LoadLevel();
            Loaded = true;

        }else
        {
            GameObject.Find("Canvas").GetComponent<HelpPopup>().PopUp(_popup);
        }
    }
}

