using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaveAttack : MonoBehaviour
{
    [SerializeField] private GameObject _magic;
    private float _castTime = 2f;
    private float _countDown;
    private bool _canCast = true;
    public bool CanCast { get { return _canCast; } }
    [SerializeField] private AudioClip _magicSFX;
    private AudioSource _play;

    // Use this for initialization
    void Start()
    {
        _play = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckFireMagic();
        if (_countDown >= 0)
            PullCountDown();
        else
            _canCast = true;
    }

    private void CheckFireMagic()
    {
        if (Input.GetKeyDown(KeyCode.RightControl) && _canCast)
        {
            _play.PlayOneShot(_magicSFX);
            _canCast = false;
            Instantiate(_magic);
            _countDown = _castTime;
        }
    }

    private void PullCountDown()
    {
        _countDown = _countDown - Time.deltaTime;
    }
}
