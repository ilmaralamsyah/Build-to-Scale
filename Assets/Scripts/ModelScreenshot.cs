using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ModelScreenshot : MonoBehaviour
{

    private Camera screenshotCamera; // Assign your camera here
    public GameObject[] models; // Assign your FBX models here
    public string folderPath = "Assets/Screenshots/"; // Folder where screenshots will be saved
    public int imageWidth = 512; 
    public int imageHeight = 512;
    
    private void Start()
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        screenshotCamera = Camera.main;

        StartCoroutine(CaptureModelScreenshots());
    }

    private IEnumerator CaptureModelScreenshots()
    {
        for (int i = 0; i < models.Length; i++)
        {
            // Enable the current model
            models[i].SetActive(true);
            models[i].transform.position = Vector3.zero;
            models[i].transform.rotation = Quaternion.identity;

            // Move camera to fit the model in view (optional)
            CenterCameraOnModel(models[i]);
            // Wait for the model to be fully rendered (optional)
            yield return new WaitForEndOfFrame();
            // Capture the screenshot
            RenderTexture rt = new RenderTexture(imageWidth, imageHeight, 24);
            screenshotCamera.targetTexture = rt;
            Texture2D screenshot = new Texture2D(imageWidth, imageHeight, TextureFormat.RGB24, false);
            screenshotCamera.Render();
            RenderTexture.active = rt;
            screenshot.ReadPixels(new Rect(0, 0, imageWidth, imageHeight), 0, 0);
            screenshot.Apply(); screenshotCamera.targetTexture = null;
            RenderTexture.active = null; Destroy(rt); 
            // Save the screenshot
            byte[] bytes = screenshot.EncodeToPNG();
            File.WriteAllBytes(folderPath + models[i].name + ".png", bytes); 
            // Disable the model before moving to the next one
            models[i].SetActive(false);
        }
        Debug.Log("Screenshots saved in " + folderPath);
    }

    private void CenterCameraOnModel(GameObject model)
    {
        // Optional: Adjust this logic based on how you want the camera to focus on the model
        Bounds bounds = model.GetComponent<Renderer>().bounds;
        Vector3 modelCenter = bounds.center;
        float modelSize = bounds.extents.magnitude;
        screenshotCamera.transform.position = modelCenter - screenshotCamera.transform.forward * modelSize * 2.0f;
        screenshotCamera.transform.LookAt(modelCenter);
    }
}