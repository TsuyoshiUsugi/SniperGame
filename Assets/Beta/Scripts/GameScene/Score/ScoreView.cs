using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// スコアを表示する
/// </summary>
public class ScoreView : MonoBehaviour
{
    [Header("参照")]
    [SerializeField] GameObject _resultObj;
    [SerializeField] Timer _timer;
    [SerializeField] Text _ClearText;
    [SerializeField] Text _ClearScoreText;
    [SerializeField] Text _failText;
    [SerializeField] Text _failScoreText;
    [SerializeField] Text _timeText;
    [SerializeField] Text _timeScoreText;
    [SerializeField] Text _isDetectedText;
    [SerializeField] Text _isDetectedScoreText;
    [SerializeField] Text _killCountText;
    [SerializeField] Text _killCountScoreText;
    [SerializeField] Text _scoreText;
    [SerializeField] string _nonCheck;
    [SerializeField] Text _rankText;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _resultObj.SetActive(false);
    }

    public void SetScoreView()
    {
        _resultObj.SetActive(true);

        //ミッション成功
        if (ScoreManager.Instance.MissionClear)
        {
            _failText.text = _nonCheck;
            _ClearScoreText.text = ScoreManager.Instance.ClearScore.ToString();
        }
        
        //ミッション失敗
        if (ScoreManager.Instance.MissionFailed)
        {
            _ClearText.text = _nonCheck;
            _ClearScoreText.text = ScoreManager.Instance.FailScore.ToString();
        }

        //時間
        _timeText.text = $"{_timer.CountTime().min:00}:{_timer.CountTime().sec:00}";
        _timeScoreText.text = ScoreManager.Instance.TimeScore.ToString();

        //非検知
        if(ScoreManager.Instance.IsDetected)
        {
            _isDetectedScoreText.text = ScoreManager.Instance.DetectedScore.ToString();
        }
        else
        {
            _isDetectedText.text = _nonCheck;
            _isDetectedScoreText.text = "0";
        }

        //非目標殺傷数
        _killCountText.text = ScoreManager.Instance.KillCount.ToString();
        _killCountScoreText.text = (ScoreManager.Instance.KillCount * ScoreManager.Instance.KillScore).ToString();

        //スコア
        _scoreText.text = ScoreManager.Instance.Score.ToString();

        //ランク
        _rankText.text = ScoreManager.Instance.ScoreRank();

    }
}
