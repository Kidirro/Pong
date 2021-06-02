using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    static public AudioScript Instance => _instance;
    private static AudioScript _instance;

    [SerializeField] private List<AudioClip> _audioClips = new List<AudioClip>();
    private List<AudioSource> _audioSource= new List<AudioSource>();

    private void Awake()
    {
        _instance = this;
        for (int i = 0; i < _audioClips.Count; i++)
        {
            _audioSource.Add(gameObject.AddComponent<AudioSource>());
            _audioSource[i].clip = _audioClips[i];
        }
    }

    public void PlayAudio(AudioType audio)
    {
        _audioSource[(int)audio].Play();
    }

}

public enum AudioType
{
    BallFall=0,
    BallStart,
    FliperActive,
    PowerHit
}