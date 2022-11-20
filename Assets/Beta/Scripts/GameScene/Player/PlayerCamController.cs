using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Linq;

/// <summary>
/// プレイヤーのカメラを操作するコンポーネント
/// </summary>
public class PlayerCamController : MonoBehaviour
{
    [Header("参照")]
    [SerializeField] InputManager _inputManager;
    [SerializeField] GameObject _eye;
    [SerializeField] CinemachineVirtualCamera _playerCam;
    [SerializeField] CinemachineVirtualCamera _scopeCam;
    [SerializeField] Rigidbody _bodyRb;
    [SerializeField] Rigidbody _eyeRb;

    [Header("設定値")]
    [SerializeField] float _camSpeed;
    [SerializeField, Tooltip("カメラを繊細に動かす為の値。マウス入力の値をこの値で割る")] float _camDetailSensitivity;
    [SerializeField] float _maxVerticalAngle;
    [SerializeField] float _minVerticalAngle;
    Quaternion _quaternionYMaxAngle;
    Quaternion _quaternionYMinAngle;

    [Header("確認用フィールド")]
    [SerializeField] Vector2 _camDir;
    [SerializeField] float _camX = 0;
    [SerializeField] float _camY = 0;

    private void Awake()
    {
        InitializeCamPriority();
    }

    /// <summary>
    /// カメラの優先度の初期化
    /// 通常時のカメラのPriorityを１にする
    /// </summary>
    private void InitializeCamPriority()
    {
        _scopeCam.Priority = 0;
        _playerCam.Priority = 1;
    }

    private void Start()
    {
        EulerToQuaternion();

        _inputManager.OnAimButtonDownEvent += isPressed => Aim(isPressed);
    }

    void Aim(bool isPressed)
    {
        if (isPressed)
        {
            _scopeCam.Priority = 1;
            _playerCam.Priority = 0;
        } 
        else if(!isPressed)
        {
            _scopeCam.Priority = 0;
            _playerCam.Priority = 1;
        }

    }

    /// <summary>
    /// カメラの制限角度をクオータニオンに直す
    /// </summary>
    private void EulerToQuaternion()
    {
        _quaternionYMaxAngle = Quaternion.Euler(_maxVerticalAngle, 0, 0);
        _quaternionYMinAngle = Quaternion.Euler(_minVerticalAngle, 0, 0);
    }

    

    void Update()
    {
        ReadInput(); 
    }

    private void FixedUpdate()
    {
        Rotate();


    }

    /// <summary>
    /// 入力を読み取る
    /// </summary>
    private void ReadInput()
    {
        _camDir = _inputManager.CamDir;
        _camDir = new Vector2(Mathf.Clamp(_camDir.x, -1, 1), Mathf.Clamp(_camDir.y, -1, 1));
        
    }

    /// <summary>
    /// 視点の回転
    /// </summary>
    void Rotate()
    {
        _camX += (_camDir.x / _camDetailSensitivity) * _camSpeed;
        _camY -= (_camDir.y / _camDetailSensitivity) * _camSpeed;

        _bodyRb.rotation = Quaternion.AngleAxis(_camX, Vector3.up);
        //transform.rotation = Quaternion.AngleAxis(_camX, Vector3.up);
        _eye.transform.localRotation = Quaternion.AngleAxis(_camY, Vector3.right);

        //_bodyRb.AddTorque(transform.up * _camDir.x * _);
        //_eyeRb.AddTorque(transform.right * _camY);
        
        RorateAngleLimit();

        //角度を制限する
        void RorateAngleLimit()
        {
            //縦
            if (_eye.transform.localRotation.x > _quaternionYMaxAngle.x)
            {
                _eye.transform.localRotation = _quaternionYMaxAngle;
                _camY = _maxVerticalAngle;
            }
            else if (_eye.transform.localRotation.x < _quaternionYMinAngle.x)
            {
                _eye.transform.localRotation = _quaternionYMinAngle;
                _camY = _minVerticalAngle;
            }

            //横
            if (_camX > 360)
            {
                _camX = 0;
            }
            else if (_camX < 0)
            {
                _camX = 360;
            }

        }
    }
}
