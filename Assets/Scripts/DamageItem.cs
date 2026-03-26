using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageItem
{
    public void Trigger(GameSession gs)
    {
        gs.TakeDamage(20);
    }
}