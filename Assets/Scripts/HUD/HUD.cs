using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [Header("Menus")]
    public GameObject pauseMenu;
    public GameObject gameOverMenu; 

    [Header("Status UI")]
    public Text deathReasonText; 
    public Text scoreText;       // Kéo thả Text hiện điểm vào đây
    public Text goldText;        // MỚI: Kéo thả Text hiện Vàng vào đây
    public Slider rageSlider;    // Kéo thả Slider thanh nộ vào đây

    // MỚI: Biến lưu trữ Player để tối ưu hiệu năng
    private PlayerController playerRef;

    void Start()
    {
        if(gameOverMenu) gameOverMenu.SetActive(false);
        
        // TỐI ƯU: Chỉ tìm Player đúng 1 lần khi bắt đầu game
        playerRef = FindAnyObjectByType<PlayerController>();
        
        // Cấu hình ban đầu cho thanh nộ
        if (rageSlider != null && playerRef != null)
        {
            rageSlider.minValue = 0;
            rageSlider.maxValue = playerRef.maxRage;
            rageSlider.value = 0;
        }
    }

    void Update()
    {
        // 1. Xử lý Pause Game
        if (Input.GetKeyDown(KeyCode.Escape) && !gameOverMenu.activeSelf)
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            Time.timeScale = pauseMenu.activeSelf ? 0 : 1;
        }

        // 2. Cập nhật Điểm số và Vàng từ GlobalController (Đã đổi sang biến static)
        if (scoreText != null)
        {
            scoreText.text = "Score: " + GlobalController.totalScore;
        }
        if (goldText != null)
        {
            goldText.text = "Gold: " + GlobalController.totalGold;
        }

        // 3. Cập nhật Nộ từ Player liên tục (Dùng biến playerRef đã lưu ở Start)
        if (playerRef != null)
        {
            UpdateRage(playerRef.rage);
        }
    }

    // Hàm cập nhật giá trị thanh Nộ
    public void UpdateRage(float currentRage)
    {
        if (rageSlider != null)
        {
            rageSlider.value = currentRage;
        }
    }

    public void ShowGameOver(string reason)
    {
        if (gameOverMenu != null)
        {
            gameOverMenu.SetActive(true);
            if (deathReasonText != null)
            {
                deathReasonText.text = reason; 
            }
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        // TÙY CHỌN: Nếu chết mà muốn chơi lại từ đầu mất hết điểm/vàng thì bỏ comment 2 dòng dưới
        // GlobalController.totalScore = 0;
        // GlobalController.totalGold = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void loadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}