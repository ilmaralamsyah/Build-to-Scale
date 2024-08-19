using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager2 : MonoBehaviour
{
    [SerializeField] private Transform secretDoor;
    [SerializeField] private KeyItem key;

    void Start()
    {
        key.onPickedUpKey += Key_onPickedUpKey;
    }


    private void Key_onPickedUpKey()
    {
        secretDoor.GetComponent<SecretDoor2>().SetUnlock(true);
    }
}
