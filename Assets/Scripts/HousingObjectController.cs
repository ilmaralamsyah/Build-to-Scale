using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousingObjectController : MonoBehaviour, IPickable
{
    public static bool isHoldingObject = false;
    private int pickUpLayer = 9;
    private int originalLayer = 0;

    public void PickUp()
    {
        isHoldingObject = true;
    }

    public void PutDown()
    {
        isHoldingObject = false;
    }

    private void OnMouseDown()
    {
        PickUp();
        CursorManager.Instance.SetHoldingCursor();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, LayerMaskManager.Instance.GetDraggingLayerMask()))
        {
            this.gameObject.layer = pickUpLayer;
        }
    }

    private void OnMouseUp()
    {
        if (isHoldingObject)
        {
            CursorManager.Instance.SetDefaultCursor();
            this.gameObject.layer = originalLayer;  // Kembalikan layer asli saat dilepas
            PutDown();
        }
    }

    private void OnMouseDrag()
    {
        if (isHoldingObject)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, LayerMaskManager.Instance.GetDraggingLayerMask()))
            {
                this.transform.position = raycastHit.point;
            }
        }
    }
}
