using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCamControlManager : MonoBehaviour
{
    [Header("参照")]
    [SerializeField] GameObject _player;
    [SerializeField] InputManager _inputManager;

    [SerializeField] AxisState _rotateX;
    [SerializeField] AxisState _rotateY;

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
        
    }

    void Rotate()
    {
        
    }
}
