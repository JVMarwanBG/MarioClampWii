using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Material cube;

    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            cube.SetColor("_EmissionColor", Color.white);
        }
    }
}
