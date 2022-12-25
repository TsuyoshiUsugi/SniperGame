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
    [SerializeField] EnemyMove _enemyMove;

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
        if(_currentStatus == EnemyState.HighAlert)
        {
            _enemyMove.enabled = false;
        }
    }

    public void Hit(float dmg)
    {
        _hp -= dmg;

        if (_hp <= 0) Death();
    }

    void Death()
    {
        �@
         _gameSceneManager.Clear();     
    }
}
