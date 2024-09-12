using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{

    [SerializeField] private bool isPickable;
    [SerializeField] private bool isScalable;

    private void Start()
    {
        isPickable = TryGetComponent<PickableObject>(out PickableObject pickableObject);
        isScalable = TryGetComponent<ScalableObject>(out ScalableObject scalableObject);
    }


    protected virtual void OnMouseEnter()
    {
        if (PickableObject.isHoldingObject) { return; }
        UpdateCursor();
    }

    protected virtual void OnMouseExit()
    {
        if (PickableObject.isHoldingObject) { return; }
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
        else
        {
            CursorManager.Instance.SetDefaultCursor();
        }
    }

}
