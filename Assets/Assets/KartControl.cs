using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartControl : MonoBehaviour
{
    public Rigidbody rbd;

    public float speed;
    public float rotationspeed;

    void Start()
    {
        
    }



    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles += Vector3.down * rotationspeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles += Vector3.up * rotationspeed * Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rbd.velocity = transform.forward * speed * Time.deltaTime;
        }
    }

}
