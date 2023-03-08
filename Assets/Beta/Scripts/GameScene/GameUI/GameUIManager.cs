using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UIÇÃï\é¶Çä«óùÇ∑ÇÈ
/// </summary>
public class GameUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LockCursor();
    }

    public void LockCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void UnlockCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
