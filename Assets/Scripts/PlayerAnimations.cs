using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;
    private PhysicsObject _object;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _object = GetComponent<Movement>();
    }

    void Update()
    {
        if(_object.Velocity.y > 0)
        {
            _animator.SetBool("IsJump", true);
        }
        if(_object.Velocity.y < 0
            && !_object.grounded)
        {
            _animator.SetBool("Landing", true);
        }
        if (_object.grounded)
        {
            _animator.SetBool("IsJump", false);
            _animator.SetBool("Landing", false);
        }
        if(_object.Velocity.x > 0)
        {
            _animator.SetBool("IsRun", true);
            _animator.SetBool("IsLeft", false);
        }
        if(_object.Velocity.x < 0)
        {
            _animator.SetBool("IsRun", true);
            _animator.SetBool("IsLeft", true);
        }
        if(_object.Velocity.x == 0)
        {
            _animator.SetBool("IsRun", false);
        }
    }
}
