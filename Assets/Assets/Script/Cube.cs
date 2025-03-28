using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cube : MonoBehaviour
{
    [SerializeField]
    private int _objectDrop = 0;

    [SerializeField]
    public bool haveMushroom;

    [SerializeField]
    public bool haveBanana;

    [SerializeField]
    public bool haveShell;

    [SerializeField]
    public bool haveCoin;

    [SerializeField]
    private bool _noItems;

    [SerializeField]
    private List<Sprite> _sprites;

    [SerializeField]
    private GameObject _image;

    private void Update()
    {
        if ((haveMushroom == false) && (haveBanana == false) && (haveShell == false) && (haveCoin == false))
        {
            _noItems = true;
            _image.GetComponent<Image>().sprite = _sprites[0];
        }

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "cube")
        {
            if (_noItems == true)
            {
                _objectDrop = Random.Range(3, 3);
                if (_objectDrop == 1)
                {
                    haveMushroom = true;
                    _image.GetComponent<Image>().sprite = _sprites[1];
                }
                if (_objectDrop == 2)
                {
                    haveBanana = true;
                    _image.GetComponent<Image>().sprite = _sprites[2];
                }
                if (_objectDrop == 3)
                {
                    haveShell = true;
                    _image.GetComponent<Image>().sprite = _sprites[3];
                }
                if (_objectDrop == 4)
                {
                    haveCoin = true;
                    _image.GetComponent<Image>().sprite = _sprites[4];
                }
                _noItems = false;
            }
            Destroy(collision.gameObject);
        }
    }
}
