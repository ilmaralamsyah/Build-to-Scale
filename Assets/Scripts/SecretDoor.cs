using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoor : MonoBehaviour
{
    [SerializeField] private LayerMask doorLayerMask;

    [SerializeField] private bool isUnlocked = false;

    private void OnMouseDown()
    {
        if (isUnlocked)
        {
            AudioManager.Instance.PlayDoorUnlockedSFX();
            Loader.Load(Loader.Scene.Level1);
        }
        else
        {
            AudioManager.Instance.PlayDoorLockSFX();
        }
    }

    public void SetUnlock(bool isUnlocked)
    {
        this.isUnlocked = isUnlocked;
        AudioManager.Instance.PlayDoorUnlockedSFX();
    }


}
