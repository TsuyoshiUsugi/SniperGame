using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �~�b�V������񂪋L�ڂ��ꂽ�X�N���v�^�u���I�u�W�F�N�g
/// 
/// �悹��ׂ����
/// �E�^�[�Q�b�g
/// �E�^�[�Q�b�g�̉摜
/// �E�G�̐�
/// �E�G�̔z�u
/// �E�G�̍s���p�^�[��
/// �E�N���A�L�^
/// </summary>
[CreateAssetMenu(fileName ="MissionInfo", menuName = "ScriptableObjects/MissionInfo")]
public class MissionInfo : ScriptableObject
{

    [Header("�~�b�V������")]
    [SerializeField] public string MissionName;

    [Header("�^�[�Q�b�g���")]
    [SerializeField] public string TargetName;

}
