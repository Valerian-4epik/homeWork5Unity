using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _volume = 0.1f;
    private float _incrementStep = 0.2f;
    private bool _isInside = false;
    private float _maxVolume = 1.0f;
    private float _minVolume = 0.0f;

    private void Start()
    {
        _audioSource.volume = _volume;
    }

    private void Update()
    {
        if(_isInside == true)
        {
            VolumeUp();
        }
        else
        {
            VolumeDown();
        }
    }

    public void Play()
    {
        _audioSource.Play();
        _isInside = true;
    }

    public void Stop()
    {
        _isInside = false;
    }

    private void VolumeUp()
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, Time.deltaTime * _incrementStep);
    }

    private void VolumeDown()
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _minVolume, Time.deltaTime * _incrementStep);
    }
}
