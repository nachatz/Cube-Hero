using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene2 : MonoBehaviour
{
    [SerializeField] private GameObject _text;
    [SerializeField] private GameObject _fade;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(Wait(7));
	}
	
    IEnumerator Wait(int time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(_text);
        StartCoroutine(Wait2(5));

    }

    IEnumerator Wait2(int time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(_fade);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("cutscene3");

    }
}
