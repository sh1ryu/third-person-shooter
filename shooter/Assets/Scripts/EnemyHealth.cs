using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float Value = 100;

    public void DealDamage(float damage)
    {
        Value -= damage;
        if (Value <= 0)
        {
            Destroy(gameObject);
        }
    }
}
