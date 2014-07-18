using UnityEngine;
using System.Collections;
using UnityEditor;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public GameObject enemy;
	public GameObject boss_ginger;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GUIText scoreText;
	private int score;
	public GUIText restartText;
	public GUIText gameOverText;
	private bool gameOver;
	private bool restartOK;
	private int hitCounter;
	public GameObject powerUp;
	private Vector3 powerPos;
	public GameObject Player;
	public bool bossActive = false;

	void Start()
	{
		score = 0;
		UpdateScore ();
		gameOver = false;
		restartOK = false;
		restartText.text = "";
		gameOverText.text = "";
		hitCounter = 0;
		StartCoroutine (SpawnWaves ());
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.R) && restartOK)
						Application.LoadLevel (Application.loadedLevel);
	}

	IEnumerator SpawnWaves ()
	{
		while(bossActive == false){
			yield return StartCoroutine (PhaseOne());
			yield return StartCoroutine (PhaseTwo());
			yield return StartCoroutine (BossOne());
		}

	}

	void UpdateScore()
	{
		scoreText.text = "Score " + score;
	}

	public void AddScore(int points)
	{
		score += points;
		UpdateScore ();
	}

	public void GameOver()
	{
		gameOverText.text = "GAME OVER";
		gameOver = true;
	}

	public void HitCounterAdd()
	{
		hitCounter += 1;
	}

	public void HitCounterReset ()
	{
		hitCounter = 0;
	}
	public void setSpawn (Vector3 pos)
	{
		powerPos = pos;
	}

	public void PowerUpCheck ()
	{
		PlayerController pc = Player.GetComponent<PlayerController>();
		if(hitCounter == 10 && pc.poweredUp == false)
		{
			if(powerPos.x >= 8) powerPos.x = 8;
			Instantiate (powerUp, powerPos, Quaternion.identity);
		}
	}

	IEnumerator PhaseOne()
	{
		restartText.text = "Phase 1";
		yield return new WaitForSeconds (startWait);
		for (int i = 0; i < 2; i++) {
			HitCounterReset ();
			for (int j = 0; j < hazardCount; j++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				GameObject go = Instantiate (hazard, spawnPosition, spawnRotation) as GameObject;
				go.SendMessage ("TheStart", transform.forward);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			if (gameOver) {
				restartText.text = "Press 'R' for Restart";
				restartOK = true;
				break;
			}
		}
	}

	IEnumerator PhaseTwo()
	{
		restartText.text = "Phase 2";
		yield return new WaitForSeconds (startWait);
		for (int i = 0; i < 2; i++) {
			HitCounterReset ();
			for (int j = 0; j < hazardCount; j++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = new Quaternion(0,180,0,0);
				GameObject go = Instantiate (enemy, spawnPosition, spawnRotation) as GameObject;
				go.SendMessage ("TheStart", transform.forward);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			if (gameOver) {
				restartText.text = "Press 'R' for Restart";
				restartOK = true;
				break;
			}
		}
	}

	IEnumerator BossOne()
	{
		if (bossActive)
						yield break;
		restartText.text = "Ginger";
		yield return new WaitForSeconds (startWait);
		HitCounterReset ();
		Vector3 spawnPosition = new Vector3 (0, spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = new Quaternion(90f,0f,0f,0f);
		GameObject go = Instantiate(boss_ginger) as GameObject;
		go.SendMessage ("TheStart", transform.forward);
		bossActive = true;
		yield return new WaitForSeconds (spawnWait);
	}
}
