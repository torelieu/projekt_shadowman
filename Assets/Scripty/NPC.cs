using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Array to store static positions
    public Vector2[] staticPositions;

    // Time interval to change position (in seconds)
    public float positionChangeInterval = 120f; // 2 minutes

    private Vector2 currentTargetPosition;
    private int currentPositionIndex = 0;
    private float timer = 0f;

    void Start()
    {
        // Set initial target position
        currentTargetPosition = staticPositions[currentPositionIndex];
        transform.position = currentTargetPosition;
    }

    void Update()
    {
        // Update timer
        timer += Time.deltaTime;

        // Check if it's time to change position
        if (timer >= positionChangeInterval)
        {
            // Change position
            currentPositionIndex = (currentPositionIndex + 1) % staticPositions.Length;
            currentTargetPosition = staticPositions[currentPositionIndex];
            transform.position = currentTargetPosition;

            // Reset timer
            timer = 0f;
        }
    }
}
