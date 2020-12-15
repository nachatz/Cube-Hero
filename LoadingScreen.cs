using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Canvas _loadingScreen;
    [SerializeField] private GameObject _fade;




    public void LoadLevel()
    {
        Instantiate(_fade);

        Instantiate(_loadingScreen);
        Destroy(GameObject.Find("Enter"));
        Destroy(GameObject.Find("Namer"));

        StartCoroutine(Wait(6));
    }

    public void LoadLevelNewGam()
    {
        Instantiate(_fade);

        Destroy(GameObject.Find("Enter"));
        Destroy(GameObject.Find("Namer"));

        StartCoroutine(Wait2(6));
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

    IEnumerator Wait2(int time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("cutscene1");
    }

}
