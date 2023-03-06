using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

/// <summary>
/// いまあるミッションデータを読み取りミッションボタンを生成する
/// </summary>
public class MissionTabManager : MonoBehaviour
{
    [SerializeField] List<MissionInfo> _missionDataList;

    [Header("参照")]
    [SerializeField] GameObject _missionButtonPrefab;
    [SerializeField] GameObject _buttonAnker;

    [Header("表示するUIの参照")]
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
    /// リストにあるミッションの数だけボタンを生成する
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
    /// 押された時に情報欄に情報を表示する
    /// </summary>
    void ShowInfo(int index)
    {
        //_mapImage.sprite = info._stageInfo. <= map画像を表示する関数
        //_targetImage.sprite = info._targetInfos[0].TargetImage;
        int num = index - 1;
        _targetName.text = $"名前：{_missionDataList[num]._targetInfos[0].TargetName}";
        _targetInfo.text = $"詳細：{ _missionDataList[num]._targetInfos[0].TargetInfomation}";
        MissionInfoHolder.Instance.CurrentMission = _missionDataList[num];
    }
}


