using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabsInAreas : MonoBehaviour
{
    public GameObject[] otherPrefabs;
    public GameObject[] treePrefabs;
    public string spawnZoneTag = "SpawnZone";
    [SerializeField] private int numberOfRocks;
    [SerializeField] private int numberOfTrees;
    private string sortingLayerName = "stromHore"; // Change this to the desired sorting layer

    private int rocksSpawned = 0;
    private int treesSpawned = 0;
    private float minDistance = 1.0f;

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        GameObject[] spawnZones = GameObject.FindGameObjectsWithTag(spawnZoneTag);

        foreach (GameObject zone in spawnZones)
        {
            Collider2D zoneCollider = zone.GetComponent<Collider2D>();

            for (int i = 0; i < numberOfRocks; i++)
            {
                if (rocksSpawned < numberOfRocks)
                {
                    Vector2 randomPoint = GetRandomPointInPolygon(zoneCollider);
                    GameObject rockPrefab = otherPrefabs[Random.Range(0, otherPrefabs.Length)];

                    if (IsFarEnoughFromOtherObjects(randomPoint, minDistance))
                    {
                        GameObject spawnedRock = Instantiate(rockPrefab, randomPoint, Quaternion.identity);
                        SetSortingLayer(spawnedRock, sortingLayerName);
                        rocksSpawned++;
                    }
                }
            }

            for (int i = 0; i < numberOfTrees; i++)
            {
                if (treesSpawned < numberOfTrees)
                {
                    Vector2 randomPoint = GetRandomPointInPolygon(zoneCollider);
                    GameObject treePrefab = treePrefabs[Random.Range(0, treePrefabs.Length)];

                    if (IsFarEnoughFromOtherObjects(randomPoint, minDistance))
                    {
                        GameObject spawnedTree = Instantiate(treePrefab, randomPoint, Quaternion.identity);
                        SetSortingLayer(spawnedTree, sortingLayerName);
                        treesSpawned++;
                    }
                }
            }
        }
    }

    Vector2 GetRandomPointInPolygon(Collider2D polygonCollider)
    {
        Vector2 randomPoint;

        do
        {
            randomPoint = new Vector2(
                Random.Range(polygonCollider.bounds.min.x, polygonCollider.bounds.max.x),
                Random.Range(polygonCollider.bounds.min.y, polygonCollider.bounds.max.y)
            );

        } while (!IsPointInPolygon(randomPoint, polygonCollider));

        return randomPoint;
    }

    bool IsPointInPolygon(Vector2 point, Collider2D polygonCollider)
    {
        RaycastHit2D hit = Physics2D.Raycast(point, Vector2.zero);

        if (hit.collider != null && hit.collider == polygonCollider)
        {
            return true;
        }

        return false;
    }

    bool IsFarEnoughFromOtherObjects(Vector2 point, float minDistance)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(point, minDistance);

        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "SpawnedObject")
            {
                return false;
            }
        }

        return true;
    }

    void SetSortingLayer(GameObject obj, string layerName)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.sortingLayerName = layerName;
        }
    }
}