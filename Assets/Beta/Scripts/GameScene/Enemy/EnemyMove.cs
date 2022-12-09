using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 動きを設定するコンポ―ネント
/// 指定された地点に移動する
/// </summary>
public class EnemyMove : MonoBehaviour
{
    [SerializeField] List<Vector3> _movePoints;

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
    /// 選択されているとき移動する道を表示する
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0, 0, 0.3f);

        foreach (var movePoint in _movePoints)
        {
            Gizmos.DrawSphere(movePoint, 1f);
        }

    }
#endif
}
