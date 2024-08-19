using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private Transform secretDoor;
    [SerializeField] private KeyItem key;

    private bool basementTriggered = false;
    private bool secretDoorTriggered = false;

    void Start()
    {
        LightController.onReveal += LightController_onEventTriggered;
        LightController.onHide += LightController_onHide;
        key.onPickedUpKey += Key_onPickedUpKey;
        secretDoor.gameObject.SetActive(false);
    }

   
    private void Key_onPickedUpKey()
    {
        secretDoor.GetComponent<SecretDoor>().SetUnlock(true);
    }

    private void LightController_onHide()
    {
        secretDoor.gameObject.SetActive(false);
    }

    private void LightController_onEventTriggered()
    {
        secretDoor.gameObject.SetActive(true);
    }



}
