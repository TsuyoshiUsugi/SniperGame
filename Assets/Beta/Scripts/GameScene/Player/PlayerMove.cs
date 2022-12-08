using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/// <summary>
/// �v���C���[�̓��͂�ǂݎ�蓮�����R���|�[�l���g
/// </summary>
public class PlayerMove : MonoBehaviour
{
    [SerializeField] InputManager _inputManager;
    [SerializeField] Rigidbody _rb;
    [SerializeField] CinemachineVirtualCamera _camera;

    [SerializeField] float _speed;
    // Start is called before the first frame update

    private void FixedUpdate()
    {
        Move(_inputManager.MoveDir);

    }

    void Move(Vector2 input)
    {
        float horizontal = input.x;
        float vertical = input.y;

        var cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 dir = cameraForward * vertical +
                Camera.main.transform.right * horizontal;

        _rb.velocity = dir * _speed + new Vector3(0, _rb.velocity.y, 0f);
    }

}
