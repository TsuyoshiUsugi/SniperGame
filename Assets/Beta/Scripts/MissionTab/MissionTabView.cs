using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ミッション選択画面のミッション情報を表示するためのクラス
/// </summary>
public class MissionTabView : MonoBehaviour
{
    [Header("参照")]
    [SerializeField] Sprite _mapImage;
    [SerializeField] Sprite _targetImage;
    [SerializeField] Text _targetName;
    [SerializeField] Text _targetInfo;
}
