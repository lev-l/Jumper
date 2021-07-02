﻿using System.Collections;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public Teleportation OtherTeleport;
    private bool _blocked;
    private GameObject _subject;

    private void Update()
    {
        if (Input.GetKey(KeyCode.E)
            && _subject
            && !_blocked)
        {
            _subject.transform.position = OtherTeleport.transform.position;
            OtherTeleport.Block();
            _subject = null;
        }
    }

    public void Block()
    {
        _blocked = true;
        StartCoroutine(Unblocke());
    }

    private IEnumerator Unblocke()
    {
        yield return new WaitForSeconds(0.5f);

        _blocked = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _subject = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _subject = null;
    }
}