using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G�̍s�����Ǘ�����R���|�[�l���g
/// 
/// MEMO
/// �Ƃɂ��������̊Ǘ������̂ݏ���
/// </summary>
public class EnemyMovement : MonoBehaviour, IDeath
{
    [SerializeField] GameSceneManager _gameSceneManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Death()
    {
        _gameSceneManager.Clear();
    }
}
