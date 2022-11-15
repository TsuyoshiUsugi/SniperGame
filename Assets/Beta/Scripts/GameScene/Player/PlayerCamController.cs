using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/// <summary>
/// プレイヤーの視点を操作するコンポーネント
/// </summary>
public class PlayerCamController : MonoBehaviour
{
    [SerializeField] InputManager _inputManager;
    [SerializeField] GameObject _eye;

    [SerializeField] float _camSpeed;
    [SerializeField] Vector2 _camDir;
    [SerializeField] float _verticalCamMaxAngle;
    [SerializeField] float _verticalCamMinAngle;

    float _camX = 0;
    float _camY = 0;
    // Start is called before the first frame update
    void Start()
    {
        
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
        _camDir = _inputManager.CamDir;
        _camDir = new Vector2(Mathf.Clamp(_camDir.x, -1, 1), Mathf.Clamp(_camDir.y, -1, 1));
    }

    /// <summary>
    /// 視点の回転
    /// </summary>
    void Rotate()
    {
        _camX += _camDir.x * _camSpeed;
        _camY += _camDir.y * _camSpeed;

        this.transform.rotation = Quaternion.AngleAxis(_camX, Vector3.up);
        _eye.transform.localRotation = Quaternion.AngleAxis(Mathf.Clamp(_camY, _verticalCamMinAngle, _verticalCamMaxAngle), Vector3.right);
    }

    
}
