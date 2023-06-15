using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float spawnRate = 1.5f;
    [SerializeField] private float heightOffset = 3f;

    private float timer = 0f;

    private void Start()
    {
        SpawnPipe();
    }

    private void Update()
    {
        if (timer > spawnRate)
        {
            SpawnPipe();
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }

    }

    private void SpawnPipe()
    {
        float lowestPossibleSpawn = transform.position.y - heightOffset;
        float highestPossibleSpawn = transform.position.y + heightOffset;

        Instantiate(pipePrefab, new Vector3(transform.position.x, Random.Range(lowestPossibleSpawn, highestPossibleSpawn), transform.position.z), Quaternion.identity);
    }
}
