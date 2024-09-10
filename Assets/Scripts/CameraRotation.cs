using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    [SerializeField] private Transform pivotObject;
    [SerializeField] private float rotationSpeed = 5f;

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            RotateCamera();
        }

        if (Input.GetMouseButtonDown(1))
        {
            CursorManager.Instance.SetCameraRotateCursor();
        }

        if (Input.GetMouseButtonUp(1))
        {
            CursorManager.Instance.SetDefaultCursor();
        }
    }

    private void RotateCamera()
    {
        float horizontalInput = Input.GetAxis("Mouse X");
        if (horizontalInput != 0)
        {
            transform.RotateAround(pivotObject.position, Vector3.up, horizontalInput * rotationSpeed);
        }
    }
}
