using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private UnityEvent _thiefEnteredTheHouse;
    [SerializeField] private UnityEvent _thiefLeftTheHouse ;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            _thiefEnteredTheHouse.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _thiefLeftTheHouse .Invoke();
    }
}
