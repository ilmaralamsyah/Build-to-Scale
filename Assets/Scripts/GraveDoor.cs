using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveDoor : MonoBehaviour
{

    private Animator animator;
    private BoxCollider bc;

    private void Start()
    {
        animator = GetComponent<Animator>();
        bc = GetComponent<BoxCollider>();
        bc.enabled = false;
        DetectKeyItem.Instance.onDoorTriggeredAction += Instance_onDoorTriggeredAction;
    }

    private void Instance_onDoorTriggeredAction()
    {
        animator.SetTrigger("Unlocked");
    }

    public void EnableBoxCollider()
    {
        bc.enabled = true;
    }

    private void OnMouseDown()
    {
        Loader.Load(Loader.Scene.FinalScene);
    }
}
