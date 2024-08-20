using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneItem : MonoBehaviour
{
    public event Action onKeyRetrieved;

    [SerializeField] private Transform hiddenBone;
    [SerializeField] private Transform hiddenCandle;

    [SerializeField] private bool triggerByCondition = false;
    [SerializeField] private Transform condition;



    private void Start()
    {
        hiddenBone.gameObject.SetActive(false);
        hiddenCandle.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        if(triggerByCondition == false)
        {
            TriggerCondition();
        } else
        {
            if(condition.localScale.x < 0.5)
            {
                Debug.Log("aa");
                TriggerCondition();
            }
            else
            {
                Debug.Log("bb");
            }
        }
        
    }

    private void TriggerCondition()
    {
        hiddenBone.gameObject.SetActive(true);
        hiddenCandle.gameObject.SetActive(true);
        onKeyRetrieved?.Invoke();
        Destroy(gameObject);
    }
}
