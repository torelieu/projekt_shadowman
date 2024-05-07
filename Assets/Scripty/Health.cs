using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int health = 100;

    public static int kills;

    private int MAX_HEALTH = 100;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            // Damage(10);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            // Heal(10);
        }
    }

    public void SetHealth(int maxHealth, int health)
    {
        this.MAX_HEALTH = maxHealth;
        this.health = health;
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

        bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;

        if (wouldBeOverMaxHealth)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
    }

    public void Die()
    {
        if (gameObject.tag == "Enemy")
        {
            kills += 1;
            Debug.Log("Killed an enemy");
            Destroy(gameObject);
        }
        
        if (gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
