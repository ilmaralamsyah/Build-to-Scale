using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    [SerializeField] private LayerMask itemLayerMask;
    [SerializeField] private LayerMask playAreaLayerMask; // Layer mask untuk play area

    private Item pickedItem;

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
                pickedItem.GetComponent<Rigidbody>().isKinematic = false;
                pickedItem = null;
            }
        }

        if (pickedItem != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, playAreaLayerMask))
            {
                // Pindahkan objek ke posisi mouse jika raycast menyentuh play area
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
                    pickedItem = detectedItem;
                    pickedItem.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
    }
}
