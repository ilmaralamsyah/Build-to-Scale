using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private bool isPickable;
    [SerializeField] private bool isScalable;

    [SerializeField] private float xReposition;
    [SerializeField] private float yReposition;
    [SerializeField] private float zReposition;

    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.isKinematic = true;
        rigidbody.useGravity = true;
        
    }

    public bool IsPickable()
    {
        return isPickable;
    }

    public bool IsScalable()
    {
        return isScalable;
    }

    private void OnCollisionEnter(Collision collision)
    {
        rigidbody.isKinematic = true;
        rigidbody.useGravity = true;
    }

    public Vector3 GetRepositionValue()
    {
        return new Vector3(xReposition, yReposition, zReposition);
    }
}
