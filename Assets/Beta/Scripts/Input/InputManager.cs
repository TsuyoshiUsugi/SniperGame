using UnityEngine.Events;
using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// 入力を読み取るマネージャーコンポーネント
/// シーンをまたいでも存在するsingletonクラス
/// </summary>
public class InputManager : MonoBehaviour
{
    SniperGameInputAction _inputActions;

    //外部に公開するイベント一覧
    public Action OnAnyButtonDownEvent;

    public Action<Vector2> OnMoveButtonDownEvent;
    public Action OnFireButtonDownEvent;
    public Action OnAimButttonDownEvent;

    void Awake()
    {
        _inputActions = new SniperGameInputAction();
        _inputActions.Enable();

        //ここからイベント登録
        //_inputActions.UI.AnyButtonDown.performed += context => { OnAnyButtonDownEvent.Invoke(); };

        _inputActions.Player.Move.performed += context => { OnMoveButtonDownEvent.Invoke(context.ReadValue<Vector2>()); };
        _inputActions.Player.Fire.performed += context => { OnFireButtonDownEvent.Invoke(); };
        _inputActions.Player.Aim.performed += context => { OnAimButttonDownEvent.Invoke(); };
    }
}
