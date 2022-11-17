using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceManager : MonoBehaviour
{
    [SerializeField] public AudioSource source;

    public void PlayInLoop(AudioClip clip)
    {
        source.clip = clip;
        source.loop = true;
        source.Play();
    }
    
    public void PlayDelayedRandom(AudioClip clip)
    {
        source.clip = clip;
        source.loop = false;
        source.PlayDelayed(Random.Range(3f, 10f));
    }
}
