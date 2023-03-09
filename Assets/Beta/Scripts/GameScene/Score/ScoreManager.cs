using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// スコアを計算する
/// </summary>
public class ScoreManager : SingletonMonobehavior<ScoreManager>
{
    [SerializeField] int _score;
    [SerializeField] int _highScoreBorder;
    public int Score => _score;

    public readonly int ClearScore = +10000;
    public readonly int FailScore = 0;
    public readonly int KillScore = -100;
    public readonly int DetectedScore = -3000;
    public readonly int TimeScoreBonusScore = -100;
    public readonly float SRankRatio = 0.9f;
    public readonly float ARankRatio = 0.8f;
    public readonly float BRankRatio = 0.7f;

    bool _missionClear = false;
    public bool MissionClear => _missionClear;

    bool _missionFailed = false;
    public bool MissionFailed => _missionFailed;

    bool _isDetected = false;
    public bool IsDetected => _isDetected;

    int _killCount = 0;
    public int KillCount => _killCount;

    int _timeScore = 0;
    public int TimeScore => _timeScore;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _score = 0;
        _missionClear = false;
        _missionFailed = false;
        _isDetected = false;
        _killCount = 0;
    }

    /// <summary>
    /// スコアのランクをS,A,B,Cのいずれかで返す
    /// </summary>
    /// <returns></returns>
    public string ScoreRank()
    {
        return _score switch
        {
            int score when score >= (float)_highScoreBorder * SRankRatio => "S",
            int score when (float)_highScoreBorder * SRankRatio > score && score >= (float)_highScoreBorder * ARankRatio => "A",
            int score when (float)_highScoreBorder * ARankRatio > score && score >= (float)_highScoreBorder * BRankRatio => "B",
            _ => "C",
        };
    }

    public void Clear(float time)
    {
        _missionClear = true;
        _score += TimeScoreBonus(time);
        _score += ClearScore;
        CompareScore();
        Debug.Log(ScoreRank());
        this.enabled = false;
    }

    public int TimeScoreBonus(float time)
    {
        _timeScore = (int)(TimeScoreBonusScore * time);
        return (int)(TimeScoreBonusScore * time);
    }

    public void Fail()
    {
        _missionFailed = true;
        _score += FailScore;
        this.enabled = false;
    }

    public void Kill()
    {
        _score += KillScore;
        _killCount++;
    }

    public void Detected()
    {
        _score += DetectedScore;
        _isDetected = true;
    }

    void CompareScore()
    {
        float preHighScore = MissionInfoHolder.Instance.CurrentMission.HighScore;
        if(_score > preHighScore)
        {
            MissionInfoHolder.Instance.CurrentMission.HighScore = _score;

            EditorUtility.SetDirty(MissionInfoHolder.Instance.CurrentMission);

            AssetDatabase.SaveAssets();
        }
    }
}
