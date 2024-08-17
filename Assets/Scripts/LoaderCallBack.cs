using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallBack : MonoBehaviour
{
    public bool isFirstFrameLoaded = true;


    private void Update()
    {
        if (isFirstFrameLoaded)
        {
            isFirstFrameLoaded = false;
            Loader.LoaderCallBack();
        }
    }


}