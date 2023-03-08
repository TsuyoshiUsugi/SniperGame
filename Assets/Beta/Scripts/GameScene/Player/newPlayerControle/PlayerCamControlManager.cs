using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCamControlManager : MonoBehaviour
{
    [Header("QÆ")]
    [SerializeField] GameObject _player;
    [SerializeField] InputManager _inputManager;

    [SerializeField] AxisState _rotateX;
    [SerializeField] AxisState _rotateY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();

        Rotate();
    }

    /// <summary>
    /// “ü—Í‚ğ“Ç‚İæ‚é
    /// </summary>
    private void ReadInput()
    {
        
    }

    void Rotate()
    {
        
    }
}
