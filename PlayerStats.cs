using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int Health { get; private set; }
    public int TruLevel { get; private set; }
    public int BowsLevel { get; private set; }
    public int SwordsLevel { get; private set; }
    public int StavesLevel { get; private set; }
    public float XpBows { get; private set; }
    public float XpSwords { get; private set; }
    public float XpStaves { get; private set; }
    public float Resistance { get; private set; }
    private float XpToLevel;
    private float _destroyLvl = 5f;
    [SerializeField] private GameObject _display;
    [SerializeField] private GameObject _levelUp;
    [SerializeField] private AudioClip _lvlUp;
    private AudioSource _play;
    private bool _cantGetHit;

    private void Awake()
    {
        Health = 100;
        BowsLevel = 1;
        StavesLevel = 1;
        SwordsLevel = 1;
        TruLevel = 1;
        Resistance = 1;
        XpBows = 0;
        XpStaves = 0;
        XpSwords = 0;
    }

    private void Start()
    {
        _play = GetComponent<AudioSource>();

        if(GameObject.Find("GameSaver") != null)
            if (GameObject.Find("GameSaver").GetComponent<GameSaver>().Loaded)
                GameObject.Find("GameSaver").GetComponent<GameSaver>().LoadGame();



    }


    public void XpGain(float x, string weapon)
    {
        GameObject c = Instantiate(_display, transform.position, Quaternion.identity, transform);
        c.GetComponent<TextMesh>().text = x.ToString();
        c.GetComponent<TextMesh>().color = Color.blue;
        switch (weapon)
        {
            case "Swords":
                XpSwords += x;
                while (XpSwords >= MaxXpCalculate(SwordsLevel))
                {
                    GameObject b = Instantiate(_levelUp, transform.position, Quaternion.identity, transform);
                    Destroy(b, _destroyLvl);
                    XpSwords -= MaxXpCalculate(SwordsLevel);
                    SwordsLevel++;
                    TruLevel++;
                    Display();
                    Resistance = Resistance + 3;
                    Health = 100;
                    _play.PlayOneShot(_lvlUp);
                }
                break;
            case "Bows":
                XpBows += x;
                while (XpBows >= MaxXpCalculate(BowsLevel))
                {
                    GameObject b = Instantiate(_levelUp, transform.position, Quaternion.identity, transform);
                    Destroy(b, _destroyLvl);
                    XpBows -= MaxXpCalculate(BowsLevel);
                    BowsLevel++;
                    TruLevel++;
                    Display();
                    Resistance = Resistance + 1;
                    Health = 100;
                    _play.PlayOneShot(_lvlUp);
                }
                break;
            case "Staves":
                XpStaves += x;
                while (XpStaves >= MaxXpCalculate(StavesLevel))
                {
                    GameObject b = Instantiate(_levelUp, transform.position, Quaternion.identity, transform);
                    Destroy(b, _destroyLvl);
                    XpStaves -= MaxXpCalculate(StavesLevel);
                    StavesLevel++;
                    TruLevel++;
                    Display();
                    Resistance = Resistance + 1;
                    Health = 100;
                    _play.PlayOneShot(_lvlUp);
                }
                break;
        }
    }

    public float MaxXpCalculate(int weaponLevel)
    {
        float xpToLevel = 100.0f + weaponLevel * 30f;

        return xpToLevel;
    }

    private void Display()
    {
        GameObject c = Instantiate(_display, transform.position, Quaternion.identity, transform);
        c.GetComponent<TextMesh>().text = "Level Up";
        c.GetComponent<DisplayDamage>().lifeTime = 3f;
        c.GetComponent<DisplayDamage>().speed = 0.05f;
        c.GetComponent<TextMesh>().color = Color.green;

    }

    public void TakeDamage(int dmg)
    {
        if (Health <= 0)
        {
            Health = 100;
            XpBows = 0f;
            XpSwords = 0f;
            XpStaves = 0f;
            SceneManager.LoadScene("lvl_town01");

        }
        else 
        {
            if (!_cantGetHit)
            {
                StartCoroutine(ResetHit());
                print(dmg);
                _cantGetHit = true;
                int damage = (dmg - (int)Resistance);
                if (damage <= 0)
                    damage = 1;
                Health -= damage;
                if (Health > 100)
                    Health = 100;
            }
        }
    }

    public void ResetStats()
    {
        BowsLevel = 1;
        SwordsLevel = 1;
        StavesLevel = 1;
        XpBows = 0;
        XpSwords = 0;
        XpStaves = 0;

    }

    public void GameLoaded(string[] stats)
    {
        Health = PlayerPrefs.GetInt(stats[0]);
        TruLevel = PlayerPrefs.GetInt(stats[1]);
        BowsLevel = PlayerPrefs.GetInt(stats[2]);
        SwordsLevel = PlayerPrefs.GetInt(stats[3]);
        StavesLevel = PlayerPrefs.GetInt(stats[4]);
        XpBows = PlayerPrefs.GetFloat(stats[5]);
        XpSwords = PlayerPrefs.GetFloat(stats[6]);
        XpStaves = PlayerPrefs.GetFloat(stats[7]);
        Resistance = PlayerPrefs.GetFloat(stats[8]);

    }

    IEnumerator ResetHit()
    {
        yield return new WaitForSeconds(1);
        _cantGetHit = false;

    }
}
