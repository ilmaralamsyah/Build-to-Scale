using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

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

    public void StartGame()
    {
        // Logika untuk memulai game, seperti memuat level pertama
        LevelManager.Instance.LoadLevel(1);
    }

    public void RestartGame()
    {
        // Logika untuk mengatur ulang permainan
        LevelManager.Instance.ReloadCurrentLevel();
    }

    public void ExitGame()
    {
        // Logika untuk keluar dari permainan
        Application.Quit();
    }
}
