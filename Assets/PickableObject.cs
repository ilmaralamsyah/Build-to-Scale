using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MMSpringPosition))]
public class PickableObject : BaseObject
{

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float yHeight;
    private int pickUpLayer = 9;
    private int originalLayer;

    private Vector3 yOffset = Vector3.up;
    private MMSpringPosition positionFeel;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        positionFeel = GetComponent<MMSpringPosition>();
        
        isPickable = true;
        isScalable = false;
        this.gameObject.layer = originalLayer;
        rb.freezeRotation = true;
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, layerMask))
        {
            SetHodlingObject();
            this.gameObject.layer = pickUpLayer;
            rb.isKinematic = true;
        }
        
    }

    protected override void OnMouseUp()
    {
        base.OnMouseUp();
        if (IsHoldingObject())
        {
            this.gameObject.layer = originalLayer;  // Kembalikan layer asli saat dilepas
            ReleaseObject();
            rb.isKinematic = false;
        }
    }

    private void OnMouseDrag()
    {
        if (IsHoldingObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, layerMask))
            {
                this.transform.position = raycastHit.point + yOffset * yHeight;
                positionFeel.MoveTo(transform.position);
            }
        }
        Debug.Log(IsHoldingObject());
    }
}
