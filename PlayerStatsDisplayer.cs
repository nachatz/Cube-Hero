using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStatsDisplayer : MonoBehaviour
{
    private Text _stats;
    private void Start()
    {
        _stats = GetComponent<Text>();
        SetText();

    }
    public void SetText()
    {
        string wep = GameObject.Find("GameControl").GetComponent<Controller>().WeaponAlive;
        switch (wep)
        {
            case "Swords":
                _stats.text =
                string.Format("TruLevel: {0}    Weapon Level: {1}    XP: {2}/{3}",
                GameObject.Find("Player").GetComponent<PlayerStats>().TruLevel,
                GameObject.Find("Player").GetComponent<PlayerStats>().SwordsLevel,
                GameObject.Find("Player").GetComponent<PlayerStats>().XpSwords,
                GameObject.Find("Player").GetComponent<PlayerStats>().MaxXpCalculate(GameObject.Find("Player").GetComponent<PlayerStats>().SwordsLevel));
                break;
            case "Staves":
                _stats.text =
                string.Format("TruLevel: {0}    Weapon Level: {1}    XP: {2}/{3}",
                GameObject.Find("Player").GetComponent<PlayerStats>().TruLevel,
                GameObject.Find("Player").GetComponent<PlayerStats>().StavesLevel,
                GameObject.Find("Player").GetComponent<PlayerStats>().XpStaves,
                GameObject.Find("Player").GetComponent<PlayerStats>().MaxXpCalculate(GameObject.Find("Player").GetComponent<PlayerStats>().StavesLevel));
                break;
            case "Bows":
                _stats.text =
                string.Format("TruLevel: {0}    Weapon Level: {1}    XP: {2}/{3}",
                GameObject.Find("Player").GetComponent<PlayerStats>().TruLevel,
                GameObject.Find("Player").GetComponent<PlayerStats>().BowsLevel,
                GameObject.Find("Player").GetComponent<PlayerStats>().XpBows,
                GameObject.Find("Player").GetComponent<PlayerStats>().MaxXpCalculate(GameObject.Find("Player").GetComponent<PlayerStats>().BowsLevel));
                break;
            default:
                _stats.text =
                string.Format("TruLevel: {0}    Weapon Level:    XP:",
                GameObject.Find("Player").GetComponent<PlayerStats>().TruLevel);
                break;
    }
    }
}
