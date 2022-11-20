using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Linq;

/// <summary>
/// �v���C���[�̃J�����𑀍삷��R���|�[�l���g
/// </summary>
public class PlayerCamController : MonoBehaviour
{
    [Header("�Q��")]
    [SerializeField] InputManager _inputManager;
    [SerializeField] GameObject _eye;
    [SerializeField] CinemachineVirtualCamera _playerCam;
    [SerializeField] CinemachineVirtualCamera _scopeCam;
    [SerializeField] Rigidbody _bodyRb;
    [SerializeField] Rigidbody _eyeRb;

    [Header("�ݒ�l")]
    [SerializeField] float _camSpeed;
    [SerializeField, Tooltip("�J������@�ׂɓ������ׂ̒l�B�}�E�X���͂̒l�����̒l�Ŋ���")] float _camDetailSensitivity;
    [SerializeField] float _maxVerticalAngle;
    [SerializeField] float _minVerticalAngle;
    Quaternion _quaternionYMaxAngle;
    Quaternion _quaternionYMinAngle;

    [Header("�m�F�p�t�B�[���h")]
    [SerializeField] Vector2 _camDir;
    [SerializeField] float _camX = 0;
    [SerializeField] float _camY = 0;

    private void Awake()
    {
        InitializeCamPriority();
    }

    /// <summary>
    /// �J�����̗D��x�̏�����
    /// �ʏ펞�̃J������Priority���P�ɂ���
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
    /// �J�����̐����p�x���N�I�[�^�j�I���ɒ���
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
    /// ���͂�ǂݎ��
    /// </summary>
    private void ReadInput()
    {
        _camDir = _inputManager.CamDir;
        _camDir = new Vector2(Mathf.Clamp(_camDir.x, -1, 1), Mathf.Clamp(_camDir.y, -1, 1));
        
    }

    /// <summary>
    /// ���_�̉�]
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

        //�p�x�𐧌�����
        void RorateAngleLimit()
        {
            //�c
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

            //��
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
