using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private ObjectSO objectSO;
    
    private Image icon;

    private bool isDragged = false;
    private Transform inventoryGameObject;

    private int pickUpLayer = 9;
    private int originalLayer;

    private void Awake()
    {
        icon = GetComponent<Image>();
        icon.sprite = objectSO.objectIcon;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragged = true;
        inventoryGameObject = Instantiate(objectSO.objectPrefab, this.transform.position, Quaternion.identity);
        originalLayer = inventoryGameObject.gameObject.layer;
        inventoryGameObject.gameObject.layer = pickUpLayer;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragged = false;
        this.gameObject.layer = originalLayer;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, LayerMaskManager.Instance.GetDraggingLayerMask()))
        {
            Destroy(inventoryGameObject.gameObject);
        }
        
    }

    private void Update()
    {
        if(isDragged)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, LayerMaskManager.Instance.GetDraggingLayerMask()))
            {
                inventoryGameObject.transform.position = raycastHit.point;
            }
        }
    }


}
