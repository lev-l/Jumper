using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu
{
    public static GameObject Menu;
}

public class Death : MonoBehaviour
{
    private Collider2D _collider;
    private ContactFilter2D _filter;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();

        _filter.useTriggers = false;
        _filter.layerMask = Physics2D.GetLayerCollisionMask(gameObject.layer);
        _filter.useLayerMask = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        UnityMovement movement = collision.GetComponent<UnityMovement>();
        if (movement)
        {
            StartCoroutine(Dead(movement));
        }
    }

    private IEnumerator Dead(UnityMovement movement)
    {
        Collider2D[] colliders = new Collider2D[4];
        yield return new WaitForSecondsRealtime(0.1f);

        if (_collider.OverlapCollider(_filter, colliders) > 0)
        {
            movement.enabled = false;
            movement.GetComponent<Rope>().enabled = false;
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
