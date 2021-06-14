using System;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public float Distance;
    public Vector2 Force;
    private Rigidbody2D _rigidbody;
    private PhysicsObject _object;
    private Transform _self;
    private Camera _camera;
    private ContactFilter2D _filter;
    private RaycastHit2D[] _hitsBuffer = new RaycastHit2D[1];
    private List<RaycastHit2D> _hitsList = new List<RaycastHit2D>(1);

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _object = GetComponent<Movement>();
        _self = GetComponent<Transform>();
        _camera = Camera.main;

        _filter.SetLayerMask(Physics2D.GetLayerCollisionMask(5));
        _filter.useLayerMask = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 distanceToMouse = mousePosition - _self.position;

            int count = _rigidbody.Cast(distanceToMouse.normalized, _hitsBuffer, Distance);
            _hitsList.Clear();
            for (int i = 0; i < count; i++)
            {
                _hitsList.Add(_hitsBuffer[i]);
            }

            foreach(RaycastHit2D hit in _hitsList)
            {
                if (hit.distance <= Distance
                    && hit.collider.CompareTag("Light"))
                {
                    Vector2 distnaceToHit = hit.centroid - (Vector2)_self.position;
                    _object.AddForce(Force * distnaceToHit.normalized);
                }
            }
        }
    }
}
