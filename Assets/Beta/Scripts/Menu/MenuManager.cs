using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Menu�V�[���̃}�l�[�W���[�R���|�[�l���g
///�@
/// �@�\
/// �E�e�V�[���Ɉڍs
/// �E
/// 
/// </summary>
public class MenuManager : MonoBehaviour
{

    /// <summary>
    /// �~�b�V�����^�u�Ɉڍs
    /// </summary>
    public void OnClickedMissionButton()
    {
        SceneManager.LoadScene("MissionTab");
        Debug.Log("�ڍs");
    }

    /// <summary>
    /// �����^�u�Ɉڍs
    /// </summary>
    public void OnClickedEquipmentButton()
    {
        SceneManager.LoadScene("");
    }

    /// <summary>
    /// �J���^�u�Ɉڍs
    /// </summary>
    public void OnClickedDevelopButton()
    {
        SceneManager.LoadScene("");
    }

    /// <summary>
    /// �����L���O�^�u�Ɉڍs
    /// </summary>
    public void OnClickedRankingButton()
    {
        SceneManager.LoadScene("");
    }

}
