using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoor2 : MonoBehaviour
{
    [SerializeField] private LayerMask doorLayerMask;

    [SerializeField] private bool isUnlocked = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ProceedtoNextLevel();
        }
    }

    public void SetUnlock(bool isUnlocked)
    {
        Debug.Log("aa");
        this.isUnlocked = isUnlocked;
    }

    private void ProceedtoNextLevel()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, doorLayerMask))
        {
            if (isUnlocked)
            {
                //play audio opening door
                Loader.Load(Loader.Scene.Level2);
            }
            else
            {
                //play audio locked door
            }

        }
    }
}
