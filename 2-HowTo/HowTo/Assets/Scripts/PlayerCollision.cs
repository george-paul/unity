using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	public PlayerMovement movement;

	void OnCollisionEnter(Collision collisonInfo)
	{
		if(collisonInfo.collider.tag=="Obstacle")
		{
			movement.enabled = false;
			FindObjectOfType<GameManager>().EndGame();
		}
	}
}
