using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyInfo;

/// <summary>
/// 敵の行動を管理するコンポーネント
/// </summary>
public class EnemyManager : MonoBehaviour
{
    [Header("参照")]
    GameSceneManager _gameSceneManager;
    [SerializeField] EnemyMove _enemyMove;

    [Header("設定値")]
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
        　
         _gameSceneManager.Clear();     
    }
}
