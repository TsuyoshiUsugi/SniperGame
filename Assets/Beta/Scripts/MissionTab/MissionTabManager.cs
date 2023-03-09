using System.IO;
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
    [SerializeField] Text _highScoreText;

    // Start is called before the first frame update
    void Awake()
    {
        GenerateMissionButton();
        ShowInfo(0);
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
            int num = i;
            missionButton.GetComponent<Button>().onClick.AddListener(() => ShowInfo(num));
        }
    }

    /// <summary>
    /// �����ꂽ���ɏ�񗓂ɏ���\������
    /// </summary>
    void ShowInfo(int index)
    {

        int num = index;
        _targetImage.sprite = _missionDataList[num]._targetInfos[0].TargetImage;
        _mapImage.sprite = _missionDataList[num]._targetInfos[0].MapImage;
        _targetName.text = $"���O�F{_missionDataList[num]._targetInfos[0].TargetName}";
        _targetInfo.text = $"�ڍׁF{ _missionDataList[num]._targetInfos[0].TargetInfomation}";

        _highScoreText.text = $"�n�C�X�R�A�F{LoadHighScore(num)}";

        MissionInfoHolder.Instance.CurrentMission = _missionDataList[num];
    }

    int LoadHighScore(int num)
    {
        var savePath = Application.persistentDataPath + "/saveRecord.json";
        SaveHighScoreData loadData;

        if (File.Exists(savePath) == false)
        {
            GenarateSaveFile(savePath);
            Debug.Log("�Z�[�u�f�[�^���Ȃ������̂Ő���");
        }

        using (StreamReader streamReader = new(savePath))
        {
            var loadJson = streamReader.ReadToEnd();
            loadData = JsonUtility.FromJson<SaveHighScoreData>(loadJson);
        }

        var recordString = loadData.ScoreRecord.Split(","); //�z���"0:1223","1:2222"�Ƃ����悤�ɂȂ��Ă���

        foreach (var str in recordString)
        {
            if (str.StartsWith(num.ToString()))
            {
                var strNum = str.Split(":");
                return int.Parse(strNum[1]);
            }
        }

        return 0;
    }

    private void GenarateSaveFile(string savePath)
    {
        SaveHighScoreData firstData = new();

        for (int i = 0; i < _missionDataList.Count; i++)
        {
            firstData.ScoreRecord += $"{i}:{0},";
        }

        string firstJsonData = JsonUtility.ToJson(firstData);
        using (StreamWriter streamWriter = new(savePath))
        {
            streamWriter.Write(firstJsonData);
        }
    }
}

namespace SaveAndLoad
{


}



