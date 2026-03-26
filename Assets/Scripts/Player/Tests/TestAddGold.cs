using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;using UnityEngine;

public class TestAddGold
{
    [Test]
    // -	Kiểm tra Score ban đầu:
    // +	Kiểm tra Score sau khi cộng thêm 10:
    public void KiemTraScore()
    {
        var gs = new ItemCollectible();
        int score = gs.GetScore();
        Assert.AreEqual(0, score);
    }
}
