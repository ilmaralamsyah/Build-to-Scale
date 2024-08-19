using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoor : MonoBehaviour
{
    [SerializeField] private LayerMask doorLayerMask;

    [SerializeField] private bool isUnlocked = false;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ProceedtoNextLevel();
        }
    }

    public void SetUnlock(bool isUnlocked)
    {
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
                Loader.Load(Loader.Scene.GameScene);
            }
            else
            {
                //play audio locked door
            }

        }
    }
}
