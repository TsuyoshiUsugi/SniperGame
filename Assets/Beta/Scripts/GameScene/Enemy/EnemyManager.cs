using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyInfo;
using UniRx;

/// <summary>
/// 敵の行動を管理するコンポーネント
/// </summary>
public class EnemyManager : MonoBehaviour
{
    [Header("参照")]
    [SerializeField] GameSceneManager _gameSceneManager;
    [SerializeField] EnemyMove _normalEnemyMove;
    [SerializeField] EnemyMove _highAlertEnemyMove;

    [Header("設定値")]
    [SerializeField] bool _isTarget = false;
    [SerializeField] float _hp = 100;
    [SerializeField] EnemyStateReactiveProperty _currentStatus = new();

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (_gameSceneManager == null) _gameSceneManager =  FindObjectOfType<GameSceneManager>();

        if (_isTarget)
        {
            _gameSceneManager.RegisterTarget(this);
        }

        _currentStatus.Value = EnemyState.Normal;

        _currentStatus.Subscribe(_ => ChangeAI()).AddTo(this);
    }

    void ChangeAI()
    {
        switch (_currentStatus.Value)
        {
            case EnemyState.Normal:
                _normalEnemyMove.enabled = true;
                _highAlertEnemyMove.enabled = false;
                break;

            case EnemyState.HighAlert:
                _normalEnemyMove.enabled = false;
                _highAlertEnemyMove.enabled = true;
                break;

            case EnemyState.Death:
                _normalEnemyMove.enabled = false;
                _highAlertEnemyMove.enabled = false;
                Death();
                break;
        }
    }

    public void Hit(float dmg)
    {
        _hp -= dmg;

        if(_hp <= 0)
        {
            ScoreManager.Instance.Kill();
            _currentStatus.Value = EnemyState.Death;
        }
    }

    void Death()
    {
        DeathAnim();

        //死亡時のragdoll処理
        void DeathAnim()
        {
            Animator anim = GetComponentInChildren<Animator>();
            Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
            anim.enabled = false;

            foreach (var rb in rigidbodies)
            {
                rb.isKinematic = false;
            }
        }

        if (_isTarget) _gameSceneManager.RegisterTargetDown(this);
    }
}
