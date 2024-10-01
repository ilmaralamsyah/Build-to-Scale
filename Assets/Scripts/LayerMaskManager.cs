using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerMaskManager : MonoBehaviour
{
    public static LayerMaskManager Instance;

    [SerializeField] private LayerMask draggingLayerMask;

    private void Awake()
    {
        Instance = this;
    }

    public LayerMask GetDraggingLayerMask()
    {
        return draggingLayerMask;
    }

}
