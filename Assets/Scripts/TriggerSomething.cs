using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSomething : MonoBehaviour
{
    public static event Action onSwitchTriggered;

    [SerializeField] private LayerMask switchLayerMask;

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
        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, switchLayerMask))
        {
            //play audio pickup key
            onSwitchTriggered?.Invoke();
            Destroy(gameObject);
        }
    }
}
