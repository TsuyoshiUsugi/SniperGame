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

    /// <summary>
    /// �N���A���o�ƏI��莟�挋�ʃV�[���̃��[�h
    /// </summary>
    public void Clear()
    {
        Debug.Log("�N���A");
        SceneManager.LoadScene(_resultSceneName);
    }

    /// <summary>
    /// ���s�̉��o�ƏI��莟�挋�ʃV�[���̃��[�h
    /// </summary>
    public void Failed()
    {
        SceneManager.LoadScene(_resultSceneName);
    }

    /// <summary>
    /// �|�[�Y����
    /// </summary>
    void Pose()
    {

    }
}
