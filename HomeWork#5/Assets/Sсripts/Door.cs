using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private UnityEvent _entry;
    [SerializeField] private UnityEvent _left;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _entry.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _left.Invoke();
    }
}
