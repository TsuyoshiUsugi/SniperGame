using System;
using System.IO;
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
        var savePath = Application.persistentDataPath + "/saveRecord.json";

        SaveHighScoreData loadData;
        loadData = LoadData(savePath);

        var recordString = loadData.ScoreRecord.Split(","); //配列は0:1223,1:2222というようになっている
        var preHighScore = 0;
        var registerRecord = "";

        for (int i = 0; i < recordString.Length; i++)
        {
            Debug.Log(recordString.Length);
            if (!recordString[i].StartsWith(MissionInfoHolder.Instance.CurrentMission.StageNum.ToString())) continue;

            var strNum = recordString[i].Split(":");
            preHighScore = int.Parse(strNum[1]);

            if (_score > preHighScore == false) return;
            strNum[1] = _score.ToString();

            var newRecord = strNum[0] + ":" + strNum[1];

            for (int j = 0; j <= recordString.Length - 1; j++)
            {
                if(j == 0 && i == j)
                {
                    registerRecord += newRecord;
                    Debug.Log("ok");
                }
                else if(j == 0)
                {
                    registerRecord += recordString[j];
                    Debug.Log("dame");
                }
                else if(j == i)
                {
                    registerRecord += "," + newRecord;
                }
                else
                {
                    registerRecord += "," + recordString[j];
                }
            }

            Debug.Log(registerRecord);
            loadData.ScoreRecord = registerRecord;

            string JsonData = JsonUtility.ToJson(loadData);
            using (StreamWriter streamWriter = new(savePath))
            {
                streamWriter.Write(JsonData);
            }
        }


    }

    private static SaveHighScoreData LoadData(string savePath)
    {
        SaveHighScoreData loadData;
        using (StreamReader streamReader = new(savePath))
        {
            var loadJson = streamReader.ReadToEnd();
            loadData = JsonUtility.FromJson<SaveHighScoreData>(loadJson);
        }

        return loadData;
    }

}

[Serializable]
public class SaveHighScoreData
{
    public string ScoreRecord;
}

