using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Menuシーンのスクリプトの仲介コンポーネント
/// </summary>
public class MenuPresenter : MonoBehaviour
{
    [SerializeField] MenuManager _menuManager;
    [SerializeField] MenuButtonInput _menuButtonInput;
    // Start is called before the first frame update
    void Start()
    {
        _menuButtonInput.OnMissionButtonClicked += () => _menuManager.OnClickedMissionButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
