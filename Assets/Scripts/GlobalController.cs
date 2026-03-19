using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalController : MonoBehaviour
{
    public static GlobalController Instance { get; private set; }

    public GameObject player;
    public string nextScene;
    
    // TỪ KHÓA 'static' GIÚP GIỮ NGUYÊN GIÁ TRỊ KHI QUA SCENE MỚI
    public static int totalScore = 0; 
    public static int totalGold = 0; 
    
    public TextMeshProUGUI scoreTextUI;
    public TextMeshProUGUI goldTextUI; // Thêm UI cho Tiền

    void Awake()
    {
        Instance = this;
    }
    
    private void Start()
    {
        // Cập nhật cả 2 UI ngay khi bắt đầu scene
        UpdateScoreUI();
        UpdateGoldUI();
    }

    // --- XỬ LÝ ĐIỂM (GIẾT QUÁI) ---
    public void AddScore(int amount) 
    {
        totalScore += amount;
        UpdateScoreUI(); 
    }

    private void UpdateScoreUI()
    {
        if (scoreTextUI != null) scoreTextUI.text = "Score: " + totalScore.ToString();
    }

    // --- XỬ LÝ TIỀN (ĂN VÀNG) ---
    public void AddGold(int amount) 
    {
        totalGold += amount;
        UpdateGoldUI(); 
    }

    private void UpdateGoldUI()
    {
        if (goldTextUI != null) goldTextUI.text = "Gold: " + totalGold.ToString();
    }
}