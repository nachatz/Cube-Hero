using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatMenuController : MonoBehaviour
{



    public void Destroy()
    {
        Destroy(GameObject.Find("StatMenu 1(Clone)"));   
    }


}
