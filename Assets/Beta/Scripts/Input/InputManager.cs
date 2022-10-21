using UnityEngine.Events;
using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// 入力を読み取るマネージャーコンポーネント
/// シーンをまたいでも存在するsingletonクラス
/// </summary>
public class InputManager : SingletonMonobehavior<InputManager>
{
    SniperGameInputAction _inputActions;

    //外部に公開するイベント一覧
    public Action OnAnyButtonDownEvent;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);

        _inputActions = new SniperGameInputAction();
        _inputActions.Enable();

        //ここからイベント登録
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
