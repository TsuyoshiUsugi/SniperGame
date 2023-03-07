using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Cinemachine;

public class TempSniperRifle : MonoBehaviour, IUse
{
    [Header("éQè∆")]
    [SerializeField] GameObject _muzzle;
    [SerializeField] GameObject _bullet;
    [SerializeField] CinemachineVirtualCamera _cam;

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
        bulletRb.AddForce(_cam.transform.forward * _speed, ForceMode.Impulse);   
    }
}
