using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// �v���C���[�̓��͂ɂ��s�����s���R���|�[�l���g
/// 
/// �@�\
/// �E�ˌ�
/// �E
/// </summary>
public class PlayerAction : MonoBehaviour
{
    [SerializeField] InputManager _inputManager;
    [SerializeField] GameObject _holdItem;

    private void Awake()
    {
        _inputManager.OnFireButttonDownEvent += () => Use();
    }

    /// <summary>
    /// ��Ɏ����Ă���A�C�e�����g�p����
    /// </summary>
    void Use()
    {
        if (!_holdItem) return;
        _holdItem?.GetComponent<IUse>().Use();
    }

}
