using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBasement : MonoBehaviour
{
    public static event Action onBasementTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Couch"))
        {
            onBasementTriggered?.Invoke();
        }
    }
}
