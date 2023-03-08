using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// �Q�[���̐i�s�Ǘ����s��
/// 
/// �����A���s�A�|�[�Y�̏������s��
/// </summary>
public class GameSceneManager : MonoBehaviour
{
    [Header("�Q��")]
    [SerializeField] string _resultSceneName;
    [SerializeField] Timer _timer;
    [SerializeField] ScoreView _scoreView;
    [SerializeField] GameUIManager _gameUIManager;
    [SerializeField] Button _restart;
    [SerializeField] Button _missionTab;
    [SerializeField] Button _title;
    [SerializeField] string _playScene;
    [SerializeField] string _MissionTabScene;
    [SerializeField] string _titleScene;

    //Target�̐����m�F�ɂ���
    Dictionary<EnemyManager, EnemyInfo.EnemyState> _targetDic = new();

    private void Start()
    {
        _restart.onClick.AddListener(() => Restart());
        _missionTab.onClick.AddListener(() => ToMissionTab());
        _title.onClick.AddListener(() => ToTitleTab());
    }

    /// <summary>
    /// �^�[�Q�b�g�̓o�^
    /// </summary>
    /// <param name="enemyManager"></param>
    public void RegisterTarget(EnemyManager enemyManager)
    {
        _targetDic.Add(enemyManager, EnemyInfo.EnemyState.Normal);
    }

    /// <summary>
    /// �^�[�Q�b�g���S�̓o�^�̏���
    /// </summary>
    public void RegisterTargetDown(EnemyManager enemyManager)
    {
        _targetDic[enemyManager] = EnemyInfo.EnemyState.Death;
        CheckTargetAlive();
    }

    void CheckTargetAlive()
    {
        foreach (var target in _targetDic)
        {
            if (target.Value != EnemyInfo.EnemyState.Death) return; 
        }

        Clear();
    }

    /// <summary>
    /// �N���A���o�ƏI��莟�挋�ʃV�[���̃��[�h
    /// </summary>
    void Clear()
    {
        Debug.Log("�N���A");
        _gameUIManager.UnlockCursor();
        ScoreManager.Instance.Clear(_timer.CurrentTime);
        _scoreView.SetScoreView();
    }

    /// <summary>
    /// ���s�̉��o�ƏI��莟�挋�ʃV�[���̃��[�h
    /// </summary>
    public void Failed()
    {
        Debug.Log("���s");
        ScoreManager.Instance.Fail();
    }

    void Restart()
    {
        SceneManager.LoadScene(_playScene);
    }

    void ToMissionTab()
    {
        SceneManager.LoadScene(_MissionTabScene);
    }

    void ToTitleTab()
    {
        SceneManager.LoadScene(_titleScene);
    }

    /// <summary>
    /// �|�[�Y����
    /// </summary>
    void Pose()
    {

    }
}
