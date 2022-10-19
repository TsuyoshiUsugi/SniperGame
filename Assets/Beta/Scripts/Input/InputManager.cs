using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���͂�ǂݎ��}�l�[�W���[�R���|�[�l���g
/// �V�[�����܂����ł����݂���singleton�N���X
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

        //��������C�x���g�o�^
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
    /// �����ꂩ�̃{�^���������ꂽ�Ƃ��ɍs��
    /// </summary>
    void OnAnyButtonDown()
    {
        Debug.Log("�{�^���������ꂽ");
    }
}
