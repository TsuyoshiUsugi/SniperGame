using System.Collections.Generic;
using System;
using UnityEngine;
using MyExtension;

/// <summary>
/// 通常時の動きを設定するコンポ―ネント
/// 指定された地点に移動する
/// </summary>
public class NormalEnemyMove : MonoBehaviour
{
    [SerializeField, Header("移動地点間の到達時間")] float _speed;

    [Header("移動経路")]
    [SerializeField] List<Vector3> _movePoints;
    public List<Vector3> MovePoints => _movePoints;

    [SerializeField] int _movePointIndex;
    Vector3 _velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _movePointIndex = 0;

        Debug.Log(_movePoints.Count);
    }

    // Update is called once per frame
    void Update()
    {
        MoveThisObj();
        
        SlideIndex();
    }

    /// <summary>
    /// 指定した移動地点に移動する
    /// </summary>
    private void MoveThisObj()
    {
        if (_movePointIndex >= _movePoints.Count - 1) return;
        transform.position =
                Vector3.SmoothDamp(transform.position, _movePoints[_movePointIndex + 1], ref _velocity, _speed);
    }

    /// <summary>
    /// 指定した地点に到達したらインデックスを進める
    /// </summary>
    private void SlideIndex()
    {
        if (_movePointIndex >= _movePoints.Count - 1) return;
        var roundCurrentPos = transform.position.Round(1);
        var roundMovePoint = _movePoints[_movePointIndex + 1].Round(1);
        if (roundCurrentPos == roundMovePoint) _movePointIndex++;
        
    }

    #if UNITY_EDITOR
    /// <summary>
    /// 選択されているとき移動する道を表示する
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0, 0, 0.3f);

        for (int i = 0; i < _movePoints.Count; i++)
        {
            Gizmos.DrawSphere(_movePoints[i], 1f);

            if (i != 0)
            {
                Gizmos.DrawLine(_movePoints[i], _movePoints[i - 1]);
            }

        }
    }
    #endif
}
