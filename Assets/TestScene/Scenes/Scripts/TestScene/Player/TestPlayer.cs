using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TestPlayer : MonoBehaviour
{
    float _horizontal;
    float _vertical;

    [SerializeField] AxisState _horizontalCam;
    [SerializeField] AxisState _verticalCam;
    [SerializeField] float _speed;
    [SerializeField] Rigidbody _rb;
    [SerializeField] GameObject _eye;
    [SerializeField] CinemachineVirtualCamera _playerCam;
    [SerializeField] int _zoomPriority;
    [SerializeField] int _originPriority;

    // Update is called once per frame
    void Update()
    {
        ReadInput();

        Zoom();

        Rotate();

        
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// ���͂�ǂݎ��
    /// </summary>
    private void ReadInput()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        _horizontalCam.Update(Time.deltaTime);
        _verticalCam.Update(Time.deltaTime);
    }

    /// <summary>
    /// �L�������ړ�������
    /// </summary>
    private void Move()
    {
        Vector3 cameraForward = Vector3.Scale(transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 cameraRight = Vector3.Scale(transform.right, new Vector3(1, 0, 1)).normalized;
        Vector3 moveForward = cameraForward * _vertical + cameraRight * _horizontal;
        _rb.velocity = (moveForward * _speed + new Vector3(0, _rb.velocity.y, 0));
    }

    /// <summary>
    /// ���_�̉�]
    /// </summary>
    void Rotate()
    {
        this.transform.rotation = Quaternion.AngleAxis(_horizontalCam.Value, Vector3.up);
        _eye.transform.localRotation = Quaternion.AngleAxis(_verticalCam.Value, Vector3.right);
    }

    void Zoom()
    {
        if(Input.GetKey(KeyCode.Mouse1))
        {
            _playerCam.Priority = _zoomPriority;
        }
        else
        {
            _playerCam.Priority = _originPriority;
        }
    }
}
