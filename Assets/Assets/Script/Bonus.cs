using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bonus : MonoBehaviour
{
    [SerializeField]
    public KartControl kartControl;

    [SerializeField]
    public Cube Cube;

    [SerializeField]
    public float speedBoosted;
    [SerializeField]
    public bool isBoosting;
    [SerializeField]
    public float _speedSave;

    [SerializeField]
    public Text _text;

    [SerializeField]
    private int _coinAmount;

    [SerializeField]
    private GameObject _shellPrefab;
    [SerializeField]
    private GameObject _bananaPrefab;
    [SerializeField]
    private Transform _shellSpawn;
    [SerializeField]
    private Transform _bananaSpawn;

    [SerializeField]
    public string playerFire;
    void Update()
    {
        if (Input.GetButtonDown(playerFire) && Cube.haveMushroom == true && !isBoosting)
        {
            StartCoroutine(Boosting());
            Cube.haveMushroom = false;
        }

        if (Input.GetButtonDown(playerFire) && Cube.haveCoin == true)
        {
            _coinAmount += 1;
            Cube.haveCoin = false;
            speedBoosted += _coinAmount * 2;
            kartControl.speedMax += _coinAmount;
        }

        _text.text = _coinAmount.ToString();

        if (Input.GetButtonDown(playerFire) && Cube.haveShell == true)
        {
            ShellSpawn();
            Cube.haveShell = false;
        }

        if (Input.GetButtonDown(playerFire) && Cube.haveBanana == true)
        {
            BananaSpawn();
            Cube.haveBanana = false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "boost")
        {
            StartCoroutine(Boosting());
        }
    }

    public IEnumerator Boosting()
    {
        isBoosting = true;
        _speedSave = kartControl.speedMax;
        kartControl.speedMax = speedBoosted;
        while (kartControl.speedMax != _speedSave)
        {
            kartControl.speedMax -= 1;
            yield return new WaitForSeconds(0.06f);
        }
        isBoosting = false;
    }

    private void ShellSpawn()
    {
        Instantiate(_shellPrefab, _shellSpawn.position, _shellSpawn.rotation);
    }

    private void BananaSpawn()
    {
        Instantiate(_bananaPrefab, _bananaSpawn.position, _bananaSpawn.rotation);
    }
}
