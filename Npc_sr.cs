using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc_sr : MonoBehaviour
{
    public Dropdown _statReset;
    [SerializeField] private Canvas _image;

    private void FixedUpdate()
    {
        switch (_statReset.value)
        {
            case 0:
                break;
            case 1:
                _statReset.value = 0;
                break;
            case 2:
                _statReset.value = 0;
                Instantiate(_image);
                break;
        }

    }


}
