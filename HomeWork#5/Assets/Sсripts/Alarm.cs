using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float _incrementStep = 0.2f;
    private bool _isInside = false;
    private float _maxVolume = 1.0f;
    private float _minVolume = 0.0f;

    private void Start()
    {
        _audioSource.volume = _incrementStep;
    }

    public void Play()
    {
        _audioSource.Play();
        _isInside = true;
        StartCoroutine(ChangeVolume(_maxVolume));
    }

    public void Stop()
    {
        _isInside = false;
        StartCoroutine(ChangeVolume(_minVolume));
    }

    private IEnumerator ChangeVolume(float value)
    {
        while (_audioSource.volume != value)
        {
            if (_isInside == true)
            {
                _audioSource.volume += _incrementStep;
            }
            else
            {
                _audioSource.volume -= _incrementStep;

                if (_audioSource.volume == _minVolume)
                {
                    _audioSource.Stop();
                }
            }

            yield return new WaitForSeconds (1.0f);
        }        
    }
}
 