using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyRifle : TempSniperRifle
{
    [SerializeField] Vector3 _dir = new();
    [SerializeField] GameObject _player;
    [SerializeField] int _randomRange = 1;

    private void Start()
    {
        _player = FindObjectOfType<PlayerCamControlManager>().gameObject;
    }

    public override void Use()
    {
        var randomVector = new Vector3(Random.Range(0, _randomRange), Random.Range(0, _randomRange), Random.Range(0, _randomRange));
        _dir = _player.transform.position + new Vector3(0, 1, 0) - _muzzle.transform.position + randomVector;

        Shot();
    }

    private void Shot()
    {
        var bulletRb = Instantiate(_bullet, _muzzle.transform.position, _muzzle.transform.rotation)?.GetComponent<Rigidbody>();
        bulletRb.AddForce(_dir * _speed, ForceMode.Impulse);
        
    }
}
