using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    [SerializeField] private LayerMask itemLayerMask;
    [SerializeField] private LayerMask playAreaLayerMask;

    private int pickUpLayer = 9;
    private Item pickedItem;
    private int originalLayer;
    private Vector2 cursorHotspot;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandlePickUpAndDrop();
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (pickedItem != null)
            {
                AudioManager.Instance.PlayDropSFX();
                pickedItem.GetComponent<Rigidbody>().isKinematic = false;
                pickedItem.gameObject.layer = originalLayer;
                pickedItem = null;
            }
        }

        if (pickedItem != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, playAreaLayerMask))
            {
                pickedItem.transform.position = raycastHit.point;
            }
        }
    }

    private void HandlePickUpAndDrop()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, itemLayerMask))
        {
            if (raycastHit.transform.TryGetComponent<Item>(out Item detectedItem))
            {
                if (detectedItem.IsPickable())
                {
                    AudioManager.Instance.PlayPickSFX();
                    pickedItem = detectedItem;
                    originalLayer = pickedItem.gameObject.layer;
                    pickedItem.gameObject.layer = pickUpLayer;
                    pickedItem.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
    }
}
