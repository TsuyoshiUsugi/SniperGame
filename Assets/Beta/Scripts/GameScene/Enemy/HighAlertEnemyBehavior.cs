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
    [SerializeField] Vector3 _horiOffset;
    

    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        if (_coward) return;

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

            RunAnim();

            SlideIndex();

            if(_movePointIndex >= _movePoints.Count - 1)
            {
                FindObjectOfType<GameSceneManager>().Failed();
            }
        }
    }

    void RunAnim()
    {
        
            _animator.SetBool("Running", true);
        
    
    }

    void RotateTowardToPlayer()
    {
        var targetDir = FindObjectOfType<PlayerCamControlManager>().gameObject.transform.position - transform.position;
        targetDir.y = 0;

        targetDir += _horiOffset;

        _body.transform.rotation = Quaternion.LookRotation(targetDir);
    }

    void Shoot()
    {
        var stop = Observable.EveryUpdate().Where(_ => this.enabled == false);

        Observable.Interval(TimeSpan.FromSeconds(_shootSpan))
            .TakeUntil(stop)
            .Subscribe(_ => _holdItem?.GetComponent<IUse>().Use())
            .AddTo(this);
    }

    private void OnDisable()
    {
        
    }
}
