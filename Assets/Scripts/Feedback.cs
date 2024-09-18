using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MMSpringScale))]
[RequireComponent(typeof(MMRotationShaker))]
public class Feedback : MonoBehaviour
{
    [Header("Scaling Feedback")]
    [SerializeField] private float scaleFeel = 2f;
    [SerializeField] private float scaleDumpling = 0.5f;

    [Header("Shake Feedback")]
    [SerializeField] private float shakeSpeed = 20f;
    [SerializeField] private float shakeRange = 10f;


    private MMRotationShaker shakerFeel;
    private MMSpringScale scalerFeel;

    private void Start()
    {

        shakerFeel = GetComponent<MMRotationShaker>();
        scalerFeel = GetComponent<MMSpringScale>();

        shakerFeel.ShakeSpeed = shakeSpeed;
        shakerFeel.ShakeRange = shakeRange;
        

        scalerFeel.SpringVector3.SetFrequency(GetScaleFeel());
        scalerFeel.SpringVector3.SetDamping(GetScaleDumpling());
    }

    private void OnMouseEnter()
    {
        if (PickableObject.isHoldingObject) return;
        shakerFeel.Play();
    }

    private Vector3 GetScaleFeel()
    {
        return new Vector3(scaleFeel, scaleFeel, scaleFeel);
    }

    private Vector3 GetScaleDumpling()
    {
        return new Vector3(scaleDumpling, scaleDumpling, scaleDumpling);
    }

    public void PlayScaleFeedback(Vector3 scaleTo)
    {
        scalerFeel.MoveTo(scaleTo);
    }
}
