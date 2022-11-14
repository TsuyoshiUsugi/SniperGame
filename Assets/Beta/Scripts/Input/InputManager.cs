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

    public Action<Vector2> OnMoveButtonDownEvent;
    public Action OnFireButtonDownEvent;
    public Action OnAimButttonDownEvent;

    void Awake()
    {
        _inputActions = new SniperGameInputAction();
        _inputActions.Enable();

        //��������C�x���g�o�^
        //_inputActions.UI.AnyButtonDown.performed += context => { OnAnyButtonDownEvent.Invoke(); };

        _inputActions.Player.Move.performed += context => { OnMoveButtonDownEvent.Invoke(context.ReadValue<Vector2>()); };
        _inputActions.Player.Fire.performed += context => { OnFireButtonDownEvent.Invoke(); };
        _inputActions.Player.Aim.performed += context => { OnAimButttonDownEvent.Invoke(); };
    }
}
