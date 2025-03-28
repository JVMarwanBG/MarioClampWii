using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField]
    private float _raycastDistance;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (Physics.Raycast(transform.position, transform.forward, _raycastDistance))
            {
                Debug.Log("Hit");
            }
        }
    }
}
