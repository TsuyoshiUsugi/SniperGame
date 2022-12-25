using System.Collections.Generic;
using UnityEngine;
using MyExtension;
using EnemyInfo;

/// <summary>
/// �ʏ펞�̓�����ݒ肷��R���|�\�l���g
/// �w�肳�ꂽ�n�_�Ɉړ�����
/// </summary>
public class EnemyMove : MonoBehaviour
{
    [Header("�ݒ�l")]
    [SerializeField, Header("�ړ��n�_�Ԃ̓��B����")] float _speed;

    [SerializeField, Header("���")] EnemyState _enemyState;
    public EnemyState ThisEnemyState => _enemyState; 

    [Header("�ړ��o�H")]
    [SerializeField] List<Vector3> _movePoints;
    public List<Vector3> MovePoints => _movePoints;

    int _movePointIndex;
    Vector3 _velocity = Vector3.zero;
    const float _gizumoSize = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        _movePointIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MoveThisObj();
        
        SlideIndex();
    }

    /// <summary>
    /// �w�肵���ړ��n�_�Ɉړ�����
    /// </summary>
    private void MoveThisObj()
    {
        if (_movePointIndex >= _movePoints.Count - 1) return;
        transform.position =
                Vector3.SmoothDamp(transform.position, _movePoints[_movePointIndex + 1], ref _velocity, _speed);
    }

    /// <summary>
    /// �w�肵���n�_�ɓ��B������C���f�b�N�X��i�߂�
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
    /// �I������Ă���Ƃ��ړ����铹��\������
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        if(_enemyState == EnemyState.Normal)
        {
            Gizmos.color = Color.blue;   //��
        }
        else if (_enemyState == EnemyState.HighAlert)
        {
            Gizmos.color = Color.red;   //��
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
