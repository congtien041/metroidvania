using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverMenu; // Kéo thả Panel Game Over vào đây
    public Text deathReasonText; // Kéo thả Text hiển thị nguyên nhân vào đây

    void Start()
    {
        if(gameOverMenu) gameOverMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameOverMenu.activeSelf)
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            Time.timeScale = pauseMenu.activeSelf ? 0 : 1;
        }
    }

    public void ShowGameOver(string reason)
    {
        if (gameOverMenu != null)
        {
            gameOverMenu.SetActive(true);
            if (deathReasonText != null)
            {
                deathReasonText.text = reason; // Nó sẽ hiện "Killed by Trap" hoặc "Enemy"
            }
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void loadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
