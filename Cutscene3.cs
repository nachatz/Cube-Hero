using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscene3 : MonoBehaviour
{
    [SerializeField] private GameObject _fade;
    [SerializeField] private Canvas _loadingScreen;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Wait(7));
    }

    IEnumerator Wait(int time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Wait2(5));
    }

    IEnumerator Wait2(int time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(_fade);
        yield return new WaitForSeconds(time);
        Instantiate(_loadingScreen);
        StartCoroutine(Waizt(6));

    }

    IEnumerator Waizt(int time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(LoadAsyc("lvl_town01"));
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
}
