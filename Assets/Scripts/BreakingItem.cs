using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingItem : MonoBehaviour
{

    [SerializeField] private Transform key;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            key.gameObject.SetActive(true);
            key.transform.position = this.transform.position;
            Destroy(gameObject);
        }
    }

}
