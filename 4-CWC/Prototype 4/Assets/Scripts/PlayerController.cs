﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 5.0f;
	private Rigidbody playerRb;

	private GameObject focalPoint;

	public bool hasPowerup=false;
	private float powerupStrength = 15f;
	public GameObject powerupIndicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
		focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
		playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);

		powerupIndicator.transform.position = transform.position - new Vector3(0,0.5f,0);
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Powerup"))
		{
			Destroy(other.gameObject);
			hasPowerup = true;
			powerupIndicator.SetActive(true);
			StartCoroutine(PowerupCountdownRoutine());
		}
	}

	IEnumerator PowerupCountdownRoutine()
	{
		yield return new WaitForSeconds(5);
		hasPowerup = false;
		powerupIndicator.SetActive(false);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
		{
			Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
			Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
			enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);

			Debug.Log("Collided with " + collision.gameObject.name + " with hasPowerup == " + hasPowerup);
		}
	}
}
