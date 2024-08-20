using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    [SerializeField] private Transform pivotObject;
    [SerializeField] private float rotationSpeed = 5f;
    /*[SerializeField] private Texture2D cameraCursor;*/

    private Vector2 cursorHotspot;

    private void Start()
    {
        /*cursorHotspot = new Vector2(cameraCursor.width / 2, cameraCursor.height / 2);*/
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {

            /*Cursor.SetCursor(cameraCursor, cursorHotspot, CursorMode.Auto);*/

            RotateCamera();
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
