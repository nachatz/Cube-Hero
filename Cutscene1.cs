using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscene1 : MonoBehaviour
{
    [SerializeField] private GameObject _text;
    [SerializeField] private GameObject _star;
    [SerializeField] private GameObject _fade;

	// Use this for initialization
	void Start ()
    {
        InstantiateText("\"One day, I'll be a star in the sky\"");
        StartCoroutine(One(15));
        StartCoroutine(Star(10));
    }

    private void InstantiateText(string s)
    {
        GameObject text = Instantiate(_text);
        GameObject.Find("Words").GetComponent<Text>().text = s;
        Destroy(text, 10f);
    }

    IEnumerator Star(int time)
    {
        yield return new WaitForSeconds(time);
        GameObject star = Instantiate(_star);
    }

    IEnumerator One(int time)
    {
        yield return new WaitForSeconds(time);
        InstantiateText("Don't fear the demons in your heart");
        StartCoroutine(Two(10));
    }

    IEnumerator Two(int time)
    {
        yield return new WaitForSeconds(time);
        InstantiateText("Don't fear the wrath of your God");
        StartCoroutine(Three(10));
    }

    IEnumerator Three(int time)
    {
        yield return new WaitForSeconds(time);
        InstantiateText("Don't fear the monsters in the night");
        StartCoroutine(Four(10));
    }

    IEnumerator Four(int time)
    {
        yield return new WaitForSeconds(time);
        Instantiate(_fade);
        StartCoroutine(Five(5));
    }
    IEnumerator Five(int time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("cutscene2");
    }
}
