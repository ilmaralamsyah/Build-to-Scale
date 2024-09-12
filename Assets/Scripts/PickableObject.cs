using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour, IPickable
{

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float yHeight = 3f;

    public static bool isHoldingObject = false;
    private int pickUpLayer = 9;
    private int originalLayer;

    private Vector3 yOffset = Vector3.up;

    private Rigidbody rb;


    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.interpolation = RigidbodyInterpolation.Interpolate;

        this.gameObject.layer = originalLayer;

    }

    public void PickUp()
    {
        isHoldingObject = true;
        rb.isKinematic = true;
    }

    public void PutDown()
    {
        isHoldingObject = false;
        rb.isKinematic = false;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void OnMouseDown()
    {
        PickUp();
        CursorManager.Instance.SetHoldingCursor();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, layerMask))
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
            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, layerMask))
            {
                this.transform.position = raycastHit.point + yOffset * yHeight;
            }
        }
    }
}
