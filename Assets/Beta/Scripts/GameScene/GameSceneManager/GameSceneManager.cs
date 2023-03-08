using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �Q�[���̐i�s�Ǘ����s��
/// 
/// �����A���s�A�|�[�Y�̏������s��
/// </summary>
public class GameSceneManager : MonoBehaviour
{
    [SerializeField] string _resultSceneName;

    //Target�̐����m�F�ɂ���
    Dictionary<EnemyManager, EnemyInfo.EnemyState> _targetDic = new();

    /// <summary>
    /// �^�[�Q�b�g�̓o�^
    /// </summary>
    /// <param name="enemyManager"></param>
    public void RegisterTarget(EnemyManager enemyManager)
    {
        _targetDic.Add(enemyManager, EnemyInfo.EnemyState.Normal);
    }

    /// <summary>
    /// �^�[�Q�b�g���S���̏���
    /// </summary>
    public void RegisterTargetDown(EnemyManager enemyManager)
    {
        _targetDic[enemyManager] = EnemyInfo.EnemyState.Death;
        CheckTargetAlive();
    }

    void CheckTargetAlive()
    {
        foreach (var target in _targetDic)
        {
            if (target.Value != EnemyInfo.EnemyState.Death) return; 
        }

        Clear();
    }

    /// <summary>
    /// �N���A���o�ƏI��莟�挋�ʃV�[���̃��[�h
    /// </summary>
    void Clear()
    {
        Debug.Log("�N���A");
        //SceneManager.LoadScene(_resultSceneName);
    }

    /// <summary>
    /// ���s�̉��o�ƏI��莟�挋�ʃV�[���̃��[�h
    /// </summary>
    public void Failed()
    {
        Debug.Log("���s");
        //SceneManager.LoadScene(_resultSceneName);
    }

    /// <summary>
    /// �|�[�Y����
    /// </summary>
    void Pose()
    {

    }
}
