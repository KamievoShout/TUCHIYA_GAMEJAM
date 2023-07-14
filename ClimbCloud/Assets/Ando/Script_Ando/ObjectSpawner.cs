using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectData
{
    public GameObject objectPrefab;
    public float spawnProbability;
}
public class ObjectSpawner : MonoBehaviour
{
    public ObjectData[] objectDataArray;
    public float spawnIntervalMin = 1f;
    public float spawnIntervalMax = 3f;
    public float spawnRangeX = 5f;
    public float spawnHeightIncrement = 1f;

    private float timer;
    private float spawnHeight;
    private float lastSpawnedX;
    private float currentSpawnInterval;

    private void Start()
    {
        spawnHeight = transform.position.y;
        SetRandomSpawnInterval();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= currentSpawnInterval)
        {
            SpawnObject();
            timer = 0f;
            SetRandomSpawnInterval();
        }
    }

    private void SpawnObject()
    {
        float randomX = GetUniqueSpawnX();
        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0f);

        GameObject selectedPrefab = SelectObjectPrefab();
        if (selectedPrefab != null)
        {
            Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
        }

        spawnHeight += spawnHeightIncrement;
        lastSpawnedX = randomX;
    }

    private GameObject SelectObjectPrefab()
    {
        float totalProbability = 0f;
        foreach (ObjectData data in objectDataArray)
        {
            totalProbability += data.spawnProbability;
        }

        float randomValue = Random.value * totalProbability;
        foreach (ObjectData data in objectDataArray)
        {
            if (randomValue < data.spawnProbability)
            {
                return data.objectPrefab;
            }
            randomValue -= data.spawnProbability;
        }

        return null;
    }

    private float GetUniqueSpawnX()
    {
        float randomX;

        do
        {
            randomX = Random.Range(-spawnRangeX, spawnRangeX);
        } while (Mathf.Abs(randomX - lastSpawnedX) < 1f);

        return randomX;
    }

    private void SetRandomSpawnInterval()
    {
        currentSpawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
    }
}
