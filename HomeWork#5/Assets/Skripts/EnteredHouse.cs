using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteredHouse : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private AudioSource _audioSource;
    private float volume = 0.1f;
    private float incrementStep = 0.2f;
    private bool isInside = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _audioSource.volume = volume;
            _audioSource.Play();
            isInside = true;
        }
    }

    private void VolumeUp()
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 1, Time.deltaTime* incrementStep);
    }

    private void VolumeDown()
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 0, Time.deltaTime * incrementStep);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInside = false;
    }

    private void Update()
    {
        if(isInside == true)
        {
        VolumeUp();
        }
        else if(isInside == false)
        {
        VolumeDown();
        }
    }



}
