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
        StopCoroutine(ChangeVolume(_maxVolume));
        _isInside = false;
        StartCoroutine(ChangeVolume(_minVolume));     
    }

    private IEnumerator ChangeVolume(float value)
    {
        while (_audioSource.volume != value)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, value, _incrementStep);

            yield return new WaitForSeconds(1.0f);
        }

        if (_audioSource.volume == _minVolume)
        {
            _audioSource.Stop();
        }
    }
}
