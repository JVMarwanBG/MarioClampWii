using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    private float speed = 30;

    [SerializeField]
    public Rigidbody _rb;

    void Update()
    {
        _rb.velocity = transform.forward * speed;
    }
}
