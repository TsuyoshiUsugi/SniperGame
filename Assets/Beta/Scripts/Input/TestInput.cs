using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour
{
    SniperGameInputAction _testInputActions;

    void Awake()
    {
        _testInputActions = new SniperGameInputAction();
        _testInputActions.Enable();
        _testInputActions.Player.Fire.performed += context => Debug.Log("Fire");
    }

    void Update()
    {
        const float Speed = 1f;

        var direction = _testInputActions.Player.Move.ReadValue<Vector2>();
        transform.Translate(direction * Speed * Time.deltaTime);
    }
}
