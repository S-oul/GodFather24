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
    public AudioClip reste60sound;
    public AudioClip reste10sound;
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
        _audioSource.volume = 99;
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}
