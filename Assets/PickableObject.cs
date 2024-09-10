using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : BaseObject
{

    [SerializeField] private LayerMask layerMask;
    private int pickUpLayer = 9;
    private int originalLayer;

    private bool isPickedUp = false;
    private Vector3 yOffset = Vector3.up;

    private Rigidbody rb;

    void Start()
    {
        isPickable = true;
        isScalable = false;
        this.gameObject.layer = originalLayer;
        rb = GetComponent<Rigidbody>();
    }


    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, layerMask))
        {
            isPickedUp = true;
            this.gameObject.layer = pickUpLayer;
            rb.isKinematic = true;
        }
    }

    private void OnMouseUp()
    {
        if (isPickedUp)
        {
            this.gameObject.layer = originalLayer;  // Kembalikan layer asli saat dilepas
            isPickedUp = false;
            rb.isKinematic = false;
        }
    }

    private void OnMouseDrag()
    {
        if (isPickedUp)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, layerMask))
            {
                this.transform.position = raycastHit.point + yOffset;
            }
        }
    }
}
