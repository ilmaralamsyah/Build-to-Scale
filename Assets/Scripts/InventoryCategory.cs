using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryCategory : MonoBehaviour
{
    [SerializeField] private Transform[] inventoryCategoryArray;

    //private InventoryObject[] inventoryObjectArray; 

    private void Awake()
    {
        inventoryCategoryArray = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            inventoryCategoryArray[i] = transform.GetChild(i);
            inventoryCategoryArray[i] = inventoryCategoryArray[i].GetComponent<InventoryObject>().GetInventoryObject();
        }
    }

    public void OnCategoryClicked(Transform clickedCategory)
    {
        // Loop melalui semua category dan hide kecuali yang diklik
        foreach (Transform category in inventoryCategoryArray)
        {
            if (category != clickedCategory)
            {
                category.gameObject.SetActive(false);  // Sembunyikan kategori lain
            }
            else
            {
                category.gameObject.SetActive(true);   // Tampilkan yang diklik (opsional)
            }
        }

        Debug.Log("Category clicked: " + clickedCategory.gameObject.name);
    }
}
