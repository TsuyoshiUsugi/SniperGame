using System;
using UnityEngine;

/// <summary>
/// singleton�̊��N���X
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
                    Debug.LogError($"{t} ���A�^�b�`���Ă���I�u�W�F�N�g�͂���܂���");
                }
            }
            return _instance;
        }           
    }

    virtual protected void Awake()
    {
        // ����GameObject�ɃA�^�b�`����Ă��邩���ׂ�.
        // �A�^�b�`����Ă���ꍇ�͔j������.
        if (this != Instance)
        {
            Destroy(this);
   
            Debug.LogError(
                typeof(T) +
                " �͊��ɑ���GameObject�ɃA�^�b�`����Ă��邽�߁A�R���|�[�l���g��j�����܂���." +
                " �A�^�b�`����Ă���GameObject�� " + Instance.gameObject.name + " �ł�.");
            return;
        }
    }
}
