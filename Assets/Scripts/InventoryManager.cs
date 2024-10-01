using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    
    public static InventoryManager Instance;

    public Dictionary<ObjectSO.ObjectType, List<ObjectSO>> objectCategories = new Dictionary<ObjectSO.ObjectType, List<ObjectSO>>();

    public List<ObjectSO> objects = new List<ObjectSO>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            // Initialize dictionary with empty lists
            foreach (ObjectSO.ObjectType objectType in System.Enum.GetValues(typeof(ObjectSO.ObjectType)))
            {
                objectCategories[objectType] = new List<ObjectSO>();
            }

            // Add all items to their corresponding categories at the start of the game
            InitializeInventory();
        }
        else
        {
            Destroy(gameObject);
        }

        
    }

    private void InitializeInventory()
    {
        foreach (ObjectSO objectSO in objects)
        {
            AddItem(objectSO);
        }
    }

    public void AddItem(ObjectSO objectSO)
    {
        if (objectCategories.ContainsKey(objectSO.objectType))
        {
            objectCategories[objectSO.objectType].Add(objectSO);
        }
    }

    public List<ObjectSO> GetItemsByCategory(ObjectSO.ObjectType objectType)
    {
        if (objectCategories.ContainsKey(objectType))
        {
            return objectCategories[objectType];
        }
        return null;
    }
}
