using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class ItemScaler : MonoBehaviour
{
    public static ItemScaler Instance;

    [SerializeField] private LayerMask itemLayerMask;

    [SerializeField] private Item item;

    [SerializeField] private float scaleSpeed;
    [SerializeField] private float maxScale;
    [SerializeField] private float minScale;

    [SerializeField] private float reposition;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        DetectItem();
        ScaleItem();
    }

    private void DetectItem()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, itemLayerMask))
        {
            if (raycastHit.transform.TryGetComponent<Item>(out Item detectedItem))
            {
                this.item = detectedItem;
            }
        }
        else
        {
            if(item != null)
            {
                item.GetComponent<Rigidbody>().isKinematic = true;
            }
            this.item = null;
        }        
    }

    private void ScaleItem()
    {
        if (this.item != null && item.IsScalable())
        {
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");
            if (scrollInput != 0)
            {
                // Calculate the new scale
                item.GetComponent<Rigidbody>().isKinematic = false;
                Vector3 oldScale = this.item.transform.localScale;
                Vector3 newScale = oldScale + Vector3.one * scrollInput * scaleSpeed;

                // Clamp the new scale to be within the minimum and maximum limits
                newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
                newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);
                newScale.z = Mathf.Clamp(newScale.z, minScale, maxScale);

                // Apply the new scale
                this.item.transform.localScale = newScale;

                // Calculate the difference in scale and adjust position to keep y at 0
                Vector3 scaleDifference = newScale - oldScale;
                Vector3 newPosition = this.item.transform.position;
                newPosition.y -= scaleDifference.y * reposition; // Adjust based on scale change

                // Apply the corrected position
                this.item.transform.position = newPosition;
            }
        }
    }
}
