using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleWeapon : MonoBehaviour
{
    private static bool _alive;
    [SerializeField] private Canvas _weaponProgression;


    public void ShowWeaponDisplay()
    {
        if (!_alive)
        {
            Instantiate(_weaponProgression);
            _alive = true;
        }

    }
    public void DestroyWeaponDisplay()
    {
        _alive = false;


        Destroy(GameObject.Find("WeaponProgression(Clone)"));

    }
}
