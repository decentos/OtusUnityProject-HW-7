using System.Collections;
using System.Collections.Generic;
using Meta;
using UnityEngine;

public class Health : MonoBehaviour
{
    [HideInInspector]
    public float currentHealth;
    [SerializeField]
    private CharacterMeta meta;
    
    private void Start()
    {
        currentHealth = meta.Health;
    }

    public void ApplyDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0.0f)
            currentHealth = 0.0f;
    }
}
