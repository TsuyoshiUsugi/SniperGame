using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの入力を読み取り動かすコンポーネント
/// </summary>
public class PlayerMove : MonoBehaviour
{
    [SerializeField] InputManager _inputManager;
    [SerializeField] Rigidbody _rb;

    [SerializeField] float _speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(_inputManager.MoveDir);
    }

    void Move(Vector2 input)
    {
        float horizontal = input.x * _speed;
        float vertical = input.y * _speed;

        _rb.velocity = new Vector3(horizontal, _rb.velocity.y , vertical);
    }
}
