using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RadioToggler : Interactable
{
    [SerializeField] private AudioSource source;

    [SerializeField] private List<AudioClip> clips;

    private int _currentClipIndex = -1;

    protected override void Awake()
    {
        base.Awake();
        
        if (!source.playOnAwake)
        {
            _currentClipIndex = -1;
            return;
        }
        
        _currentClipIndex = 0;
        source.clip = clips.FirstOrDefault();
        source.Play();
    }

    public override bool? Interact(Interactor interactor)
    {
        _currentClipIndex++;
        
        if (_currentClipIndex >= clips.Count)
            _currentClipIndex = -1;

        if (_currentClipIndex == -1)
        {
            source.Pause();
            return true;
        }
        
        source.clip = clips[_currentClipIndex];
        source.Play();
        return true;
    }
}
