using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpPopup : MonoBehaviour
{


    public void PopUp(GameObject _popup)
    {
        GameObject pop = Instantiate(_popup);
        
        Destroy(pop, 10f);


    }


}
