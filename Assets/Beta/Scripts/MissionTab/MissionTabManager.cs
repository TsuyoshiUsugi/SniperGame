using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

/// <summary>
/// ���܂���~�b�V�����f�[�^��ǂݎ��~�b�V�����{�^���𐶐�����
/// </summary>
public class MissionTabManager : MonoBehaviour
{
    [SerializeField] List<MissionInfo> _missionDataList;

    [Header("�Q��")]
    [SerializeField] GameObject _missionButtonPrefab;
    [SerializeField] GameObject _buttonAnker;

    [Header("�\������UI�̎Q��")]
    [SerializeField] Image _mapImage;
    [SerializeField] Image _targetImage;
    [SerializeField] Text _targetName;
    [SerializeField] Text _targetInfo;

    // Start is called before the first frame update
    void Awake()
    {
        GenerateMissionButton();
    }

    /// <summary>
    /// ���X�g�ɂ���~�b�V�����̐������{�^���𐶐�����
    /// </summary>
    private void GenerateMissionButton()
    {
        for (int i = 0; i < _missionDataList.Count; i++)
        {
            GameObject missionButton = Instantiate(_missionButtonPrefab);
            missionButton.GetComponentInChildren<Text>().text = _missionDataList[i].MissionName;
            missionButton.transform.SetParent(_buttonAnker.transform);
            Debug.Log(i);
            missionButton.GetComponent<Button>().onClick.AddListener(() => ShowInfo(i));
        }
    }

    /// <summary>
    /// �����ꂽ���ɏ�񗓂ɏ���\������
    /// </summary>
    void ShowInfo(int index)
    {
        //_mapImage.sprite = info._stageInfo. <= map�摜��\������֐�
        //_targetImage.sprite = info._targetInfos[0].TargetImage;
        int num = index - 1;
        _targetName.text = $"���O�F{_missionDataList[num]._targetInfos[0].TargetName}";
        _targetInfo.text = $"�ڍׁF{ _missionDataList[num]._targetInfos[0].TargetInfomation}";
        MissionInfoHolder.Instance.CurrentMission = _missionDataList[num];
    }
}


