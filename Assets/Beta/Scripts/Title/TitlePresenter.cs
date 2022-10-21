using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TitlePresenter : MonoBehaviour
{
    [SerializeField] InputManager _inputManager;
    [SerializeField] TitleManager _titleManager;
    // Start is called before the first frame update
    void Start()
    {
        _inputManager.OnAnyButtonDownEvent += () =>_titleManager.LoadMenuScene();
    }

}
