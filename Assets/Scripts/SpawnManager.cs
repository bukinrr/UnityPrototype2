using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    private Vector3 rotaion = new Vector3(0, 90, 0);
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnRangeZ = 20;
    private float spawnPosZ = 20;
    private float spawnPosX = 20;
    private float startDelay = 2;
    private float spawnInterval = 1;
    private int angle = 90;

    void Start()
    {
        InvokeRepeating("SpawmRandomAnimal", startDelay, spawnInterval);
    }

    void Update()
    {
    }

    void SpawmRandomAnimal()
    {
        Vector3[] arrayAxis =
        {
            new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ),
            new Vector3(spawnPosX, 0, Random.Range(-spawnRangeZ, spawnRangeZ / 2)),
            new Vector3(-spawnPosX, 0, Random.Range(-spawnRangeZ, spawnRangeZ / 2))
        };
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        int arrayAxisIndex = Random.Range(0, arrayAxis.Length);
        if (arrayAxisIndex == 0)
        {
            Instantiate(animalPrefabs[animalIndex], arrayAxis[arrayAxisIndex],
                animalPrefabs[animalIndex].transform.rotation);
        }
        else if (arrayAxisIndex == 1)
        {
            Instantiate(animalPrefabs[animalIndex], arrayAxis[arrayAxisIndex], Quaternion.Euler(-rotaion));
        }
        else
        {
            Instantiate(animalPrefabs[animalIndex], arrayAxis[arrayAxisIndex], Quaternion.Euler(rotaion));
        }
    }
}