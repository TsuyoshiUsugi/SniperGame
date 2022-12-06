using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

/// <summary>
/// ミッションデータを読み取りミッションボタンを生成する
/// </summary>
public class MissionTabManager : MonoBehaviour
{
    [SerializeField] List<MissionInfo> _missionDataList;

    [Header("参照")]
    [SerializeField] GameObject _missionButtonPrefab;
    [SerializeField] GameObject _buttonAnker;

    // Start is called before the first frame update
    void Awake()
    {
        GenerateMissionButton();
    }

    private void GenerateMissionButton()
    {
        for (int i = 0; i < _missionDataList.Count; i++)
        {
            GameObject missionButton = Instantiate(_missionButtonPrefab);
            missionButton.GetComponentInChildren<Text>().text = _missionDataList[i].MissionName;
            missionButton.transform.SetParent(_buttonAnker.transform);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
