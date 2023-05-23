using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class GravityEntity : MonoBehaviour
{
    public const float GravityScale = 9.81f;

    [SerializeField] private Rigidbody _rb;
    
    private Vector3 _gravityDir = Vector3.down;

    private void Awake()
    {
        if (!_rb) _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.AddForce(_rb.mass * GravityScale * _gravityDir);
    }

    [Button]
    public void ChangeGravity(Vector3 dir)
    {
        _gravityDir = dir;
    }
}
