using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Cinemachine;
using DG.Tweening;

public class TempSniperRifle : MonoBehaviour, IUse
{
    [Header("éQè∆")]
    [SerializeField] protected GameObject _muzzle;
    [SerializeField] protected GameObject _bullet;
    [SerializeField] CinemachineVirtualCamera _cam;

    [Header("ê›íËíl")]
    [SerializeField] protected float _speed = 500;
    [SerializeField] float _recoilNum = -30;
    [SerializeField] float _recoilTime = 0.1f;
    [SerializeField] Ease _recoilEase;

    void Awake()
    {
        Assert.IsNotNull(_muzzle);
        Assert.IsNotNull(_bullet);
    }

    public virtual void Use()
    {
        Shot();
    }

    private void Shot()
    {
        var bulletRb = Instantiate(_bullet, _muzzle.transform.position, _muzzle.transform.rotation)?.GetComponent<Rigidbody>();

        if (_cam == null) return;
        bulletRb.AddForce(_cam.transform.forward * _speed, ForceMode.Impulse);
        DoRecoil();
    }

    protected void DoRecoil()
    {
        transform.DOLocalRotate(new Vector3(_recoilNum, 0, 0), _recoilTime).SetLoops(2,LoopType.Yoyo).SetEase(_recoilEase).SetAutoKill(this);
    }
}
