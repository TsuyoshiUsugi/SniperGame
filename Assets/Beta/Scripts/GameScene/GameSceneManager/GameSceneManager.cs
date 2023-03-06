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
    [SerializeField] string _resultSceneName;

    /// <summary>
    /// クリア演出と終わり次第結果シーンのロード
    /// </summary>
    public void Clear()
    {
        Debug.Log("クリア");
        SceneManager.LoadScene(_resultSceneName);
    }

    /// <summary>
    /// 失敗の演出と終わり次第結果シーンのロード
    /// </summary>
    public void Failed()
    {
        SceneManager.LoadScene(_resultSceneName);
    }

    /// <summary>
    /// ポーズ処理
    /// </summary>
    void Pose()
    {

    }
}
