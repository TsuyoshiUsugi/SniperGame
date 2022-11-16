using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/// <summary>
/// �v���C���[�̎��_�𑀍삷��R���|�[�l���g
/// </summary>
public class PlayerCamController : MonoBehaviour
{
    [SerializeField] InputManager _inputManager;
    [SerializeField] GameObject _eye;

    [SerializeField] float _camSpeed;
    [SerializeField] Vector2 _camDir;
    [SerializeField] float _max;
    [SerializeField] float _min;

    [SerializeField] float _camX = 0;
    [SerializeField] float _camY = 0;
    Quaternion _quaternionMax;
    Quaternion _quaternionMin;


    private void Start()
    {
        EulerToQuaternion();

        _inputManager.OnAimButttonDownEvent += () => Aim();
    }

    private void EulerToQuaternion()
    {
        _quaternionMax = Quaternion.Euler(_max, 0, 0);
        _quaternionMin = Quaternion.Euler(_min, 0, 0);
    }

    void Aim()
    {

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
        var present = _camX;
        _camX += _camDir.x * _camSpeed;
        _camY += _camDir.y * _camSpeed;

        this.transform.rotation = Quaternion.AngleAxis(_camX, Vector3.up);
        _eye.transform.localRotation = Quaternion.AngleAxis(_camY, Vector3.right);


        if (_eye.transform.localRotation.x > _quaternionMax.x)
        {
            _eye.transform.localRotation = _quaternionMax;
            _camY = _max;
        }
        else if (_eye.transform.localRotation.x < _quaternionMin.x)
        {
            _eye.transform.localRotation = _quaternionMin;
            _camY = _min;
        }
    }
}
