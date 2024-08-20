using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoor2 : MonoBehaviour
{

    [SerializeField] private bool isUnlocked = false;


    public void SetUnlock(bool isUnlocked)
    {
        this.isUnlocked = isUnlocked;
        AudioManager.Instance.PlayDoorUnlockedSFX();
    }

    private void OnMouseDown()
    {
        if (isUnlocked)
        {
            AudioManager.Instance.PlayDoorUnlockedSFX();
            Loader.Load(Loader.Scene.Level2);
        }
        else
        {
            AudioManager.Instance.PlayDoorLockSFX();
        }
    }
}
