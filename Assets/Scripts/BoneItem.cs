using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneItem : MonoBehaviour
{
    public event Action onKeyRetrieved;

    [SerializeField] private Transform hiddenBone;
    [SerializeField] private Transform hiddenCandle;


    private void Start()
    {
        hiddenBone.gameObject.SetActive(false);
        hiddenCandle.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        hiddenBone.gameObject.SetActive(true);
        hiddenCandle.gameObject.SetActive(true);
        onKeyRetrieved?.Invoke();
        Destroy(gameObject);
    }
}
