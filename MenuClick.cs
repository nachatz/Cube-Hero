using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuClick : MonoBehaviour
{
    [SerializeField] private AudioClip _clickSFX;
        private AudioSource _play;

    private void Start()
    {
        _play = GetComponent<AudioSource>();
    }
    public void PlayClickSound()
    {
        _play.PlayOneShot(_clickSFX);


    }
}
