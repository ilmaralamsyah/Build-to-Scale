using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField] private GameObject fireVFX;

    private void Start()
    {
        fireVFX.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Candle"))
        {
            fireVFX.SetActive(true);
        }
    }
}
