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

    float _camX = 0;
    float _camY = 0;
    // Update is called once per frame
    void Update()
    {
        ReadInput();

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
        _camX += _camDir.x * _camSpeed;
        _camY += _camDir.y * _camSpeed;

        this.transform.rotation = Quaternion.AngleAxis(_camX, Vector3.up);
        _eye.transform.localRotation = Quaternion.AngleAxis(_camY, Vector3.right);
    }
}
