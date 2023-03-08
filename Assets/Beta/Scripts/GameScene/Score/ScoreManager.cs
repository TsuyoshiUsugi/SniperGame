using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スコアを計算する
/// </summary>
public class ScoreManager : SingletonMonobehavior<ScoreManager>
{
    [SerializeField] int _score;
    public int Score => _score;

    const int _clearScore = +10000;
    const int _failScore = -99999;
    const int _killScore = +1000;
    const int _detectedScore = -1000;

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
    }

    public void Clear(float time)
    {
        _score += TimeScoreBonus(time);
        _score += _clearScore;
    }

    public int TimeScoreBonus(float time)
    {
        return (int)(10000 * (1 / time));
    }

    public void Fail()
    {
        _score += _failScore;
    }

    public void Kill()
    {
        _score += _killScore;
    }

    public void Detected()
    {
        _score += _detectedScore;
    }
}
