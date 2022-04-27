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

    private void Update()
    {
        StartCoroutine(VolumeValue());
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

    private IEnumerator VolumeValue()
    {

        if (_isInside == true)
        {
            ChangeVolume(_maxVolume);
        }
        else
        {
            ChangeVolume(_minVolume);

            if(_audioSource.volume == _minVolume)
            {
                _audioSource.Stop();
            }
        }

        yield return null;
    }

    private void ChangeVolume(float value)
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, value, Time.deltaTime * _incrementStep);
    }
}
 