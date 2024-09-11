using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{

    protected bool isScalable = false;
    protected bool isPickable = false;
    protected bool isInteractable = false;

    private static bool isHoldingObject;

    protected virtual void OnMouseEnter()
    {
        if (isHoldingObject) { return; }
        UpdateCursor();
    }

    protected virtual void OnMouseDown()
    {
        CursorManager.Instance.SetHoldingCursor();
    }

    protected virtual void OnMouseUp()
    {
        CursorManager.Instance.SetDefaultCursor();
    }

    protected virtual void OnMouseExit()
    {
        if(isHoldingObject) { return; }
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

    public bool IsHoldingObject()
    {
        return isHoldingObject;
    }

    public void SetHodlingObject()
    {
        isHoldingObject = true;
    }

    public void ReleaseObject()
    {
        isHoldingObject = false;
    }

}
