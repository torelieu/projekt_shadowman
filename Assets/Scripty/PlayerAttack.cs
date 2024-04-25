using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackarea = default;
    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;


    private void Start()
    {
        attackarea = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack) 
            {
                timer = 0f;
                attacking = false;
                attackarea.SetActive(attacking);
            }
        }
    }

    private void Attack()
    {
        attacking = true;
        attackarea.SetActive(true);
    }
}
