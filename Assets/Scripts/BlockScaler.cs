using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class BlockScaler : MonoBehaviour
{
    public static BlockScaler Instance;

    [SerializeField] private LayerMask blockWorldLayerMask;

    [SerializeField] private Block block;

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
        DetectBlock();
        ScaleObject();
    }

    private void DetectBlock()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, blockWorldLayerMask))
        {
            if (raycastHit.transform.TryGetComponent<Block>(out Block detectedBlock))
            {
                this.block = detectedBlock;
            }
        }
        else
        {
            this.block = null;
        }        
    }

    private void ScaleObject()
    {
        if (this.block != null && block.IsScalable())
        {
            // Detect mouse scroll input
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");
            if (scrollInput != 0)
            {
                // Calculate the new scale
                Vector3 oldScale = this.block.transform.localScale;
                Vector3 newScale = oldScale + Vector3.one * scrollInput * scaleSpeed;

                // Clamp the new scale to be within the minimum and maximum limits
                newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
                newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);
                newScale.z = Mathf.Clamp(newScale.z, minScale, maxScale);

                // Apply the new scale
                this.block.transform.localScale = newScale;

                // Calculate the difference in scale and adjust position to keep y at 0
                Vector3 scaleDifference = newScale - oldScale;
                Vector3 newPosition = this.block.transform.position;
                newPosition.y -= scaleDifference.y * reposition; // Adjust based on scale change

                // Apply the corrected position
                this.block.transform.position = newPosition;
            }
        }
    }
}
