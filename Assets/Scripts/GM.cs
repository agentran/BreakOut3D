using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {

	public int lives = 3; //lives of the player
	public int bricks = 36; //number of currect bricks
	public float resetDelay = 1f; // time after reset
	public Text livesText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject CubePrefabs;
	public GameObject Paddle;
	public GameObject deathParticles;
	public static GM instance = null; //GM can be used in all of the other scripts because it is static

	private GameObject clonePaddle;

	// Use this for initialization
	void Awake () 
	{
		if (instance == null) //if we dont have a game manager yet, we use this to define this as a game manager
			instance = this;
		else if (instance != this) //if we have another game manager, then this code will destroy it
			Destroy (gameObject);

		Setup();

	}

	public void Setup()
	{
		clonePaddle = Instantiate(Paddle, transform.position, Quaternion.identity * Quaternion.AngleAxis(90 , Vector3.forward)) as GameObject;
		Instantiate(CubePrefabs, transform.position = new Vector3(1f, 5f, 0f), Quaternion.identity);
	}

	void CheckGameOver()
	{
		if (bricks < 1) //winning condition
		{
			youWon.SetActive(true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay); //call a function(Reset) with a delay(resetDelay)
		}

		if (lives < 1) //losing Condition
		{
			gameOver.SetActive(true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}

	}

	void Reset()
	{
		Time.timeScale = 1f;
		Application.LoadLevel(Application.loadedLevel); //its gonna load the same scene after the game is finished
	}

	public void LoseLife()
	{
		lives--;
		livesText.text = "Lives: " + lives;
		Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity* Quaternion.AngleAxis(90 , Vector3.forward)); //show the particals at the position of the paddle(death)
		Destroy(clonePaddle); //destroy the paddle
		Invoke ("SetupPaddle", resetDelay); //Reset the paddle again
		CheckGameOver(); //check if the game is lost
	}

	void SetupPaddle()
	{
		clonePaddle = Instantiate(Paddle, transform.position, Quaternion.identity* Quaternion.AngleAxis(90 , Vector3.forward)) as GameObject;
	}

	public void DestroyBrick()
	{
		bricks--;
		CheckGameOver();//check if game is won
	}
}