using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject explosion;
	public int scoreValue;
	private GameController gameController;
	public bool invincible = false;
	public float health;

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

	void Update()
	{
		checkHealth();
	}

	void OnTriggerEnter(Collider other) {

		//To be used in case of cinematics, etc.
		if (invincible) 
		{
			return;
		}

		//Assess damage from player fire
		if (other.tag == "PlayerBolt") 
		{
			ProjectileTemplate pt = other.gameObject.GetComponent<ProjectileTemplate>();
			health -= pt.damage;
			Destroy(other.gameObject);
		}

		//collision with the player is treated as fatal
		if(other.tag == "Player")
		{
			health -= health;
		}
	}

	void checkHealth()
	{
		if(health <= 0.0)
		{
			Instantiate(explosion, transform.position, transform.rotation);
			//for meta powerup purposes
			gameController.HitCounterAdd ();
			//TODO add logic to drop powerups randomly
			gameController.AddScore (scoreValue);
			Destroy(gameObject);
		}
	}

	public void setInvincible (bool isInvincible)
	{
		invincible = isInvincible;
	}
}
