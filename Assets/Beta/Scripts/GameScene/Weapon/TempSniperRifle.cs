using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Cinemachine;
using DG.Tweening;

public class TempSniperRifle : MonoBehaviour, IUse
{
    [Header("参照")]
    [SerializeField] GameObject _muzzle;
    [SerializeField] GameObject _bullet;
    [SerializeField] CinemachineVirtualCamera _cam;

    [Header("設定値")]
    [SerializeField] float _speed;
    [SerializeField] float _recoilNum = -30;
    [SerializeField] float _recoilTime = 0.1f;
    [SerializeField] Ease _recoilEase;

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
        DoRecoil();
    }

    void DoRecoil()
    {
        Debug.Log("リコイル");
        transform.DOLocalRotate(new Vector3(_recoilNum, 0, 0), _recoilTime).SetLoops(2,LoopType.Yoyo).SetEase(_recoilEase).SetAutoKill(this);
    }
}
