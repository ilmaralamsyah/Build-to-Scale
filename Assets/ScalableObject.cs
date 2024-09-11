using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;


[RequireComponent(typeof(MMSpringScale))]
public class ScalableObject : BaseObject
{
    [Header("Scale Controller")]
    [SerializeField] private float scaleSpeed = 5f;
    [SerializeField] private float maxScale = 0.5f;
    [SerializeField] private float minScale = 2f;

    [Header("Item Reposition After Scale")]
    [SerializeField] private float xReposition;
    [SerializeField] private float yReposition;
    [SerializeField] private float zReposition;



    private MMSpringScale scalerFeel;



    private void Start()
    {
        isScalable = true;
        isPickable = false;

        scalerFeel = GetComponent<MMSpringScale>();
    }

    private void OnMouseOver()
    {
        HandleScaleObject();
    }

    protected override void OnMouseDown()
    {
        
    }

    private void HandleScaleObject()
    {
        Debug.Log(IsHoldingObject());
        if (IsHoldingObject()) { return; }
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");


        if (scrollInput != 0)
        {
            Debug.Log(scrollInput);
            // Calculate the new scale
            //AudioManager.Instance.PlayScaleSFX();
            //HasLight(scrollInput);
            Vector3 oldScale = this.transform.localScale;
            Vector3 newScale = oldScale + Vector3.one * scrollInput * scaleSpeed;

            // Clamp the new scale to be within the minimum and maximum limits

            newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
            newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);
            newScale.z = Mathf.Clamp(newScale.z, minScale, maxScale);

            // Apply the new scale
            this.transform.localScale = newScale;
            scalerFeel.MoveTo(newScale);

            // Calculate the difference in scale and adjust position to keep y at 0
            Vector3 scaleDifference = newScale - oldScale;
            Vector3 newPosition = this.transform.position;
            newPosition.x -= scaleDifference.x * xReposition; // Adjust based on scale change
            newPosition.y -= scaleDifference.y * yReposition; // Adjust based on scale change
            newPosition.z -= scaleDifference.z * zReposition; // Adjust based on scale change

            // Apply the corrected position
            this.transform.position = newPosition;

        }
    }
}
