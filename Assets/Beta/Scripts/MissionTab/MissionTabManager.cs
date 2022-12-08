using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

/// <summary>
/// �~�b�V�����f�[�^��ǂݎ��~�b�V�����{�^���𐶐�����
/// </summary>
public class MissionTabManager : MonoBehaviour
{
    [SerializeField] List<MissionInfo> _missionDataList;

    [Header("�Q��")]
    [SerializeField] GameObject _missionButtonPrefab;
    [SerializeField] GameObject _buttonAnker;

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

            missionButton.GetComponent<Button>().onClick.AddListener(() => ShowInfo());
        }
    }

    void ShowInfo()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
