using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private bool isCollected = false;
    private GameSession gameSession;

    void Start()
    {
        gameSession = new GameSession(); // For testing, create a new instance
    }

    public void Collect()
    {
        if (!isCollected)
        {
            gameSession.AddToScore(100);
            isCollected = true;
            // In real game, destroy the object
            Destroy(gameObject);
        }
    }

    public bool IsCollected()
    {
        return isCollected;
    }
}