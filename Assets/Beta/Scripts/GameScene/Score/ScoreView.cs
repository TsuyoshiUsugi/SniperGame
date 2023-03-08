using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �X�R�A��\������
/// </summary>
public class ScoreView : MonoBehaviour
{
    [Header("�Q��")]
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

        //�~�b�V��������
        if (ScoreManager.Instance.MissionClear)
        {
            _failText.text = _nonCheck;
            _ClearScoreText.text = ScoreManager.Instance.ClearScore.ToString();
        }
        
        //�~�b�V�������s
        if (ScoreManager.Instance.MissionFailed)
        {
            _ClearText.text = _nonCheck;
            _ClearScoreText.text = ScoreManager.Instance.FailScore.ToString();
        }

        //����
        _timeText.text = $"{_timer.CountTime().min:00}:{_timer.CountTime().sec:00}";
        _timeScoreText.text = ScoreManager.Instance.TimeScore.ToString();

        //�񌟒m
        if(ScoreManager.Instance.IsDetected)
        {
            _isDetectedScoreText.text = ScoreManager.Instance.DetectedScore.ToString();
        }
        else
        {
            _isDetectedText.text = _nonCheck;
            _isDetectedScoreText.text = "0";
        }

        //��ڕW�E����
        _killCountText.text = ScoreManager.Instance.KillCount.ToString();
        _killCountScoreText.text = (ScoreManager.Instance.KillCount * ScoreManager.Instance.KillScore).ToString();

        //�X�R�A
        _scoreText.text = ScoreManager.Instance.Score.ToString();

        //�����N
        _rankText.text = ScoreManager.Instance.ScoreRank();

    }
}
