using System;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public float Distance;
    public Vector2 Force;
    private Rigidbody2D _rigidbody;
    private Movement _object;
    private Transform _self;
    private Camera _camera;
    private ContactFilter2D _filter;
    private RaycastHit2D[] _hitsBuffer = new RaycastHit2D[5];
    private List<RaycastHit2D> _hitsList = new List<RaycastHit2D>(5);

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

            for(int i = _hitsList.Count - 1; i >= 0; i--)
            {
                RaycastHit2D hit = _hitsList[i];

                if (hit.distance <= Distance
                    && hit.collider.CompareTag("Light"))
                {
                    Vector2 distanceToHit = hit.centroid - (Vector2)_self.position;
                    hit.collider.GetComponent<Animator>().Play("RopeAttached");

                    _object.AddForce(Force * distanceToHit.normalized);
                    break;
                }
            }
        }
    }
}
