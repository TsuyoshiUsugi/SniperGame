using UnityEngine;
using UnityEditor;

/// <summary>
/// �ړ��n�_��ҏW���₷������Editor�g��
/// 
/// �@�\
/// Scene�ォ��ړ��n�_�𑀍�\�ɂ���
/// </summary>
[CustomEditor(typeof(EnemyBehavior), true)]
public class MovePointEditor : Editor
{
    SerializedProperty _movePosList;

    private void OnEnable()
    {
        _movePosList = serializedObject.FindProperty("_movePoints");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }

    private void OnSceneGUI()
    {
        var enemyMove = target as EnemyBehavior;

        serializedObject.Update();

        if (_movePosList.arraySize == 0) return;

        enemyMove.MovePoints[0] = enemyMove.gameObject.transform.position;

        for (int i = 0; i < enemyMove.MovePoints.Count; i++)
        {
            Vector3 movePos = enemyMove.MovePoints[i];
            EditorGUI.BeginChangeCheck();
            var newMovePos = Handles.PositionHandle(movePos, enemyMove.transform.rotation);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Change");
                enemyMove.MovePoints[i] = newMovePos;
            }
        }

        serializedObject.ApplyModifiedProperties();
    }

}
