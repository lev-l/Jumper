using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Messanger : MonoBehaviour
{
    private Throw _throw;

    private void Start()
    {
        _throw = GetComponentInParent<Throw>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _throw.PlayerCame(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _throw.PlayerCame(false);
    }
}
