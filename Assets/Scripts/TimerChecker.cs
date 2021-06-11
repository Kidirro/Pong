using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using Unity;

public class TimerChecker : MonoBehaviour
{
    static public TimerChecker Instance => _instance;
    private static TimerChecker _instance;

    [SerializeField] private Text _score;
    [SerializeField] private Text _record;
    private AudioScript _audio;

    private float _time=0;
    private bool _isGamePlay = false;

    public void ChangePhase()
    {
        _isGamePlay = !_isGamePlay;
        if (!_isGamePlay)
        {
            _audio.PlayAudio(AudioType.BallFall); 
            if (_time > PlayerPrefs.GetFloat("Record"))
            {
                PlayerPrefs.SetFloat("Record", _time);
                _record.text = "Record:\n" + PlayerPrefs.GetFloat("Record");
            }
        }
        else
        {
            _audio.PlayAudio(AudioType.BallStart);
        }
        _time = 0;
    }

    public void CloseGame()
    {
        _isGamePlay = false;
        _audio.PlayAudio(AudioType.BallFall);
        if (_time > PlayerPrefs.GetFloat("Record"))
        {
            PlayerPrefs.SetFloat("Record", _time);
            _record.text = "Record:\n" + PlayerPrefs.GetFloat("Record");
        }
        _time = 0;
    }

    public void StartGame()
    {
        Application.targetFrameRate = 60;
        _isGamePlay = true;
        _audio.PlayAudio(AudioType.BallStart);
        _time = 0;
    }

    private void Awake()
    {
        _audio = AudioScript.Instance;
        _instance = this;
        StartCoroutine(TimerProcess());
        _record.text = "Record:\n" + PlayerPrefs.GetFloat("Record");
    }

    private IEnumerator TimerProcess()
    {
        while (true)
        {
            _time += 0.1f;
            _time = Mathf.Round(_time * 10) / 10;
            _score.text = (_isGamePlay) ? "Score:\n" + _time : "Score:\n-";
            yield return new WaitForSeconds(0.1f);
        }
    }
}

