using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject inGameUI;

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

    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
        inGameUI.SetActive(false);
        Time.timeScale = 0f;
    }

    public void HidePauseMenu()
    {
        pauseMenu.SetActive(false);
        inGameUI.SetActive(true);
        Time.timeScale = 1f;
    }

    public void UpdateScore(int score)
    {
        Debug.Log("Score updated: " + score);
    }
}
