using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲームの進行管理を行う
/// 
/// 成功、失敗、ポーズの処理を行う
/// </summary>
public class GameSceneManager : MonoBehaviour
{
    [Header("参照")]
    [SerializeField] string _resultSceneName;
    [SerializeField] Timer _timer;

    //Targetの生存確認につかう
    Dictionary<EnemyManager, EnemyInfo.EnemyState> _targetDic = new();

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
        Debug.Log("クリア");
        ScoreManager.Instance.Clear(_timer.CurrentTime);
        //SceneManager.LoadScene(_resultSceneName);
    }

    /// <summary>
    /// 失敗の演出と終わり次第結果シーンのロード
    /// </summary>
    public void Failed()
    {
        Debug.Log("失敗");
        ScoreManager.Instance.Fail();
        //SceneManager.LoadScene(_resultSceneName);
    }

    /// <summary>
    /// ポーズ処理
    /// </summary>
    void Pose()
    {

    }
}
