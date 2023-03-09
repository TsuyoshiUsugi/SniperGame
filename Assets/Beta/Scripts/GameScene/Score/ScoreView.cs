using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
    [SerializeField] List<Text> _rightTexts;
    [SerializeField] List<Text> _midleTexts;
    [SerializeField] List<Text> _leftTexts;

    float _showDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        
    }

    private void Initialize()
    {
        _resultObj.SetActive(false);
        _leftTexts.ForEach(text => text.DOFade(0, 0));
        _midleTexts.ForEach(text => text.DOFade(0, 0));
        _rightTexts.ForEach(text => text.DOFade(0, 0));
        _rankText.gameObject.SetActive(false);

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
        if (ScoreManager.Instance.IsDetected)
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

        StartCoroutine(nameof(ShowResult));
    }

    IEnumerator ShowResult()
    {
        var endValue = 38;
        var startValue = 622;
        var dur = 1f;

        var resultObjRect = _resultObj.GetComponent<RectTransform>();
        resultObjRect.position = new(resultObjRect.position.x, startValue, resultObjRect.position.z);
        resultObjRect.DOAnchorPosY(endValue, dur);

        yield return new WaitForSeconds(_showDelay);

        for (int i = 0; i < _midleTexts.Count; i++)
        {
            AlphaAnim(_leftTexts[i]);
            AlphaAnim(_midleTexts[i]);
            AlphaAnim(_rightTexts[i]);

            yield return new WaitForSeconds(_showDelay);
        }

        AlphaAnim(_leftTexts[_leftTexts.Count - 1]);
        AlphaAnim(_rightTexts[_rightTexts.Count - 1]);

        yield return new WaitForSeconds(_showDelay);

        _rankText.gameObject.SetActive(true);
    }

    void AlphaAnim(Text text)
    {
        var alpha = 1;
        var delay = 0.25f;

        DOTween.ToAlpha(() => text.color, color => text.color = color, alpha, delay);
    }
}
