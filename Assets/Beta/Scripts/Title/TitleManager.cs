using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �^�C�g���V�[���̃}�l�[�W���[�R���|�[�l���g
/// 
/// �@�\
/// menu�V�[���Ɉڍs����
/// </summary>
public class TitleManager : MonoBehaviour
{
    [SerializeField] string _menuScene;
    /// <summary>
    /// ���j���[�V�[���Ɉڍs����
    /// </summary>
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(_menuScene);
    }

}
