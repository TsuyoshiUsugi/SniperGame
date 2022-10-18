using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���͂�ǂݎ��}�l�[�W���[�R���|�[�l���g
/// �V�[�����܂����ł����݂���singleton�N���X
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
