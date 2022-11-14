using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void OnApplicationFocus(bool hasFocus)
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
