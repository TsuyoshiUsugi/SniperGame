using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/// <summary>
/// プレイヤーの視点を操作するコンポーネント
/// </summary>
public class PlayerCamController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _playerCam;
    [SerializeField] AxisState _horizontalCam;
    [SerializeField] AxisState _verticalCam;

    [SerializeField] GameObject _eye;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 視点の回転
    /// </summary>
    void Rotate()
    {
        this.transform.rotation = Quaternion.AngleAxis(_horizontalCam.Value, Vector3.up);
        _eye.transform.localRotation = Quaternion.AngleAxis(_verticalCam.Value, Vector3.right);
    }
}
