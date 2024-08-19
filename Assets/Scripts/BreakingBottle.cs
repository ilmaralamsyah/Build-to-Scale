using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingBottle : MonoBehaviour
{

    [SerializeField] private Transform key;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            key.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }

}
