using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の行動を管理するコンポーネント
/// </summary>
public class EnemyManager : MonoBehaviour
{
    [Header("参照")]
    GameSceneManager _gameSceneManager;
    [SerializeField] NormalEnemyMove _enemyMove;

    [Header("設定値")]
    [SerializeField] float _hp = 100;
    [SerializeField] Status _currentStatus = Status.Normal;

    /// <summary>
    /// 状態
    /// </summary>
    public enum Status
    {
        Normal,
        HighAlert,
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentStatus = Status.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        if(_currentStatus == Status.HighAlert)
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
