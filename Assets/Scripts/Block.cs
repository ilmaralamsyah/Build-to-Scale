using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private bool isPickable;
    [SerializeField] private bool isScalable;

    Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        if (isPickable)
        {
            rigidbody.isKinematic = true;
        }
    }

    public bool IsPickable()
    {
        return isPickable;
    }

    public bool IsScalable()
    {
        return isScalable;
    }
}
