using UnityEngine.Events;
using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// ���͂�ǂݎ��}�l�[�W���[�R���|�[�l���g
/// �V�[�����܂����ł����݂���singleton�N���X
/// </summary>
public class InputManager : MonoBehaviour
{
    SniperGameInputAction _inputActions;

    //�O���Ɍ��J����C�x���g�ꗗ
    public Action OnAnyButtonDownEvent;

    public Vector2 MoveDir => _moveDir;
    Vector2 _moveDir;

    public Action OnFireButtonDownEvent;
    public Action OnAimButttonDownEvent;

    void Awake()
    {
        _inputActions = new SniperGameInputAction();
        _inputActions.Enable();

        //��������C�x���g�o�^
        //_inputActions.UI.AnyButtonDown.performed += context => { OnAnyButtonDownEvent.Invoke(); };

        _inputActions.Player.Move.performed += context =>  { _moveDir = context.ReadValue<Vector2>(); };
        _inputActions.Player.Move.canceled += context =>  { _moveDir = new Vector2(0,0); };

        _inputActions.Player.Fire.performed += context => { OnFireButtonDownEvent.Invoke(); };
        _inputActions.Player.Aim.performed += context => { OnAimButttonDownEvent.Invoke(); };
    }
}
