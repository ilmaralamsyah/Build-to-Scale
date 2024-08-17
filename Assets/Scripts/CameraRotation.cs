using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    [SerializeField] private Transform pivotObject; // Objek di tengah yang menjadi poros rotasi
    [SerializeField] private float rotationSpeed = 5f; // Kecepatan rotasi

    private void Update()
    {
        if (Input.GetMouseButton(1)) // Klik kanan dan tahan
        {
            RotateCamera();
        }
    }

    private void RotateCamera()
    {
        float horizontalInput = Input.GetAxis("Mouse X"); // Input horizontal dari mouse
        if (horizontalInput != 0)
        {
            // Rotasi kamera mengelilingi objek pusat
            transform.RotateAround(pivotObject.position, Vector3.up, horizontalInput * rotationSpeed);
        }
    }
}
