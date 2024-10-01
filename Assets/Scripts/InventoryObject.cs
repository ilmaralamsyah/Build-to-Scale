using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryObject : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Transform inventoryObject;

    private InventoryCategory inventoryCategory;

    private void Awake()
    {
        inventoryCategory = GetComponentInParent<InventoryCategory>();
        inventoryObject.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        inventoryCategory.OnCategoryClicked(inventoryObject);
    }

    public Transform GetInventoryObject()
    {
        return inventoryObject;
    }
}
