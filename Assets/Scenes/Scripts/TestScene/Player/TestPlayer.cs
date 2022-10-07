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
    /// “ü—Í‚ð“Ç‚ÝŽæ‚é
    /// </summary>
    private void ReadInput()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        _horizontalCam.Update(Time.deltaTime);
        _verticalCam.Update(Time.deltaTime);
    }

    /// <summary>
    /// ƒLƒƒƒ‰‚ðˆÚ“®‚³‚¹‚é
    /// </summary>
    private void Move()
    {
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveForward = cameraForward * _vertical + Camera.main.transform.right * _horizontal;
        _rb.velocity = (moveForward * _speed + new Vector3(0, _rb.velocity.y, 0));
    }

    /// <summary>
    /// Ž‹“_‚Ì‰ñ“]
    /// </summary>
    void Rotate()
    {
        var horizontalRotation = Quaternion.AngleAxis(_horizontalCam.Value, Vector3.up);
        var verticalRotation = Quaternion.AngleAxis(_verticalCam.Value, Vector3.right);
        this.transform.rotation = horizontalRotation;
        _eye.transform.localRotation = verticalRotation;
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
