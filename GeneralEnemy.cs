using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralEnemy : MonoBehaviour
{
    protected int _health;
    protected int _resistance;
    public int damage;
    protected int _level;
    public int EnemyLevel { get { return _level; } }
    protected int _healthStat;
    public delegate int Calculate();
    public delegate float CalculateXP();
    Calculate CalcDmg;
    CalculateXP CalcXp;
    [SerializeField] private GameObject _display;
    //[SerializeField] private GameObject _statBar;
    //protected GameObject _statBarAlive;

    private const float TruLevelXpMod = 0.85f;
    private const float EnemyXpMod = 3.5f;
    private const float WepXpMod = 3f;
    private const int BowDmgMod = 50;
    private const int SwordsDmgMod = 80;
    private const int StavesDmgMod = 20;
    private const int TruLvlDmgMod = 2;



    // Use this for initialization
    void Start ()
    {
        CalcDmg = CalculateDamage;
        CalcXp = CalculateXp;

    }

    public void TakeDamage(Calculate calc)
    {
        int dmg = calc();
        GameObject c = Instantiate(_display, transform.position, Quaternion.identity, transform);
        c.GetComponent<TextMesh>().text = dmg.ToString();
        _health -= dmg;
        if (_health <= 0)
        {
            GameObject.Find("Spawner").GetComponent<EnemySpawner>().enemies--;
            Destroy(gameObject);
            GiveExperience(CalculateXp);
        }
    }

    public void GiveExperience(CalculateXP calc)
    {
        float xp = calc();
        switch (GameObject.Find("GameControl").GetComponent<Controller>().WeaponAlive)
        {
            case "Swords":
                GameObject.Find("Player").GetComponent<PlayerStats>().XpGain(xp, "Swords");
                break;
            case "Staves":
                GameObject.Find("Player").GetComponent<PlayerStats>().XpGain(xp, "Staves");
                break;
            case "Bows":
                GameObject.Find("Player").GetComponent<PlayerStats>().XpGain(xp, "Bows");
                break;
            default:
                print("No weapon found");
                break;
        }
    }

    public int CalculateDamage()
    {
        int dmg;
        switch (GameObject.Find("GameControl").GetComponent<Controller>().WeaponAlive)
        {
            case "Swords":
                dmg = (((GameObject.Find("Player").GetComponent<PlayerStats>().SwordsLevel) / _level) * SwordsDmgMod);
                break;
            case "Staves":
                dmg = (((GameObject.Find("Player").GetComponent<PlayerStats>().StavesLevel) / _level) * StavesDmgMod);
                break;
            case "Bows":
                dmg = (((GameObject.Find("Player").GetComponent<PlayerStats>().BowsLevel) / _level) * BowDmgMod);
                break;
            default:
                dmg = 0;
                break;
        }
        dmg = dmg - _resistance + (int)Random.Range(0, 110) + GameObject.Find("Player").GetComponent<PlayerStats>().TruLevel * TruLvlDmgMod;
        if (dmg < 0)
            return dmg = 1;
        else
            return dmg;

    }

    public float CalculateXp()
    {

        float xp = (_level * EnemyXpMod) - (GameObject.Find("Player").GetComponent<PlayerStats>().TruLevel * TruLevelXpMod + WepXpMod * WhichWeapon()) + (int)Random.Range(0,10f);
        if (xp <= 0)
            return xp = 1f;
        else
            return xp;
    }

    private int WhichWeapon()
    {
        switch (GameObject.Find("GameControl").GetComponent<Controller>().WeaponAlive)
        {
            case "Swords":
                return GameObject.Find("Player").GetComponent<PlayerStats>().SwordsLevel;
            case "Staves":
                return GameObject.Find("Player").GetComponent<PlayerStats>().BowsLevel;
            case "Bows":
                return GameObject.Find("Player").GetComponent<PlayerStats>().StavesLevel;
            default:
                return 0;
        }

    }

    public int Damage()
    {
        return damage;
    }


}
