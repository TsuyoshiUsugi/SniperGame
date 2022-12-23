using System.Collections.Generic;
using System;
using UnityEngine;
using MyExtension;

/// <summary>
/// �ʏ펞�̓�����ݒ肷��R���|�\�l���g
/// �w�肳�ꂽ�n�_�Ɉړ�����
/// </summary>
public class NormalEnemyMove : MonoBehaviour
{
    [SerializeField, Header("�ړ��n�_�Ԃ̓��B����")] float _speed;

    [Header("�ړ��o�H")]
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
