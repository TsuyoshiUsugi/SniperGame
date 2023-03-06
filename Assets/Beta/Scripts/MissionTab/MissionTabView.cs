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
    [SerializeField] string _GameSceneName;

    private void Start()
    {
        _standByButton.onClick.AddListener(() => SceneManager.LoadScene(_GameSceneName));
    }
}
