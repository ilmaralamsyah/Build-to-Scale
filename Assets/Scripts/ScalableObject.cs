using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;



[RequireComponent (typeof(Feedback))]
public class ScalableObject : MonoBehaviour, IScalable
{
    [Header("Scale Controller")]
    [SerializeField] private float scaleSpeed = 5f;
    [SerializeField] private float maxScale = 2f;
    [SerializeField] private float minScale = 0.5f;
   

    private Rigidbody rb;

    private Feedback feedback;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        feedback = GetComponent<Feedback>();

    }

    private void OnMouseOver()
    {
        HandleScaleObject();
    }

    private void OnMouseExit()
    {
        rb.isKinematic = false;
    }

    public void Scale(float scaleAmount)
    {
        Vector3 newScale = transform.localScale + Vector3.one * scaleAmount * scaleSpeed;
        newScale = Vector3.Max(newScale, Vector3.one * minScale);
        newScale = Vector3.Min(newScale, Vector3.one * maxScale);
        transform.localScale = newScale;
        feedback.PlayScaleFeedback(newScale);
    }

    private void HandleScaleObject()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");


        if (scrollInput != 0 && !PickableObject.isHoldingObject)
        {
            Scale(scrollInput);
        }
    }
}
