using System;
using UnityEngine;

/// <summary>
/// singletonの基底クラス
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class SingletonMonobehavior<T> : MonoBehaviour where T : MonoBehaviour
{
    static T _instance;
    public static T Instance
    { 
        get
        {
            if (_instance == null)
            {
                Type t = typeof(T);

                _instance = (T)FindObjectOfType(t);
                if(_instance == null)
                {
                    Debug.LogError($"{t} をアタッチしているオブジェクトはありません");
                }
            }
            return _instance;
        }           
    }

    virtual protected void Awake()
    {
        // 他のGameObjectにアタッチされているか調べる.
        // アタッチされている場合は破棄する.
        if (this != Instance)
        {
            Destroy(this);
   
            Debug.LogError(
                typeof(T) +
                " は既に他のGameObjectにアタッチされているため、コンポーネントを破棄しました." +
                " アタッチされているGameObjectは " + Instance.gameObject.name + " です.");
            return;
        }
    }
}
