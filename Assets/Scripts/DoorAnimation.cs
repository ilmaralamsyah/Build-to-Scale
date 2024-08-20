using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    [SerializeField] private AnimationClip dorrAnimation;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        TriggerSomething.onSwitchTriggered += TriggerSomething_onSwitchTriggered;
    }

    private void TriggerSomething_onSwitchTriggered()
    {
        animator.SetTrigger("IsTriggered");
    }

    public void TriggerAnimEvent()
    {
        AudioManager.Instance.PlayDoorRevealSFX();
    }
}
