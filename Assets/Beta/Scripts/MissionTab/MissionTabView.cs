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

    [Header("�ݒ�l")]
    [SerializeField] string _gameSceneName;
    public string GameSceneName { get => _gameSceneName; set => _gameSceneName = value; }

    MissionInfoHolder _missionInfoHolder;

    private void Start()
    {
        _standByButton.onClick.AddListener(() => SceneManager.LoadScene(_gameSceneName));
        _missionInfoHolder = FindObjectOfType<MissionInfoHolder>();
    }

    private void Update()
    {
        _gameSceneName = _missionInfoHolder.CurrentMission.MissionSceneName;
    }

}
