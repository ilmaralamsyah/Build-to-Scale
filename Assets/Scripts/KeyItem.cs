using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{

    public event Action onPickedUpKey;

    [SerializeField] private LayerMask keyLayerMask;

    private void OnMouseDown()
    {
        AudioManager.Instance.PlayPickSFX();
        onPickedUpKey?.Invoke();
        Destroy(gameObject);
    }

}
