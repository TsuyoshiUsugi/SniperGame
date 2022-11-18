using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/// <summary>
/// �v���C���[�̃J�����𑀍삷��R���|�[�l���g
/// </summary>
public class PlayerCamController : MonoBehaviour
{
    [Header("�Q��")]
    [SerializeField] InputManager _inputManager;
    [SerializeField] GameObject _eye;

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


    private void Start()
    {
        EulerToQuaternion();

        _inputManager.OnAimButttonDownEvent += () => Aim();
    }

    void Aim()
    {

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
        _camDir = new Vector2(Mathf.Clamp(_camDir.x, -1, 1), Mathf.Clamp(_camDir.y, -1, 1));
    }

    /// <summary>
    /// ���_�̉�]
    /// </summary>
    void Rotate()
    {
        _camX += _camDir.x * _camSpeed / _camDetailSensitivity;
        _camY -= _camDir.y * _camSpeed / _camDetailSensitivity;

        this.transform.rotation = Quaternion.AngleAxis(_camX, Vector3.up);
        _eye.transform.localRotation = Quaternion.AngleAxis(_camY, Vector3.right);

        RorateAngleLimit();

        //�p�x�𐧌�����
        void RorateAngleLimit()
        {
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
