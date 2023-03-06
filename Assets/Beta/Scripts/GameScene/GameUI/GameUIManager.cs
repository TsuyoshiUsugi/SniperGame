using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UIの表示を管理する
/// </summary>
public class GameUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
