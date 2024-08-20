using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectKeyItem : MonoBehaviour
{
    public static DetectKeyItem Instance;

    public event Action onDoorTriggeredAction;

    [SerializeField] private BoneItem key1;
    [SerializeField] private BoneItem key2;
    [SerializeField] private BoneItem key3;
    [SerializeField] private BoneItem key4;

    [SerializeField] private AnimationClip candleAnimation;


    [SerializeField] private List<GameObject> candles = new List<GameObject>();

    private int TotalKey;

    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        TotalKey = 0;

        key1.onKeyRetrieved += Key_onKeyRetrieved;
        key2.onKeyRetrieved += Key_onKeyRetrieved;
        key3.onKeyRetrieved += Key_onKeyRetrieved;
        key4.onKeyRetrieved += Key_onKeyRetrieved;
    }

    private void Key_onKeyRetrieved()
    {
        TotalKey++;
        AudioManager.Instance.PlayPickSFX();
        CheckKey();
    }

    private void CheckKey()
    {
        if(TotalKey >=4)
        {
            DisableAllCandle();
            StartCoroutine(Animate());
        }
    }


    private void DisableAllCandle()
    {
        foreach(GameObject candle in candles)
        {
            candle.SetActive(false);
        }
    }

    IEnumerator Animate()
    {
        yield return new WaitForSeconds(1);
        candles[0].SetActive(true);
        candles[1].SetActive(true);
        AudioManager.Instance.PlayPickSFX();
        AudioManager.Instance.PlayPickSFX();
        yield return new WaitForSeconds(1);
        candles[2].SetActive(true);
        candles[3].SetActive(true);
        AudioManager.Instance.PlayPickSFX();
        AudioManager.Instance.PlayPickSFX();
        yield return new WaitForSeconds(1);
        candles[4].SetActive(true);
        candles[5].SetActive(true);
        AudioManager.Instance.PlayPickSFX();
        AudioManager.Instance.PlayPickSFX();
        yield return new WaitForSeconds(1);
        candles[6].SetActive(true);
        candles[7].SetActive(true);
        AudioManager.Instance.PlayPickSFX();
        AudioManager.Instance.PlayPickSFX();
        yield return new WaitForSeconds(1);
        candles[8].SetActive(true);
        candles[9].SetActive(true);
        AudioManager.Instance.PlayPickSFX();
        AudioManager.Instance.PlayPickSFX();
        yield return new WaitForSeconds(1);
        onDoorTriggeredAction?.Invoke();
        AudioManager.Instance.PlayDoorRevealSFX();

    }
}
