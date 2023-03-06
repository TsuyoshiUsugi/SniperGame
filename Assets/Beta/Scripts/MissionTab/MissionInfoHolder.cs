using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �I�𒆂̃~�b�V��������ێ�����
/// ����͈�x���������ƃQ�[�����͕ێ����ꑱ���A�e�V�[������Q�Ƃ����
/// </summary>
public class MissionInfoHolder : SingletonMonobehavior<MissionInfoHolder>
{
    [SerializeField] MissionInfo _currentMission;
    public MissionInfo CurrentMission { get => _currentMission; set => _currentMission = value; }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
