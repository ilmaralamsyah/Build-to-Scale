using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPicker : MonoBehaviour
{
    [SerializeField] private LayerMask blockWorldLayerMask;
    [SerializeField] private LayerMask playAreaLayerMask; // Layer mask untuk play area

    private Block pickedBlock;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandlePickUpAndDrop();
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (pickedBlock != null)
            {
                pickedBlock.GetComponent<Rigidbody>().isKinematic = false;
                pickedBlock = null;
            }
        }

        if (pickedBlock != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, playAreaLayerMask))
            {
                // Pindahkan objek ke posisi mouse jika raycast menyentuh play area
                pickedBlock.transform.position = raycastHit.point;
            }
        }
    }

    private void HandlePickUpAndDrop()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, blockWorldLayerMask))
        {
            if (raycastHit.transform.TryGetComponent<Block>(out Block detectedBlock))
            {
                if (detectedBlock.IsPickable())
                {
                    pickedBlock = detectedBlock;
                    pickedBlock.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
    }
}
