using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession
{
    private int score = 0;
    private int health = 100;
    private int maxHealth = 100;

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int amount)
    {
        if (amount > 0)
        {
            score += amount;
        }
    }

    public int GetHealth()
    {
        return health;
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            health -= damage;
            if (health < 0)
            {
                health = 0;
            }
        }
    }

    public void Heal(int healAmount)
    {
        if (healAmount > 0)
        {
            health += healAmount;
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }
    }
}