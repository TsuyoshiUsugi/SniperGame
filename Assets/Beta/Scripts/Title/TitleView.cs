using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// タイトルシーンのviewの変更を受け付けるコンポーネント
/// </summary>
public class TitleView : MonoBehaviour
{
    [SerializeField] Button _startButton;

    public event Action OnStartButtonClicked;

    private void Start()
    {
        _startButton.onClick.AddListener(() => OnStartButtonClicked());
    }
}
