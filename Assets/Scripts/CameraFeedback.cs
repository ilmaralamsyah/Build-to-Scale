using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFeedback : MonoBehaviour
{
    private MMSpringPosition positionFeel;

    private void Awake()
    {
        positionFeel = GetComponent<MMSpringPosition>();
    }

    private void Start()
    {
        positionFeel.SpringVector3.SetDamping(Vector3.one);
        positionFeel.SpringVector3.SetFrequency(Vector3.one * 2);
    }

    public void MoveTo(Vector3 target)
    {
        positionFeel.MoveTo(target);
    }
}
