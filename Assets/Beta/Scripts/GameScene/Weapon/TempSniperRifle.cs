using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class TempSniperRifle : MonoBehaviour, IUse
{
    [Header("参照")]
    [SerializeField] GameObject _muzzle;
    [SerializeField] GameObject _bullet;

    [Header("設定値")]
    [SerializeField] float _speed;

    void Awake()
    {
        Assert.IsNotNull(_muzzle);
        Assert.IsNotNull(_bullet);
    }

    public void Use()
    {
        Shot();
    }

    private void Shot()
    {
        var bulletRb = Instantiate(_bullet, _muzzle.transform.position, _muzzle.transform.rotation)?.GetComponent<Rigidbody>();
        bulletRb.AddForce(this.gameObject.transform.forward * _speed, ForceMode.Impulse);   
    }
}
