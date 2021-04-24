using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public HealthBar healthBar;
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}
