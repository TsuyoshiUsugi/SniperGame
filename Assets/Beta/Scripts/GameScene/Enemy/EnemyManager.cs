using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyInfo;

/// <summary>
/// �G�̍s�����Ǘ�����R���|�[�l���g
/// </summary>
public class EnemyManager : MonoBehaviour
{
    [Header("�Q��")]
    GameSceneManager _gameSceneManager;
    [SerializeField] EnemyMove _normalEnemyMove;
    [SerializeField] EnemyMove _highAlertEnemyMove;

    [Header("�ݒ�l")]
    [SerializeField] float _hp = 100;
    [SerializeField] EnemyState _currentStatus = EnemyState.Normal;

    // Start is called before the first frame update
    void Start()
    {
        _currentStatus = EnemyState.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_currentStatus)
        {
            case EnemyState.Normal:
                _normalEnemyMove.enabled = true;
                _highAlertEnemyMove.enabled = false;

                break;

            case EnemyState.HighAlert:
                _normalEnemyMove.enabled = false;
                _highAlertEnemyMove.enabled = true;

                break;
        }
    }

    public void Hit(float dmg)
    {
        _hp -= dmg;
        if (_hp <= 0) Death();
    }

    void Death()
    {
        Animator anim = GetComponentInChildren<Animator>();
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        anim.enabled = false;

        foreach (var rb in rigidbodies)
        {
            rb.isKinematic = false;
            
        }
    }
}
