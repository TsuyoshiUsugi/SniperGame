using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�̍s�����Ǘ�����R���|�[�l���g
/// </summary>
public class EnemyManager : MonoBehaviour
{
    [Header("�Q��")]
    GameSceneManager _gameSceneManager;
    [SerializeField] NormalEnemyMove _enemyMove;

    [Header("�ݒ�l")]
    [SerializeField] float _hp = 100;
    [SerializeField] Status _currentStatus = Status.Normal;

    /// <summary>
    /// ���
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
