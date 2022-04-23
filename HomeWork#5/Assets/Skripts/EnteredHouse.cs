using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteredHouse : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _siren;
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _siren.GetComponent<AudioSource>().Play();
            _siren.GetComponent<Signal>().isInside = true;
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        _siren.GetComponent<Signal>().isInside = false;
    }

    private void Update()
    {

    }



}
