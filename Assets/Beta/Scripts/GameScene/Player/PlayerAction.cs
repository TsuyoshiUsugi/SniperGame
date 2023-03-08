using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// プレイヤーの入力による行動を行うコンポーネント
/// 
/// 機能
/// ・射撃
/// ・
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
    /// 手に持っているアイテムを使用する
    /// </summary>
    void Use()
    {
        if (!_holdItem) return;
        _holdItem?.GetComponent<IUse>().Use();
    }

}
