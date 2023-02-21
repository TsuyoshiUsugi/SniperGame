using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// �^�C�g���V�[����view�̕ύX���󂯕t����R���|�[�l���g
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
