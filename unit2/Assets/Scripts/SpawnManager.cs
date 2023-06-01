using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public int animalIndex;
    private float spawnRangeX = 20.0f;
    public float time = 2;
    public float repeatRate = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", 2, 1);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], new Vector3(-10, 0, (Random.Range(-spawnRangeX, spawnRangeX))),
        animalPrefabs[animalIndex].transform.rotation);
    }
}



