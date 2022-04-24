using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    private bool _isInside = false;
    public bool IsInside => _isInside;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _isInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isInside = false;
    }
}
