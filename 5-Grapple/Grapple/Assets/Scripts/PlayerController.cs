using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	private Rigidbody2D playerRb;
	//movement
	public float movementSpeed = 3.0f;
	public float translateMovementSpeed = 0.15f;
	//horizontal vel limit
	public float velLimit = 30.0f;
	public Vector2 vel;
	//jump
	public float jumpForce = 2.0f;
	//ground check
	public bool isGrounded = false;
	private BoxCollider2D playerBc;

    void Start()
    {
		playerRb = GetComponent<Rigidbody2D>();
		playerBc = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
		//movement
		// if(Input.GetAxis("Horizontal") != 0 && isGrounded)
		// {
		// 	playerRb.velocity = Vector2.right * Input.GetAxis("Horizontal") * movementSpeed;
		// }
		// else if (isGrounded)
		// {
		// 	playerRb.velocity = new Vector2(0, playerRb.velocity.y);
		// }
		// if(Input.GetButtonDown("Fire1") && isGrounded)
		// {
		// 	playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		// }
		if(Input.GetAxis("Horizontal") != 0 && isGrounded)
		{
			transform.Translate(Vector3.right * translateMovementSpeed * Input.GetAxis("Horizontal"));
		}
		if(Input.GetButtonDown("Fire1") && isGrounded)
		{
			playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
		if(Input.GetButtonDown("Fire1") && Input.GetAxis("Horizontal")>0 && isGrounded)
		{
			playerRb.AddForce(new Vector2(1.73f,1) * jumpForce, ForceMode2D.Impulse);
		}
		if(Input.GetButtonDown("Fire1") && Input.GetAxis("Horizontal")<0 && isGrounded)
		{
			playerRb.AddForce(new Vector2(-1.73f,1) * jumpForce, ForceMode2D.Impulse);
		}
    }

	private void OnCollisionEnter2D(Collision2D other) 
	{
		//ground check
		if(other.gameObject.layer == 8 && other.transform.position.y <= (transform.position.y + playerBc.size.y/2)) // layer 8 is Ground and collision is under player
		{
			isGrounded = true;
		}
	}

	private void OnCollisionExit2D(Collision2D other) 
	{
		//ground check
		if(other.gameObject.layer == 8)
		{
			isGrounded = false;
		}

	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.name == "Pit Sensor")
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}