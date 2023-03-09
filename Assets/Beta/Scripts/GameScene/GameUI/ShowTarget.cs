using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTarget : MonoBehaviour
{
    [SerializeField] Image _showTargetUI;
    // Start is called before the first frame update
    void Start()
    {
        _showTargetUI.sprite = MissionInfoHolder.Instance.CurrentMission._targetInfos[0].TargetImage;
    }

}
