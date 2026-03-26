using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

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

public class CoinPickup
{
    private bool isCollected = false;
    private bool isDestroyed = false;
    private GameSession gameSession;

    public CoinPickup(GameSession gs)
    {
        gameSession = gs;
    }

    public void Collect()
    {
        if (!isCollected)
        {
            gameSession.AddToScore(100);
            isCollected = true;
            isDestroyed = true; // Simulate destroy
        }
    }

    public bool IsCollected()
    {
        return isCollected;
    }

    public bool IsDestroyed()
    {
        return isDestroyed;
    }
}

public class DamageItem
{
    public void Trigger(GameSession gs)
    {
        gs.TakeDamage(20);
    }
}

public class AddGold
{
    // 1. Test Score
    [Test]
    public void TestScoreInitial()
    {
        var gs = new GameSession();
        int score = gs.GetScore();
        Assert.AreEqual(0, score);
    }

    [Test]
    public void TestScoreAddOnce()
    {
        var gs = new GameSession();
        gs.AddToScore(100);
        int score = gs.GetScore();
        Assert.AreEqual(100, score);
    }

    [Test]
    public void TestScoreAddMultiple()
    {
        var gs = new GameSession();
        gs.AddToScore(100);
        gs.AddToScore(50);
        int score = gs.GetScore();
        Assert.AreEqual(150, score);
    }

    [Test]
    public void TestScoreAddZero()
    {
        var gs = new GameSession();
        gs.AddToScore(0);
        Assert.AreEqual(0, gs.GetScore());
    }

    [Test]
    public void TestScoreAddNegative()
    {
        var gs = new GameSession();
        gs.AddToScore(-100);
        Assert.AreEqual(0, gs.GetScore());
    }

    // 2. Test Item
    [Test]
    public void TestCoinPickupIncreasesScore()
    {
        var gs = new GameSession();
        var coin = new CoinPickup(gs);
        coin.Collect();
        Assert.AreEqual(100, gs.GetScore());
    }

    [Test]
    public void TestTrapDamage()
    {
        var gs = new GameSession();
        var trap = new DamageItem();
        trap.Trigger(gs);
        Assert.AreEqual(80, gs.GetHealth());
    }

    [Test]
    public void TestItemUsedOnce()
    {
        var coin = new CoinPickup(new GameSession());
        coin.Collect();
        coin.Collect();
        Assert.AreEqual(true, coin.IsCollected());
    }

    [Test]
    public void TestItemDestroyed()
    {
        var coin = new CoinPickup(new GameSession());
        coin.Collect();
        // Check if destroyed
        Assert.IsTrue(coin.IsDestroyed());
    }

    [Test]
    public void TestNoTriggerWithoutCollision()
    {
        var gs = new GameSession();
        int start = gs.GetScore();
        // Not calling Collect
        Assert.AreEqual(start, gs.GetScore());
    }

    // 3. Test HP/Life
    [Test]
    public void TestHealthInitial()
    {
        var gs = new GameSession();
        int health = gs.GetHealth();
        Assert.AreEqual(100, health);
    }

    [Test]
    public void TestTakeDamage()
    {
        var gs = new GameSession();
        gs.TakeDamage(20);
        Assert.AreEqual(80, gs.GetHealth());
    }

    [Test]
    public void TestHealthNotNegative()
    {
        var gs = new GameSession();
        gs.TakeDamage(200);
        Assert.AreEqual(0, gs.GetHealth());
    }

    [Test]
    public void TestHeal()
    {
        var gs = new GameSession();
        gs.TakeDamage(50);
        gs.Heal(20);
        Assert.AreEqual(70, gs.GetHealth());
    }

    [Test]
    public void TestHealNotOverMax()
    {
        var gs = new GameSession();
        gs.Heal(200);
        Assert.AreEqual(100, gs.GetHealth());
    }
}
