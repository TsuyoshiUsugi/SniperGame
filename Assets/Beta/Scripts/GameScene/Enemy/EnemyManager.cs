using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の行動を管理するコンポーネント
/// </summary>
public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameSceneManager _gameSceneManager;

    [SerializeField] float _hp = 100;

    Status _currentStatus = Status.Normal;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
