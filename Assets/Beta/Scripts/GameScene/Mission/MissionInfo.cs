using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public List<TargetInfo> _targetInfos;
    public EnemyInfo _enemyInfo;
    public StageInfo _stageInfo;

    /// <summary>
    /// ターゲット情報まとめたクラス
    /// </summary>
    [Serializable]
    public class TargetInfo
    {
        [SerializeField] string _targetName;
        [SerializeField] Sprite _targetImage;
        [SerializeField] string _targetInfo;
        [SerializeField] Vector3 _targetAI; //ここは独自のAIクラスにする予定
        //モデルの参照を書く
    }

    /// <summary>
    /// ザコ敵の情報をまとめたクラス
    /// </summary>
    [Serializable]
    public class EnemyInfo
    {
        [SerializeField] int _targetNum;
        //独自のAIクラスの変数を用意
    　　//参照も書く
    }

    /// <summary>
    /// ステージ情報をまとめたクラス
    /// </summary>
    [Serializable]
    public class StageInfo
    {
        [SerializeField] int _stageIndex;
        [SerializeField] int _time;
        [SerializeField] float _windDirection;
    }
        


}
