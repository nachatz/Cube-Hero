using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SwordAttack : MonoBehaviour
{

    [SerializeField] private LayerMask _isEnemy;
    private float _attackRange = 1f;
    private Transform _attackPos;
    private float _animReset = 1.5f;
    public float _time { get; private set; }
    public bool _canAttack;


    private AudioSource _play;
    [SerializeField] private AudioClip[] _swordsSFX = new AudioClip[3];

    // Use this for initialization
    void Start ()
    {
        _canAttack = true;
        _attackPos = GameObject.Find("AttackPosSwords").GetComponent<Transform>();

        _play = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update ()
    {
        Attack();
	}

    private void Attack()
    {
        if (_time > 0)
            ResetAnim();

        print(_time);

        if (Input.GetKeyDown(KeyCode.RightControl) && _canAttack)
            {
                _canAttack = false;
                _time = _animReset;
            _play.PlayOneShot(_swordsSFX[(int)Random.Range(0f, 3f)]);
                Collider2D[] damagedEnemies = Physics2D.OverlapCircleAll(_attackPos.position, _attackRange, _isEnemy);
                for (int i = 0; i < damagedEnemies.Length; i++)
                {
                    damagedEnemies[i].GetComponent<GeneralEnemy>().TakeDamage(damagedEnemies[i].GetComponent<GeneralEnemy>().CalculateDamage);
                }
            }      
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPos.position, _attackRange);
    }

    private void ResetAnim()
    {
        _time = _time - Time.deltaTime;
        if (_time < 1.1)  _canAttack = true; 
    }
}
