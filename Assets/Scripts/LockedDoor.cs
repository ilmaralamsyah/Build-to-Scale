using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    private void OnMouseDown()
    {
        AudioManager.Instance.PlayDoorLockSFX();
    }
}
