using UnityEngine;
using System.Collections;

public class ConsumeOnContact : MonoBehaviour {

	public int powerUpValue;
	private GameController gameController;

	void Start()
	{
		//Getting a reference to the gameController at runtime
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if(gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameController == null)
			Debug.Log ("Cannot find 'gameController' script");
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Boundary" || other.tag == "Asteroid") 
		{
			return;
		}
		if (other.tag == "Player") {
			gameController.AddScore (powerUpValue);
			Destroy (gameObject);
		}
	}
}
