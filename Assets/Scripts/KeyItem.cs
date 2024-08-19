using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{

    public event Action onPickedUpKey;

    [SerializeField] private LayerMask keyLayerMask;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PickUpKey();
        }
    }


    private void PickUpKey()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, keyLayerMask))
        {
            //play audio pickup key
            onPickedUpKey?.Invoke();
            Destroy(gameObject, 0.2f);
        }
    }
}
