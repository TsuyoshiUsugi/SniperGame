using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 入力を読み取るマネージャーコンポーネント
/// シーンをまたいでも存在するsingletonクラス
/// </summary>
public class InputManager : SingletonMonobehavior<InputManager>
{
    SniperGameInputAction _testInputActions;


    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);

        _testInputActions = new SniperGameInputAction();
        _testInputActions.Enable();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
