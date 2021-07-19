using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    public Ables SelfAbles;
    public GameObject PhysicTeleporter;

    void Start()
    {
        GetComponent<Flying>().enabled = SelfAbles.Fly;
        if (SelfAbles.PhysicsTeleportation)
        {
            Instantiate(PhysicTeleporter, transform.position, Quaternion.identity);
        }
    }
}
