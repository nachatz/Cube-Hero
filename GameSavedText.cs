using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSavedText : MonoBehaviour
{
    Vector3 Scale;

    private void Awake()
    {
        Scale = transform.localScale;
        Scale.x = 1;
    }

    // Update is called once per frame
    void Update ()
    {
        GetComponent<TextMesh>().fontSize -= 2;
        if (GetComponent<TextMesh>().fontSize <= 0)
            Destroy(gameObject);


        transform.localScale = Scale;
	}
}
