using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// ������ݒ肷��R���|�\�l���g
/// �w�肳�ꂽ�n�_�Ɉړ�����
/// </summary>
public class EnemyMove : MonoBehaviour
{
    [SerializeField] List<Vector3> _movePoints;
    public List<Vector3> MovePoints => _movePoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #if UNITY_EDITOR
    /// <summary>
    /// �I������Ă���Ƃ��ړ����铹��\������
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0, 0, 0.3f);
        var rectSize = new Vector2(2, 2);

        for (int i = 0; i < _movePoints.Count; i++)
        {

        }

    }
    #endif
}
