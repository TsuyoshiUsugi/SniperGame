using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class TempSniperRifle : MonoBehaviour, IUse
{
    [Header("éQè∆")]
    [SerializeField] GameObject _muzzle;
    [SerializeField] GameObject _bullet;

    [Header("ê›íËíl")]
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
