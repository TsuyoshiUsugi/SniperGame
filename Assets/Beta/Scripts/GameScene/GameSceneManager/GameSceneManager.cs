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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// クリア演出と終り次第結果シーンのロード
    /// </summary>
    public void Clear()
    {
        Debug.Log("クリア");
        SceneManager.LoadScene(_resultSceneName);
    }

    /// <summary>
    /// 失敗の演出と終り次第結果シーンのロード
    /// </summary>
    void Failed()
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
