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
    [SerializeField] public string MissionSceneName;
    public List<TargetInfo> _targetInfos;
    public EnemyInfo _enemyInfo;
    public StageInfo _stageInfo;
    public float HighScore = 0;

    /// <summary>
    /// ターゲット情報まとめたクラス
    /// </summary>
    [Serializable]
    public class TargetInfo
    {
        [SerializeField] string _targetName;
        public string TargetName => _targetName;

        [SerializeField] Sprite _targetImage;
        public Sprite TargetImage => _targetImage;

        [SerializeField] string _targetInfo;
        public String TargetInfomation => _targetInfo;

        [SerializeField] Vector3 _targetMovePoints; //ここはターゲットの移動地点の参照
    }

    /// <summary>
    /// ザコ敵の情報をまとめたクラス
    /// </summary>
    [Serializable]
    public class EnemyInfo
    {
        /*
        ここに書くべきなのは、
        ・ザコ敵の生成位置
        ・巡回ルート
        ・戦闘時の移動地点

        */
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
