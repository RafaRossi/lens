using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableComponent : MonoBehaviour, IClickable
{
    public Action OnClick = delegate {  };
    
    public void Click()
    {
        OnClick?.Invoke();
    }

    private void OnMouseDown()
    {
        Click();
    }
}
