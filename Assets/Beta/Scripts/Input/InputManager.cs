using UnityEngine.Events;
using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// ���͂�ǂݎ��}�l�[�W���[�R���|�[�l���g
/// </summary>
public class InputManager : MonoBehaviour
{
    SniperGameInputAction _inputActions;

    //�O���Ɍ��J����C�x���g�ꗗ
    public event Action OnAnyButtonDownEvent;
    public event Action<bool> OnAimButtonDownEvent;
    public event Action OnFireButttonDownEvent;

    public Vector2 MoveDir => _moveDir;
    Vector2 _moveDir;
    public Vector2 CamDir => _camDir;
    Vector2 _camDir;

    void Awake()
    {
        _inputActions = new SniperGameInputAction();
        _inputActions.Enable();

        //��������C�x���g�o�^
        //_inputActions.UI.AnyButtonDown.performed += context => { OnAnyButtonDownEvent.Invoke(); };

        _inputActions.Player.Move.performed += context =>  { _moveDir = context.ReadValue<Vector2>(); };
        _inputActions.Player.Move.canceled += context =>  { _moveDir = new Vector2(0,0); };

        _inputActions.Player.Look.performed += context => { _camDir = context.ReadValue<Vector2>(); };
        _inputActions.Player.Look.canceled += context => { _camDir = new Vector2(0, 0); };

        _inputActions.Player.Aim.started += context => { OnAimButtonDownEvent.Invoke(true); };
        _inputActions.Player.Aim.canceled += contex => { OnAimButtonDownEvent.Invoke(false); };
        _inputActions.Player.Fire.started += context => { OnFireButttonDownEvent.Invoke(); };
    }
}
