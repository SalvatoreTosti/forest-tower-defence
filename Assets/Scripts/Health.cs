using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;

    public void Damage(int amount)
    {
        currentHealth -= amount;
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    void Update()
    {
        if (IsDead())
        {
            Object.Destroy(gameObject);
        }

    }
}
