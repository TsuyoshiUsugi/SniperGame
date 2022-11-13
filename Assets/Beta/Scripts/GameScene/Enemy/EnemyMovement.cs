using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の行動を管理するコンポーネント
/// 
/// MEMO
/// とにかく動きの管理処理のみ書く
/// </summary>
public class EnemyMovement : MonoBehaviour, IDeath
{
    [SerializeField] GameSceneManager _gameSceneManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Death()
    {
        _gameSceneManager.Clear();
    }
}
