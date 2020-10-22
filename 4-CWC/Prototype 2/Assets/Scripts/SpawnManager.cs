using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public GameObject[] animalPrefabs;
	public int animalIndex;
	public float spawnRangeX = 18;
	public float spawnPosZ = 30;

	public float startDelay = 2.0f;
	public float spawnInterval = 1.5f;

	void SpawnRandomAnimal()
	{
		Vector3 spawnPos= new Vector3(Random.Range(-spawnRangeX,spawnRangeX), 0, spawnPosZ);
		animalIndex = Random.Range(0, animalPrefabs.Length);
		Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
	}

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
