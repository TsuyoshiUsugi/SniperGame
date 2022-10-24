using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// メニュー画面のボタン入力を読み取るスクリプト
/// </summary>
public class MenuButtonInput : MonoBehaviour
{
    [SerializeField] Button _missionButton;
    [SerializeField] Button _equipmentButton;
    [SerializeField] Button _developButton;
    [SerializeField] Button _rankingButton;
    [SerializeField] Button _noneButton;
    [SerializeField] Button _optionButton;

    public Action OnMissionButtonClicked;
    public Action OnEquipmentButtonClicked;
    public Action OnDevelopButtonClicked;
    public Action OnRankingButtonClicked;
    public Action OnNoneButtonClicked;
    public Action OnOptionButtonClicked;
    // Start is called before the first frame update
    void Start()
    {
        _missionButton.onClick.AddListener(() => OnMissionButtonClicked());
        _equipmentButton.onClick.AddListener(() => OnEquipmentButtonClicked());
        _developButton.onClick.AddListener(() => OnDevelopButtonClicked());
        _rankingButton.onClick.AddListener(() => OnRankingButtonClicked());
        _noneButton.onClick.AddListener(() => OnNoneButtonClicked());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
