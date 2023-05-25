using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeReference]
    GameObject platformPrefab;
    [SerializeField]
    int platformCount = 10;
    [SerializeField]
    float rangeX = 2.3f;
    [SerializeField]
    float minY = 0.3f;
    [SerializeField]
    float maxY = 2.5f;
    [SerializeReference]
    GameObject resetPos;
    Vector3 spawnPosition = new(0f, -4f, 0f);
    BoxCollider2D boxCollider2D;
    float maxSpawn;

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        SpawnPlateforms(platformCount);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpawnPlateforms(platformCount);
            gameObject.transform.position = resetPos.transform.position;
        }
    }

    void SpawnPlateforms(int count)
    {
        maxSpawn = boxCollider2D.bounds.max.y;
        for (int i = 0; i < count; i++)
        {
            if (maxSpawn >= spawnPosition.y)
            {
                spawnPosition.y += Random.Range(minY, maxY);
                spawnPosition.x = Random.Range(-rangeX, rangeX);
                Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
