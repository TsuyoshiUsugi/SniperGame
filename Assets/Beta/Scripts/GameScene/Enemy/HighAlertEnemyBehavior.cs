using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class HighAlertEnemyBehavior : EnemyBehavior
{
    [SerializeField] bool _coward;
    [SerializeField] float _shootSpan = 5;
    [SerializeField] GameObject _holdItem;
    [SerializeField] float _diff = -50;

    // Start is called before the first frame update
    private void Start()
    {
        if (_coward) return;

        _animator = GetComponentInChildren<Animator>();
        _animator.SetBool("Crouch", true);
        RotateTowardToPlayer();
        Shoot();
    }

    private void Update()
    {
        if(_coward) 
        {
            MoveThisObj();

            RotateObj();

            SlideIndex();
        }
    }

    void RotateTowardToPlayer()
    {
        var diff = FindObjectOfType<PlayerCamControlManager>().gameObject.transform.position - transform.position;
        _body.transform.rotation = Quaternion.LookRotation(diff) * Quaternion.AngleAxis(_diff, Vector3.up);
    }

    void Shoot()
    {
        Observable.Interval(TimeSpan.FromSeconds(_shootSpan))
            .Subscribe(_ => _holdItem?.GetComponent<IUse>().Use())
            .AddTo(this);
    }
}
