using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Awake()
    {
        _inputManager.OnFireButttonDownEvent += () => Shot();
    }

    void Shot()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
