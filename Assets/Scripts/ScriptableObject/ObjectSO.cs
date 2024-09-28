using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu()]
public class ObjectSO : ScriptableObject
{
    public Sprite objectIcon;
    public Transform objectPrefab;
    public string objectName;
    public ObjectType objectType;
    public enum ObjectType
    {
        Bed,
        Electronics,
        Chair,
        Table
    }
    public int objectID;
    public bool isUnlocked;

}
