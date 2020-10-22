using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public Rigidbody player;
	public float restartDelay = 2f;
	public GameObject completeLevelUI;

	bool gameHasEnded = false;

	public void WinGame()
	{
		Debug.Log("LEVEL COMPLETE");
		Invoke("Delay", 0.1f);
		completeLevelUI.SetActive(true);
	}

	public void EndGame()
	{
		if(!(gameHasEnded))
		{
			gameHasEnded=true;
			Debug.Log("GAME OVER");
			Invoke("Delay", 0.1f);
			//player.constraints= RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
			Invoke("Restart",restartDelay);
			//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	void Delay()
	{
		player.constraints= RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
	}
	void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
