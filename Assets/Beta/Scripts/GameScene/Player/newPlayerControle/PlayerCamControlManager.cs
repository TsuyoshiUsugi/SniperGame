using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCamControlManager : MonoBehaviour
{
    [Header("設定")]
    [SerializeField] AxisState _rotateX;
    [SerializeField] AxisState _rotateY;
    [SerializeField] float _rotateXGap;

    [Header("参照")]
    [SerializeField] InputManager _inputManager;
    [SerializeField] GameObject _rotateXObj;
    [SerializeField] CinemachineVirtualCamera _playerCam;
    [SerializeField] CinemachineVirtualCamera _scopeCam;

    private void Start()
    {
        _rotateX.Value += _rotateXGap;
        _inputManager.OnAimButtonDownEvent += isPressed => Aim(isPressed);
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();

        Rotate();
    }

    /// <summary>
    /// 入力を読み取る
    /// </summary>
    private void ReadInput()
    {
        _rotateX.Update(Time.deltaTime);
        _rotateY.Update(Time.deltaTime);
    }

    void Rotate()
    {
        var horizon = Quaternion.AngleAxis(_rotateX.Value, Vector3.up);
        var vertical = Quaternion.AngleAxis(_rotateY.Value, Vector3.right);

        transform.rotation = horizon;
        _rotateXObj.transform.localRotation = vertical;
    }

    void Aim(bool isPressed)
    {
        if (isPressed)
        {
            _scopeCam.Priority = 1;
            _playerCam.Priority = 0;
        }
        else if (!isPressed)
        {
            _scopeCam.Priority = 0;
            _playerCam.Priority = 1;
        }

    }

    private void OnDisable()
    {
        Action<bool> disPoseEvent = (isPressed) => Aim(isPressed);
        _inputManager.OnAimButtonDownEvent -= disPoseEvent;
    }

}
