using UnityEngine.Events;
using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// ���͂�ǂݎ��}�l�[�W���[�R���|�[�l���g
/// �V�[�����܂����ł����݂���singleton�N���X
/// </summary>
public class InputManager : SingletonMonobehavior<InputManager>
{
    SniperGameInputAction _inputActions;

    //�O���Ɍ��J����C�x���g�ꗗ
    public Action OnAnyButtonDownEvent;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);

        _inputActions = new SniperGameInputAction();
        _inputActions.Enable();

        //��������C�x���g�o�^
        _inputActions.UI.AnyButtonDown.performed += context =>
        {
            DebugText();
            OnAnyButtonDownEvent.Invoke();
        };
    }

    void DebugText()
    {
        Debug.Log("ok");
    }

}
