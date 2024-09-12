using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip aimantAttire;
    public AudioClip aimantEttire;
    public AudioClip ambiance;
    public AudioClip bombeExplosion;
    public AudioClip collecteItem;
    public AudioClip reste60sound;
    public AudioClip reste10sound;

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
        
    }

    public void jouerAudio(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}
