using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    private bool _stopped1;
    private Text _text;
    // Use this for initialization
    void Start()
    {
        _text = GetComponent<Text>();
    }

    private void FixedUpdate()
    {
        if (!_stopped1)
        {
            if (!GameObject.Find("Square").GetComponent<TutorialSquare>().Moved)
            {
                _text.text = "Move left with 'A' and Right with 'D'\n" +
                "You may also use the Arrow Keys";
            }
            if (GameObject.Find("Square").GetComponent<TutorialSquare>().Moved)
            {
                _text.text = "Jump with the Space key";

            }
            if (GameObject.Find("Square").GetComponent<TutorialSquare>().Jumped)
            {

                _text.text = "You can attack with the Right Control when you choose a weapon";
                StartCoroutine(WaitThenChange(5, "You progress in two different ways, TruLevel & Weapon Level"));
            }
        }


    }

    IEnumerator WaitThenChange(int time, string text)
    {
        yield return new WaitForSeconds(time);
        ChangeText(text);

    }

    private void ChangeText(string text)
    {
        _stopped1 = true;
        _text.text = text;
        ChangeText1();
    }

    private void ChangeText1()
    {
        StartCoroutine(WaitThenChange2(8, "TruLevel is your overall level. It will increase your damage with all weapons as well as increase your resistance"));
    }

    IEnumerator WaitThenChange2(int time, string text)
    {
        yield return new WaitForSeconds(time);
        ChangeText2(text);

    }

    private void ChangeText2(string text)
    {
        _text.text = text;
        ChangeText3();
    }

    private void ChangeText3()
    {
        StartCoroutine(WaitThenChange3(8, "Your Weapon Level will determine the majority of the damage you deal. You can always change weapons"));
    }

    IEnumerator WaitThenChange3(int time, string text)
    {
        yield return new WaitForSeconds(time);
        ChangeText4(text);

    }

    private void ChangeText4(string text)
    {
        _text.text = text;
        ChangeText5();
    }

    private void ChangeText5()
    {
        StartCoroutine(WaitThenChange4(8, "The Up arrow will allow you entry at portals. \n Good Luck!"));
    }

    IEnumerator WaitThenChange4(int time, string text)
    {
        yield return new WaitForSeconds(time);
        ChangeText6(text);

    }

    private void ChangeText6(string text)
    {
        _text.text = text;
    }

}
