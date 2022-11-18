using UnityEngine.Events;
using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// 入力を読み取るマネージャーコンポーネント
/// </summary>
public class InputManager : MonoBehaviour
{
    SniperGameInputAction _inputActions;

    //外部に公開するイベント一覧
    public Action OnAnyButtonDownEvent;
    public Action OnFireButtonDownEvent;
    public Action OnAimButttonDownEvent;

    public Vector2 MoveDir => _moveDir;
    Vector2 _moveDir;
    public Vector2 CamDir => _camDir;
    Vector2 _camDir;

    void Awake()
    {
        _inputActions = new SniperGameInputAction();
        _inputActions.Enable();

        //ここからイベント登録
        //_inputActions.UI.AnyButtonDown.performed += context => { OnAnyButtonDownEvent.Invoke(); };

        _inputActions.Player.Move.performed += context =>  { _moveDir = context.ReadValue<Vector2>(); };
        _inputActions.Player.Move.canceled += context =>  { _moveDir = new Vector2(0,0); };

        _inputActions.Player.Look.performed += context => { _camDir = context.ReadValue<Vector2>(); };
        _inputActions.Player.Look.canceled += context => { _camDir = new Vector2(0, 0); };

        _inputActions.Player.Fire.performed += context => { OnFireButtonDownEvent.Invoke(); };
        _inputActions.Player.Aim.performed += context => { OnAimButttonDownEvent.Invoke(); };
    }
}
