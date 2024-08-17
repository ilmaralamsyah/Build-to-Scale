using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private bool isPickable;
    [SerializeField] private bool isScalable;

    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.isKinematic = true;
        
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
    }
}
