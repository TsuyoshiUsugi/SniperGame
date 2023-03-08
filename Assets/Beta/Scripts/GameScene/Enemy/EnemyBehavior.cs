using System.Collections.Generic;
using UnityEngine;
using MyExtension;
using EnemyInfo;

/// <summary>
/// 通常時の動きを設定するコンポ―ネント
/// 指定された地点に移動する
/// </summary>
public class EnemyBehavior : MonoBehaviour
{
    [Header("参照")]
    [SerializeField] protected GameObject _body;
    protected Animator _animator;

    [Header("設定値")]
    [SerializeField, Header("移動地点間の到達時間")] float _speed;

    [SerializeField, Header("状態")] EnemyState _enemyState;
    public EnemyState ThisEnemyState => _enemyState; 

    [Header("移動経路")]
    [SerializeField] protected List<Vector3> _movePoints = new();
    public List<Vector3> MovePoints => _movePoints;

    int _movePointIndex;
    Vector3 _latestPos;

    Vector3 _velocity = Vector3.zero;

    const float _gizumoSize = 0.3f;


    // Start is called before the first frame update
    void Start()
    {
        _movePointIndex = 0;
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        MoveThisObj();

        RotateObj();
        
        SlideIndex();
    }

    /// <summary>
    /// 指定した移動地点に移動する
    /// </summary>
    protected void MoveThisObj()
    {
        if (_movePointIndex >= _movePoints.Count - 1) return;
        transform.position =
                Vector3.SmoothDamp(transform.position, _movePoints[_movePointIndex + 1], ref _velocity, _speed);
    }

    /// <summary>
    /// 向かっている地点の方向にキャラを向かせる
    /// </summary>
    protected void RotateObj()
    {
        var diff = transform.position - _latestPos;
        _latestPos = transform.position;

        if(diff.magnitude > 0.01f)
        {
            _body.transform.rotation = Quaternion.LookRotation(diff);

            _animator.SetBool("Walking", true);
        }
        else
        {
            _animator.SetBool("Walking", false);
        }
    }   

    /// <summary>
    /// 指定した地点に到達したらインデックスを進める
    /// </summary>
    protected void SlideIndex()
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
        if(_enemyState == EnemyState.Normal)
        {
            Gizmos.color = Color.blue;   //青
        }
        else if (_enemyState == EnemyState.HighAlert)
        {
            Gizmos.color = Color.red;   //赤
        }

        for (int i = 0; i < _movePoints.Count; i++)
        {
            Gizmos.DrawSphere(_movePoints[i], _gizumoSize);

            if (i != 0)
            {
                Gizmos.DrawLine(_movePoints[i], _movePoints[i - 1]);
            }

        }
    }
#endif
}
