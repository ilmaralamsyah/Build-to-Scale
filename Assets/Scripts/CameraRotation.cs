using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    [SerializeField] private Transform currentPivotObject;
    [SerializeField] private Transform[] pivotObjectArray;
    [SerializeField] private float rotationSpeed = 5f;

    private Vector3 offset;
    private int index = 0;
    private Vector3 startPos;
    private Quaternion startRotation;
    private CameraFeedback cameraFeedback;

    private void Awake()
    {
        cameraFeedback = GetComponent<CameraFeedback>();
    }

    private void Start()
    {
        offset = transform.position - currentPivotObject.position;
        startPos = transform.position;
        startRotation = transform.rotation;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            RotateCamera();
        }


        if (Input.GetKeyDown(KeyCode.K))
        {
            index = (index + 1) % pivotObjectArray.Length;
            currentPivotObject = pivotObjectArray[index];
            ResetTransform();
            transform.position = currentPivotObject.position + offset;
            cameraFeedback.MoveTo(transform.position);
            RenewTransform();
        }
    }

    private void ResetTransform()
    {
        transform.position = startPos;
        transform.rotation = startRotation;
    }

    private void RenewTransform()
    {
        startPos = transform.position;
        startRotation = transform.rotation;
    }

    private void RotateCamera()
    {
        float horizontalInput = Input.GetAxis("Mouse X");
        if (horizontalInput != 0)
        {
            transform.RotateAround(currentPivotObject.position, Vector3.up, horizontalInput * rotationSpeed);
        }
    }
}
