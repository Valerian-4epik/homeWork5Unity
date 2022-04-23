using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private float volume = 0.1f;
    private float incrementStep = 0.2f;
    public bool isInside = false;

    void Start()
    {
        _audioSource.volume = volume;
    }

    private void VolumeUp()
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 1, Time.deltaTime * incrementStep);
    }

    private void VolumeDown()
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 0, Time.deltaTime * incrementStep);
    }

    void Update()
    {
        if (isInside == true)
        {
            VolumeUp();
        }
        else if (isInside == false)
        {
            VolumeDown();
        }
    }
}
