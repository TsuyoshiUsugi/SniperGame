using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// �~�b�V�����I����ʂ̃~�b�V��������\�����邽�߂̃N���X
/// </summary>
public class MissionTabView : MonoBehaviour
{
    [Header("�Q��")]
    [SerializeField] Button _standByButton;
    [SerializeField] string _GameSceneName;

    private void Start()
    {
        _standByButton.onClick.AddListener(() => SceneManager.LoadScene(_GameSceneName));
    }
}
