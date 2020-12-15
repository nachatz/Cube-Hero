using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Wait(6));
	}


    IEnumerator LoadAsyc(string name)
    {
        AsyncOperation _load = SceneManager.LoadSceneAsync(name);

        while (!_load.isDone)
        {
            float progress = Mathf.Clamp01(_load.progress / 9f);
            GameObject.Find("LoadingBar").GetComponent<Slider>().value = progress;
            yield return null;
        }

    }

    IEnumerator Wait(int time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(LoadAsyc("lvl_town01"));
    }
}
