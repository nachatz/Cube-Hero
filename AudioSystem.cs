using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioSystem : MonoBehaviour
{
    [SerializeField] private AudioClip[] _Town = new AudioClip[1];
    [SerializeField] private AudioClip[] _Menu = new AudioClip[1];
    [SerializeField] private AudioClip[] _Cutscene = new AudioClip[1];
    [SerializeField] private AudioClip[] _Kyfe = new AudioClip[1];
    public AudioSource _play;
    public string _where;

    private bool fix;
    private bool fix1;
    private bool fix2;
    private bool fix3;
	// Use this for initialization
	void Start ()
    {
        _play = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        _play.PlayOneShot(_Menu[0]);
        _where = "menu";
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        Scene _currentScene = SceneManager.GetActiveScene();

        if (_currentScene.name == "cutscene1" && !fix)
        {
            _play.Stop();
            _play.PlayOneShot(_Cutscene[0]);
            fix = true;
        }

        if (_currentScene.name == "lvl_town01" && !fix1)
        {
            _where = "town";
            _play.Stop();
            fix1 = true;
            fix2 = false;
        }
        if (_currentScene.name == "Kyfe_01" && !fix2)
        {
            _where = "kyfe";
            _play.Stop();
            fix1 = false;
            fix2 = true;
        }

        

        Where();
    }

    private void Where()
    {
        switch (_where)
        {
            case "town":
                if (!_play.isPlaying)
                    _play.PlayOneShot(_Town[(int)Random.Range(0f, 1f)]);
                break;
            case "kyfe":
                if (!_play.isPlaying)
                    _play.PlayOneShot(_Kyfe[(int)Random.Range(0f, 1f)]);
                break;
            case "menu":
                if (!_play.isPlaying)
                    _play.PlayOneShot(_Menu[(int)Random.Range(0f, 1f)]);
                break;



        }


    }
}
