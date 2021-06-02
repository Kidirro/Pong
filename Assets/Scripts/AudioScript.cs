using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    static public AudioScript Instance => _instance;
    private static AudioScript _instance;

    [SerializeField] private List<AudioClip> _audioClips = new List<AudioClip>();
    [SerializeField] private AudioSource _audioSource;

    private void Awake()
    {
        _instance = this;
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(AudioType audio)
    {
        _audioSource.clip = _audioClips[(int)audio];
        _audioSource.Play();
    }

}

public enum AudioType
{
    BallFall=0,
    FliperActive
}