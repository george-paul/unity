using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float spawnInterval=1;

	private float time = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

	void Update()
	{
		time+=Time.deltaTime;
		if (time>spawnInterval)
		{
			SpawnRandomBall();
		}
	}

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
		time=0;
		spawnInterval=Random.Range(2,6);

		Debug.Log(spawnInterval);

        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
		int randBall = Random.Range(0, ballPrefabs.Length);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[randBall], spawnPos, ballPrefabs[randBall].transform.rotation);
    }

}
