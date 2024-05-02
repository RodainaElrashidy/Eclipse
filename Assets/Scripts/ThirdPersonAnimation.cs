using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonAnimation : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody rb;
    private float maxSpeed = 5f;

    private void Start()
    {
        _animator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _animator.SetFloat("Speed", rb.velocity.magnitude / maxSpeed);

    }
}
