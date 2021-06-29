using System.Collections;
using UnityEngine;

public class UnityMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public bool grounded { get; private set; }
    private Rigidbody2D _rigidbody;
    private float _xSpeed;
    private Collider2D _ground;

    void Start()
    {
        grounded = false;
        _rigidbody = GetComponent<Rigidbody2D>();
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            grounded = true;
            _ground = collision;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.isTrigger
            && collision == _ground)
        {
            grounded = false;
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