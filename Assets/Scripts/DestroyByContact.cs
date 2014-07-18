using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if(gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameController == null)
			Debug.Log ("Cannot find 'gameController' script");
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Boundary" || other.tag == "PowerUp") 
		{
			return;
		}
		gameController.HitCounterAdd ();
		gameController.setSpawn (gameObject.transform.position);
		Instantiate (explosion, transform.position, transform.rotation);
		if (other.tag == "Player") {
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
				}
		gameController.PowerUpCheck ();
		gameController.AddScore (scoreValue);
		Destroy(other.gameObject);
		Destroy (gameObject);
	}
}
