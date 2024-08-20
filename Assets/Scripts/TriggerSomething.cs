using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSomething : MonoBehaviour
{
    public static event Action onSwitchTriggered;

    private void OnMouseDown()
    {
        onSwitchTriggered?.Invoke();
        Destroy(gameObject);
    }
}
