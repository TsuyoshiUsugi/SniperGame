using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI�̕\�����Ǘ�����
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
