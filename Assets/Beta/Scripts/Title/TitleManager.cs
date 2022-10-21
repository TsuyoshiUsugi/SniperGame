using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// タイトルシーンのマネージャーコンポーネント
/// 
/// 機能
/// menuシーンに移行する
/// </summary>
public class TitleManager : MonoBehaviour
{
    [SerializeField] string _menuScene;
    /// <summary>
    /// メニューシーンに移行する
    /// </summary>
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(_menuScene);
    }

}
