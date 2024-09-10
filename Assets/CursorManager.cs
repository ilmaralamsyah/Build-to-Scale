using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

    public static CursorManager Instance;

    [Header("Cursor Textures")]
    [SerializeField] private Texture2D scaleCursor;
    [SerializeField] private Texture2D pickCursor;
    [SerializeField] private Texture2D interactCursor;
    [SerializeField] private Texture2D scaleAndPickCursor;
    [SerializeField] private Texture2D cameraRotateCursor;

    private Vector2 scaleCursorHotspot;
    private Vector2 pickCursorHotspot;
    private Vector2 interactCursorHotspot;
    private Vector2 scaleAndPickCursorHotspot;
    private Vector2 cameraRotateCursorHotspot;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SetDefaultCursor();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        scaleCursorHotspot = new Vector2(scaleCursor.width / 2, scaleCursor.height / 2);
        pickCursorHotspot = new Vector2(pickCursor.width / 2, pickCursor.height / 2);
        interactCursorHotspot = new Vector2(interactCursor.width / 2, interactCursor.height / 2);
        scaleAndPickCursorHotspot = new Vector2(scaleAndPickCursor.width / 2, scaleAndPickCursor.height / 2);
        cameraRotateCursorHotspot = new Vector2(cameraRotateCursor.width / 2, cameraRotateCursor.height / 2);
    }

    public void SetDefaultCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        Debug.Log("default");
    }

    public void SetScaleCursor()
    {
        Cursor.SetCursor(scaleCursor, scaleCursorHotspot, CursorMode.Auto);
         Debug.Log("scale");
    }

    public void SetPickCursor()
    {
        Cursor.SetCursor(pickCursor, pickCursorHotspot, CursorMode.Auto);
        Debug.Log("pick");
    }

    public void SetInteractCursor()
    {
        Cursor.SetCursor(interactCursor, interactCursorHotspot, CursorMode.Auto);
        Debug.Log("interact");
    }

    public void SetScaleAndPickCursor()
    {
        Cursor.SetCursor(scaleAndPickCursor, scaleAndPickCursorHotspot, CursorMode.Auto);
        Debug.Log("scale pick");
    }

    public void SetCameraRotateCursor()
    {
        Cursor.SetCursor(cameraRotateCursor, cameraRotateCursorHotspot, CursorMode.Auto);
        Debug.Log("camera");
    }
}
