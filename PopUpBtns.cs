using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PopUpBtns : MonoBehaviour
{
	
    public void NoBtn_SR()
    {
        Destroy(GameObject.Find("SR_confirm(Clone)"));

    }

    public void YesBtn_SR()
    {
        GameObject.Find("Player").GetComponent<PlayerStats>().ResetStats();
        Destroy(GameObject.Find("SR_confirm(Clone)"));

    }

}


