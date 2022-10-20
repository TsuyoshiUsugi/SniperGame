using UnityEngine;
using UniRx;

/// <summary>
/// 入力を読み取るマネージャーコンポーネント
/// シーンをまたいでも存在するsingletonクラス
/// </summary>
public class InputManager : SingletonMonobehavior<InputManager>
{
    SniperGameInputAction _inputActions;

    private readonly ReactiveProperty<Unit> _anyButtonDown = new();
    public IReadOnlyReactiveProperty<Unit> AnyButtonDown => _anyButtonDown;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);

        _inputActions = new SniperGameInputAction();
        _inputActions.Enable();

        //ここからイベント登録
       // _inputActions.UI.AnyButtonDown.performed += _anyButtonDown(;

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
