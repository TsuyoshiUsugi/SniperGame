using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ミッション情報が記載されたスクリプタブルオブジェクト
/// 
/// 乗せるべき情報
/// ・ターゲット
/// ・ターゲットの画像
/// ・敵の数
/// ・敵の配置
/// ・敵の行動パターン
/// ・クリア記録
/// </summary>
[CreateAssetMenu(fileName ="MissionInfo", menuName = "ScriptableObjects/MissionInfo")]
public class MissionInfo : ScriptableObject
{

    [Header("ミッション名")]
    [SerializeField] public string MissionName;

    [Header("ターゲット情報")]
    [SerializeField] public string TargetName;

}
