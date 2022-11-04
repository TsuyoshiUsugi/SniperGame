using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Menuシーンのマネージャーコンポーネント
///　
/// 機能
/// ・各シーンに移行
/// ・
/// 
/// </summary>
public class MenuManager : MonoBehaviour
{

    /// <summary>
    /// ミッションタブに移行
    /// </summary>
    public void OnClickedMissionButton()
    {
        SceneManager.LoadScene("MissionTab");
        Debug.Log("移行");
    }

    /// <summary>
    /// 装備タブに移行
    /// </summary>
    public void OnClickedEquipmentButton()
    {
        SceneManager.LoadScene("");
    }

    /// <summary>
    /// 開発タブに移行
    /// </summary>
    public void OnClickedDevelopButton()
    {
        SceneManager.LoadScene("");
    }

    /// <summary>
    /// ランキングタブに移行
    /// </summary>
    public void OnClickedRankingButton()
    {
        SceneManager.LoadScene("");
    }

}
