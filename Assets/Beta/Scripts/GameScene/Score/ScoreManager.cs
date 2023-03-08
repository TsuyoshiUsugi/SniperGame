using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スコアを計算する
/// </summary>
public class ScoreManager : SingletonMonobehavior<ScoreManager>
{
    [SerializeField] int _score;
    [SerializeField] int _highScoreBorder;
    public int Score => _score;

    const int _clearScore = +10000;
    const int _failScore = -99999;
    const int _killScore = -100;
    const int _detectedScore = -3000;
    const int _timeScoreBonus = -100;
    const float _sRank = 0.9f;
    const float _aRank = 0.8f;
    const float _bRank = 0.7f;

    bool _missionClear = false;
    public bool MissionClear => _missionClear;

    bool _missionFailed = false;
    public bool MissionFailed => _missionFailed;

    bool _isDetected = false;
    public bool IsDetected => _isDetected;

    int _killCount = 0;
    public int KillCount => _killCount;

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
            int score when score >= (float)_highScoreBorder * _sRank => "S",
            int score when (float)_highScoreBorder * _sRank > score && score >= (float)_highScoreBorder * _aRank => "A",
            int score when (float)_highScoreBorder * _aRank > score && score >= (float)_highScoreBorder * _bRank => "B",
            _ => "C",
        };
    }

    public void Clear(float time)
    {
        _missionClear = true;
        _score += TimeScoreBonus(time);
        _score += _clearScore;
        Debug.Log(ScoreRank());
    }

    int TimeScoreBonus(float time)
    {
        return (int)(_timeScoreBonus * time);
    }

    public void Fail()
    {
        _missionFailed = true;
        _score += _failScore;
    }

    public void Kill()
    {
        _score += _killScore;
        _killCount++;
    }

    public void Detected()
    {
        _score += _detectedScore;
        _isDetected = true;
    }
}
