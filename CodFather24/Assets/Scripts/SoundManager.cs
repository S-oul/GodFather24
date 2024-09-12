using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip aimantAttire;
    public AudioClip aimantEttire;
    public AudioClip bombeExplosion;
    public AudioClip collecteItem;
    public AudioClip reste30sound;
    //public AudioClip ambiance;

    private AudioSource _audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void jouerAudio(AudioClip clip)
    {
        //AudioSource.volume = 99;
        _audioSource.clip = clip;
        _audioSource.PlayOneShot(clip);

    }

    public void StopSound()
    {
        if(_audioSource.clip.name != "Alarm sound")
        {
            _audioSource.Stop();
        }
    }
}
