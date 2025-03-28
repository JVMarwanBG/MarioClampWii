using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField]
    public KartControl kartControl;

    [SerializeField]
    public float speedSlowed;
    [SerializeField]
    private float _speedSave;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "banana")
        {
            StartCoroutine(Slow());
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "shell")
        {
            StartCoroutine(Slow());
            Destroy(collision.gameObject);
        }
    }

    public IEnumerator Slow()
    {
        _speedSave = kartControl.speedMax;
        kartControl.speedMax = speedSlowed;
        while (kartControl.speedMax != _speedSave)
        {
            kartControl.speedMax += 1;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
