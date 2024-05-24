using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn; // The object to spawn
    public int numberOfSpawns = 5; // Number of objects to spawn
    public Vector2 spawnAreaSize = new Vector2(5f, 5f); // Size of the spawn area

    // This method is called when another collider enters the trigger zone
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider that entered the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Spawn the specified number of objects
            for (int i = 0; i < numberOfSpawns; i++)
            {
                // Generate a random position within the spawn area
                Vector2 randomPosition = new Vector2(
                    Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                    Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2)
                );

                // Instantiate the object at the random position
                Instantiate(objectToSpawn, (Vector2)transform.position + randomPosition, Quaternion.identity);
            }
        }
    }

    // Draw the spawn area in the editor for visualization
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}
