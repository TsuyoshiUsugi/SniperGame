using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// ミッション選択画面のミッション情報を表示するためのクラス
/// </summary>
public class MissionTabView : MonoBehaviour
{
    [Header("参照")]
    [SerializeField] Button _standByButton;

    [Header("設定値")]
    [SerializeField] string _gameSceneName;
    public string GameSceneName { get => _gameSceneName; set => _gameSceneName = value; }

    MissionInfoHolder _missionInfoHolder;

    private void Start()
    {
        _standByButton.onClick.AddListener(() => MoveToPlayScene());
        _missionInfoHolder = FindObjectOfType<MissionInfoHolder>();
    }

    void MoveToPlayScene()
    {
        _gameSceneName = _missionInfoHolder.CurrentMission.MissionSceneName;
        SceneManager.LoadScene(_gameSceneName);
    }

}
