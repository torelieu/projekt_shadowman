using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public int[] stageHp = { 100, 150, 200, 250, 300 };
    [SerializeField]
    private int currentStage = 0;
    [SerializeField]
    private int currentHp;
    public GameObject spikePrefab;
    public Transform spikeSpawnPoint;
    public float floatingSpeed = 3f;
    private Vector3 startPos;
    private bool goingUp = true;
    private int hitCount = 0;
    public float spikeSpeed = 5f;
    public Slider healthBar;
    public Text stageText;

    private Transform player;

    void Start()
    {
        currentHp = stageHp[currentStage];
        startPos = transform.position;
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        // Floating behavior
        if (goingUp)
        {
            transform.position += Vector3.up * floatingSpeed * Time.deltaTime;
            if (transform.position.y >= startPos.y + 3f)
                goingUp = false;
        }
        else
        {
            transform.position += Vector3.down * floatingSpeed * Time.deltaTime;
            if (transform.position.y <= startPos.y - 3f)
                goingUp = true;
        }

        healthBar.value = currentHp;
        stageText.text = "Stage " + currentStage;
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        hitCount++;

        if (currentHp <= 0)
        {
            currentStage++;
            floatingSpeed += 2;
            if (currentStage < stageHp.Length)
            {
                currentHp = stageHp[currentStage];
                healthBar.maxValue = currentHp;
            }
            else
            {
                // Handle boss death
            }
        }

        if (hitCount % 3 == 0)
        {
            ShootSpikes();
        }
        if (hitCount % 5 == 0)
        {
            ShootSpikes();
            ShootSpikes();
        }
    }

    void ShootSpikes()
    {
        GameObject spike = Instantiate(spikePrefab, spikeSpawnPoint.position, Quaternion.identity);
        Vector2 direction = (player.position - spikeSpawnPoint.position).normalized;
        spike.GetComponent<Rigidbody2D>().velocity = direction * spikeSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Orb"))
        {
            TakeDamage(20);
            Destroy(collision.gameObject);
        }
    }
}
