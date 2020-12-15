using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc_cw : MonoBehaviour
{

    public Dropdown _weapons;
    [SerializeField] private GameObject _swords;
    [SerializeField] private GameObject _staves;
    [SerializeField] private GameObject _bows;
    private GameObject _currentWeapon;
    private Canvas _show;
    [SerializeField] private Canvas _weaponProgression;

    private void Awake()
    {
        if (GameObject.Find("Swords(Clone)") != null)
            Destroy(GameObject.Find("Swords(Clone)"));

        if (GameObject.Find("Staves(Clone)") != null)
            Destroy(GameObject.Find("Staves(Clone)"));

        if (GameObject.Find("Bows(Clone)") != null)
            Destroy(GameObject.Find("Bows(Clone)"));



    }

    private void FixedUpdate()
    {
        ChangeWeapon(_weapons.value);
    }


    public void ChangeWeapon(int n)
    {
        switch (n)
        {
            case 0:
                break;
            case 1:
                Destroy(_currentWeapon);
                _currentWeapon = Instantiate(_bows);
                _weapons.value = 0;
                break;
            case 2:
                Destroy(_currentWeapon);
                _currentWeapon = Instantiate(_staves);
                _weapons.value = 0;          
                break;
            case 3:
                Destroy(_currentWeapon);
                _currentWeapon = Instantiate(_swords);
                _weapons.value = 0;
                break;
        }
    }


}
