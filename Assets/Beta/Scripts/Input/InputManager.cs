using UnityEngine;
using UniRx;

/// <summary>
/// ���͂�ǂݎ��}�l�[�W���[�R���|�[�l���g
/// �V�[�����܂����ł����݂���singleton�N���X
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

        //��������C�x���g�o�^
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
    /// �����ꂩ�̃{�^���������ꂽ�Ƃ��ɍs��
    /// </summary>
    void OnAnyButtonDown()
    {
        Debug.Log("�{�^���������ꂽ");
    }
}
