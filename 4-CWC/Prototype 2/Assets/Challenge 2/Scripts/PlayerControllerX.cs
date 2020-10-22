using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
	public float spamDelay = 1.0f;

	private float time = 0;

    // Update is called once per frame
    void Update()
    {
		time += Time.deltaTime;

        // On spacebar press, send dog
        if (Input.GetButton("Fire1") && time>spamDelay)
        {
			time=0;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
