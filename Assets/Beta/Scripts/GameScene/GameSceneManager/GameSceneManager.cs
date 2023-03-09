using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲームの進行管理を行う
/// 
/// 成功、失敗、ポーズの処理を行う
/// </summary>
public class GameSceneManager : MonoBehaviour
{
    [Header("参照")]
    [SerializeField] Timer _timer;
    [SerializeField] ScoreView _scoreView;
    [SerializeField] GameUIManager _gameUIManager;
    [SerializeField] Button _restart;
    [SerializeField] Button _missionTab;
    [SerializeField] Button _title;
    [SerializeField] string _playScene;
    [SerializeField] string _MissionTabScene;
    [SerializeField] string _titleScene;

    //Targetの生存確認につかう
    Dictionary<EnemyManager, EnemyInfo.EnemyState> _targetDic = new();

    private void Start()
    {
        _restart.onClick.AddListener(() => Restart());
        _missionTab.onClick.AddListener(() => ToMissionTab());
        _title.onClick.AddListener(() => ToTitleTab());
    }

    /// <summary>
    /// ターゲットの登録
    /// </summary>
    /// <param name="enemyManager"></param>
    public void RegisterTarget(EnemyManager enemyManager)
    {
        _targetDic.Add(enemyManager, EnemyInfo.EnemyState.Normal);
    }

    /// <summary>
    /// ターゲット死亡の登録の処理
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
    /// クリア演出と終わり次第結果シーンのロード
    /// </summary>
    void Clear()
    {
        TurnOffEnemyBehavior();

        FindObjectOfType<PlayerManager>().StopPlayerInput();

        Debug.Log("クリア");
        _gameUIManager.UnlockCursor();
        ScoreManager.Instance.Clear(_timer.CurrentTime);
        _scoreView.SetScoreView();
    }

    private void TurnOffEnemyBehavior()
    {
        var enemies = FindObjectsOfType<HighAlertEnemyBehavior>();

        foreach (var enemy in enemies)
        {
            enemy.enabled = false;
        }
    }

    /// <summary>
    /// 失敗の演出と終わり次第結果シーンのロード
    /// </summary>
    public void Failed()
    {
        FindObjectOfType<PlayerManager>().StopPlayerInput();

        TurnOffEnemyBehavior();
        ScoreManager.Instance.Fail();
        _gameUIManager.UnlockCursor();
        _scoreView.SetScoreView();
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
    /// ポーズ処理
    /// </summary>
    void Pose()
    {

    }
}
