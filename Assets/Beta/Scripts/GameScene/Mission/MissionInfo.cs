using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public List<TargetInfo> _targetInfos;
    public EnemyInfo _enemyInfo;
    public StageInfo _stageInfo;

    /// <summary>
    /// �^�[�Q�b�g���܂Ƃ߂��N���X
    /// </summary>
    [Serializable]
    public class TargetInfo
    {
        [SerializeField] string _targetName;
        [SerializeField] Sprite _targetImage;
        [SerializeField] string _targetInfo;
        [SerializeField] Vector3 _targetAI; //�����̓^�[�Q�b�g�̈ړ��n�_�̎Q��
    }

    /// <summary>
    /// �U�R�G�̏����܂Ƃ߂��N���X
    /// </summary>
    [Serializable]
    public class EnemyInfo
    {
        /*
        �����ɏ����ׂ��Ȃ̂́A
        �E�U�R�G�̐����ʒu
        �E���񃋁[�g
        �E�퓬���̈ړ��n�_

        */
    }

    /// <summary>
    /// �X�e�[�W�����܂Ƃ߂��N���X
    /// </summary>
    [Serializable]
    public class StageInfo
    {
        [SerializeField] int _stageIndex;
        [SerializeField] int _time;
        [SerializeField] float _windDirection;
    }
        


}
