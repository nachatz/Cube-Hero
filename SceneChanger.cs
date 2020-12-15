using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private GameObject _fadeOut;

	public void ChangeScene(string name)
    {
        Instantiate(_fadeOut);
        StartCoroutine(Wait(name));

    }

    IEnumerator Wait(string name)
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(name);

    }

    public void QuitGame()
    {
        Application.Quit();

    }
}
