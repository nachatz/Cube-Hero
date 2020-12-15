using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAttack : MonoBehaviour
{
    [SerializeField] private GameObject _arrows;
    [SerializeField] private AudioClip _arrowSFX;
    private AudioSource _play;
    private float _pullTime = 0.3f;
    private float _countDown;
    private bool _canShoot = true;
    public bool CanShoot { get { return _canShoot; } }

    // Use this for initialization
    void Start ()
    {
        _play = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update ()
    {
        CheckShootArrow();
        if (_countDown >= 0)
            PullCountDown();
        else
            _canShoot = true;
    }

    private void CheckShootArrow()
    {
        if (Input.GetKeyDown(KeyCode.RightControl) && _canShoot)
        {
            _canShoot = false;
            Instantiate(_arrows);
            _countDown = _pullTime;
            _play.PlayOneShot(_arrowSFX);
        }
    }

    private void PullCountDown()
    {

        _countDown = _countDown - Time.deltaTime;

    }

}
