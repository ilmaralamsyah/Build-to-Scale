using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{

    protected bool isScalable = false;
    protected bool isPickable = false;
    protected bool isInteractable = false;

    protected virtual void OnMouseEnter()
    {
        UpdateCursor();
    }

    protected virtual void OnMouseExit()
    {
        CursorManager.Instance.SetDefaultCursor();
    }

    protected void UpdateCursor()
    {
        if (isPickable && isScalable)
        {
            CursorManager.Instance.SetScaleAndPickCursor();
        }
        else if (isScalable)
        {
            CursorManager.Instance.SetScaleCursor();
        }
        else if (isPickable)
        {
            CursorManager.Instance.SetPickCursor();
        }
        else if (isInteractable)
        {
            CursorManager.Instance.SetInteractCursor();
        }
        else
        {
            CursorManager.Instance.SetDefaultCursor();
        }
    }
}
