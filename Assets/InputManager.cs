using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        HandlePauseMenu();
        HandlePickUp();
        HandleScale();
    }

    private void OnMouseOver()
    {
        
    }

    private static void HandleScale()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            Debug.Log("Mouse scrolled: " + Input.GetAxis("Mouse ScrollWheel"));
        }
    }

    private static void HandlePickUp()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse clicked at: " + Input.mousePosition);
        }
    }

    private static void HandlePauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.Instance.ShowPauseMenu();
        }
    }
}
