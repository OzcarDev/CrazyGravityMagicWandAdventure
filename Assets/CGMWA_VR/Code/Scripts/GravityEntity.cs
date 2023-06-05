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

    public event Action<Vector3> OnGravityChange; 

    public Rigidbody Rb => _rb;
    [SerializeField] private Rigidbody _rb;
    
    private Vector3 _gravityDir = Vector3.down;

    private void Awake()
    {
        if (!_rb) _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
    }

    private void FixedUpdate()
    {
        //Virtual Gravity
        _rb.AddForce(_rb.mass * GravityScale * _gravityDir);
    }

    [Button]
    public void ChangeGravity(Vector3 dir)
    {
        _gravityDir = dir;
        OnGravityChange?.Invoke(dir);
    }
}
