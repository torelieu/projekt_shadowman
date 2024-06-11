using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject orbPrefab;
    public Transform firePoint;
    public float orbSpeed = 30f;
    public float fireRate = 2f;
    public float jumpRate = 3f;
    private float nextJumpRate = 0f;
    private float nextFireTime = 0f;
    public int playerHp = 500;
    public int jumpAmount = 10;
    public Slider healthBar;
    private bool isGrounded = true;
    public GameObject losePanel;

    void Start()
    {
        healthBar.maxValue = playerHp;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
        if (Input.GetMouseButtonDown(1) && isGrounded == true && Time.time > nextJumpRate)
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            nextJumpRate = Time.time + jumpRate;
        }

        healthBar.value = playerHp;
    }

    void Shoot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - firePoint.position).normalized;
        GameObject orb = Instantiate(orbPrefab, firePoint.position, Quaternion.identity);
        orb.GetComponent<Rigidbody2D>().velocity = direction * orbSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            playerHp -= 40;
            if (playerHp <= 0)
            {
                losePanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
