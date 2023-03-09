using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using Cinemachine;
using DG.Tweening;
using UniRx;

public class TempSniperRifle : MonoBehaviour, IUse
{
    [Header("éQè∆")]
    [SerializeField] protected GameObject _muzzle;
    [SerializeField] protected GameObject _bullet;
    [SerializeField] CinemachineVirtualCamera _cam;
    [SerializeField] Text _currentMagNumText;

    [Header("ê›íËíl")]
    [SerializeField] protected float _speed = 500;
    [SerializeField] float _recoilNum = -30;
    [SerializeField] float _recoilTime = 0.1f;
    [SerializeField] Ease _recoilEase;
    [SerializeField] const int _maxMagNum = 6;
    ReactiveProperty<int> _currentMagNum = new(); 
    [SerializeField] float _reloadTime = 4;

    bool _coolTime;

    void Awake()
    {
        if(_currentMagNumText)
        {
            _currentMagNum.Value = _maxMagNum;
            _currentMagNum.Subscribe(num => _currentMagNumText.text = num.ToString());
        }
        Assert.IsNotNull(_muzzle);
        Assert.IsNotNull(_bullet);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(nameof(Reload));
        }
    }

    public virtual void Use()
    {
        Shot();
    }

    private void Shot()
    {
        if (_coolTime) return;
        if (_currentMagNum.Value == 0) return;
        _currentMagNum.Value--;

        var bulletRb = Instantiate(_bullet, _muzzle.transform.position, _muzzle.transform.rotation)?.GetComponent<Rigidbody>();
        if (_cam == null) return;
        bulletRb.AddForce(_cam.transform.forward * _speed, ForceMode.Impulse);

        DoRecoil();
    }

    protected void DoRecoil()
    {
        _coolTime = true;
        transform.DOLocalRotate(new Vector3(_recoilNum, 0, 0), _recoilTime)
            .SetLoops(2, LoopType.Yoyo)
            .SetEase(_recoilEase)
            .OnComplete(() => _coolTime = false)
            .SetAutoKill(this);
    }

    IEnumerator Reload()
    {
        if (_currentMagNum.Value == _maxMagNum) yield break;
        _currentMagNum.Value = 0;
        yield return new WaitForSeconds(_reloadTime);
        _currentMagNum.Value = _maxMagNum;
    }
}
