﻿using System.Collections;
using UnityEngine;

public class UnityMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public bool grounded { get; private set; }
    private Rigidbody2D _rigidbody;
    private float _xSpeed;
    private ContactFilter2D _filter;

    void Start()
    {
        grounded = false;
        _rigidbody = GetComponent<Rigidbody2D>();

        _filter.useTriggers = false;
        _filter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        _filter.useLayerMask = true;

        StartCoroutine(GetGround());
    }

    void Update()
    {
        Vector2 newVelocity = _rigidbody.velocity;

        newVelocity.x = Input.GetAxis("Horizontal") * Speed + _xSpeed;
        if (grounded
            && Input.GetKeyDown(KeyCode.Space))
        {
            newVelocity.y = Input.GetAxis("Jump") * JumpForce;
        }

        _rigidbody.velocity = newVelocity;
    }

    public IEnumerator GetGround()
    {
        RaycastHit2D[] buffer = new RaycastHit2D[10];
        while (true)
        {
            int grounds = _rigidbody.Cast(Vector2.down, _filter, buffer, 0.55f);

            grounded = grounds > 0;

            yield return new WaitForSeconds(0.1f);
        }
    }

    public void AddForce(Vector2 force)
    {
        _rigidbody.velocity = force;
        _xSpeed = force.x;
        Invoke(nameof(SetXSpeed0), 0.2f);
    }

    public void SetXSpeed0()
    {
        _xSpeed = 0;
    }
}
