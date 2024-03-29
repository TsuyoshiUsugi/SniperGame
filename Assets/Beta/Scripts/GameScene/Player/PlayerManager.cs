using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの動きを管理するコンポーネント
/// </summary>
public class PlayerManager : MonoBehaviour
{
    [SerializeField] float _hp = 100;
    GameSceneManager _gameSceneManager;
    PlayerCamControlManager _playerCamControlManager;
    PlayerAction _playerAction;
    InputManager _inputManager;

    private void Start()
    {
        _inputManager = FindObjectOfType<InputManager>();
        _gameSceneManager = FindObjectOfType<GameSceneManager>();
        _playerCamControlManager = FindObjectOfType<PlayerCamControlManager>();
        _playerAction = FindObjectOfType<PlayerAction>();
    }

    public void Hit(float dmg)
    {
        _hp -= dmg;

        Death();
    }

    private void Death()
    {
        if (_hp <= 0)
        {
            _gameSceneManager.Failed();
            StopPlayerInput();
            

            GetComponentInChildren<Animator>().SetBool("Die", true);
            var playerIK = GetComponentsInChildren<IIKOff>();
            foreach (var ik in playerIK)
            {
                ik.OffIk();
                gameObject.AddComponent<Rigidbody>();
            }

            this.enabled = false;
        }
    }

    public void StopPlayerInput()
    {

        _playerCamControlManager.enabled = false;
    }
}
