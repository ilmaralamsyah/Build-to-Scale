using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {

        shakerFeel = GetComponent<MMRotationShaker>();

        shakerFeel.ShakeSpeed = shakeSpeed;
        shakerFeel.ShakeRange = shakeRange;
    }

    private void OnMouseEnter()
    {
        shakerFeel.Play();
    }

    public Vector3 GetScaleFeel()
    {
        return new Vector3(scaleFeel, scaleFeel, scaleFeel);
    }

    public Vector3 GetScaleDumpling()
    {
        return new Vector3(scaleDumpling, scaleDumpling, scaleDumpling);
    }
}
