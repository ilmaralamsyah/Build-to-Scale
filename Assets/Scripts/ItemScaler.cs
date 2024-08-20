using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEditor.EventSystems;
using System;

public class ItemScaler : MonoBehaviour
{
    public static ItemScaler Instance;

    [SerializeField] private LayerMask itemLayerMask;

    [SerializeField] private Item item;

    [SerializeField] private float scaleSpeed;
    [SerializeField] private float maxScale;
    [SerializeField] private float minScale;

    [SerializeField] private Texture2D scaleCursor;
    [SerializeField] private Texture2D pickCursor;

    private Vector2 cursorHotspot;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        cursorHotspot = new Vector2(scaleCursor.width / 2, scaleCursor.height / 2);
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
                if (this.item.IsScalable())
                {
                    Cursor.SetCursor(scaleCursor, cursorHotspot, CursorMode.Auto);
                }
                else if (this.item.IsPickable())
                {
                    Cursor.SetCursor(pickCursor, cursorHotspot, CursorMode.Auto);
                }

            }
        }
        else
        {
            if (item != null)
            {
                //item.GetComponent<Rigidbody>().isKinematic = true;
            }
            this.item = null;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

    private void ScaleItem()
    {
        if (this.item != null && item.IsScalable())
        {
            //item.GetComponent<Rigidbody>().isKinematic = false;

            float scrollInput = Input.GetAxis("Mouse ScrollWheel");


            if (scrollInput != 0)
            {
                // Calculate the new scale
                AudioManager.Instance.PlayScaleSFX();
                HasLight(scrollInput);
                Vector3 oldScale = this.item.transform.localScale;
                Vector3 newScale = oldScale + Vector3.one * scrollInput * scaleSpeed;

                // Clamp the new scale to be within the minimum and maximum limits

                float minScale = item.GetMinScale();
                float maxScale = item.GetMaxScale();

                newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
                newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);
                newScale.z = Mathf.Clamp(newScale.z, minScale, maxScale);

                // Apply the new scale
                this.item.transform.localScale = newScale;

                // Calculate the difference in scale and adjust position to keep y at 0
                Vector3 scaleDifference = newScale - oldScale;
                Vector3 newPosition = this.item.transform.position;
                newPosition.x -= scaleDifference.x * item.GetRepositionValue().x; // Adjust based on scale change
                newPosition.y -= scaleDifference.y * item.GetRepositionValue().y; // Adjust based on scale change
                newPosition.z -= scaleDifference.z * item.GetRepositionValue().z; // Adjust based on scale change

                // Apply the corrected position
                this.item.transform.position = newPosition;
            }
        }
    }

    private void HasLight(float scrollInput)
    {
        if (item.TryGetComponent<LightController>(out LightController lightController))
        {
            if (scrollInput > 0f)
            {
                lightController.LightUp();
            }
            else if (scrollInput < 0f)
            {
                lightController.LightDown();
            }
        }
    }
}
