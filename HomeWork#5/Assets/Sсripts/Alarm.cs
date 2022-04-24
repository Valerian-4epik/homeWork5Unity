using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Door door;
    private float _volume = 0.1f;
    private float _incrementStep = 0.2f;
    private bool _isInside;

    void Start()
    {
        _audioSource.volume = _volume;
    }

    private void VolumeUp()
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 1, Time.deltaTime * _incrementStep);
    }

    private void VolumeDown()
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 0, Time.deltaTime * _incrementStep);
    }

    void Update()
    {
        _isInside = door.IsInside;

        if (_isInside == true)
        {        
            VolumeUp();
            _audioSource.Play();
        }
        else if (_isInside == false)
        {
            VolumeDown();
        }
    }
}
