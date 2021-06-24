﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu
{
    public static GameObject Menu;
}

public class Death : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Movement movement = collision.GetComponent<Movement>();
        if (movement)
        {
            movement.enabled = false;
            DeadMenu.Menu.SetActive(true);
            movement.GetComponent<Animator>().Play("Death");
            StartCoroutine(Restarting());
        }
    }

    public IEnumerator Restarting()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                DeadMenu.Menu.SetActive(false);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            yield return null;
        }
    }
}