using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 選択中のミッション情報を保持する
/// これは一度生成されるとゲーム中は保持され続け、各シーンから参照される
/// </summary>
public class MissionInfoHolder : SingletonMonobehavior<MissionInfoHolder>
{
    [SerializeField] MissionInfo _currentMission;
    public MissionInfo CurrentMission { get => _currentMission; set => _currentMission = value; }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
