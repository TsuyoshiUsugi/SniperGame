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

    [Header("�ݒ�l")]
    [SerializeField] float _camSpeed;
    [SerializeField, Tooltip("�J������@�ׂɓ������ׂ̒l�B�}�E�X���͂̒l�����̒l�Ŋ���")] float _camDetailSensitivity;
    [SerializeField] float _maxVerticalAngle;
    [SerializeField] float _minVerticalAngle;
    Quaternion _quaternionMaxAngle;
    Quaternion _quaternionMinAngle;

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
        _quaternionMaxAngle = Quaternion.Euler(_maxVerticalAngle, 0, 0);
        _quaternionMinAngle = Quaternion.Euler(_minVerticalAngle, 0, 0);
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
        Debug.Log(_camDir);
        _camDir = new Vector2(Mathf.Clamp(_camDir.x, -1, 1), Mathf.Clamp(_camDir.y, -1, 1));
        
    }

    /// <summary>
    /// ���_�̉�]
    /// </summary>
    void Rotate()
    {
        _camX += (_camDir.x / _camDetailSensitivity) * _camSpeed;
        _camY -= (_camDir.y / _camDetailSensitivity) * _camSpeed;

        this.transform.rotation = Quaternion.AngleAxis(_camX, Vector3.up);
        _eye.transform.localRotation = Quaternion.AngleAxis(_camY, Vector3.right);
        
        RorateAngleLimit();

        //�p�x�𐧌�����
        void RorateAngleLimit()
        {
            //�c
            if (_eye.transform.localRotation.x > _quaternionMaxAngle.x)
            {
                _eye.transform.localRotation = _quaternionMaxAngle;
                _camY = _maxVerticalAngle;
            }
            else if (_eye.transform.localRotation.x < _quaternionMinAngle.x)
            {
                _eye.transform.localRotation = _quaternionMinAngle;
                _camY = _minVerticalAngle;
            }
        }
    }
}
