using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 入力を読み取るマネージャーコンポーネント
/// シーンをまたいでも存在するsingletonクラス
/// </summary>
public class InputManager : SingletonMonobehavior<InputManager>
{
    SniperGameInputAction _inputActions;


    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);

        _inputActions = new SniperGameInputAction();
        _inputActions.Enable();

        //ここからイベント登録
        _inputActions.UI.AnyButtonDown.performed += context => OnAnyButtonDown();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// いずれかのボタンが押されたときに行う
    /// </summary>
    void OnAnyButtonDown()
    {
        Debug.Log("ボタンが押された");
    }
}
