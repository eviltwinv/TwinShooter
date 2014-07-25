using UnityEngine;
using System.Collections;

public class GingerController : MonoBehaviour {
	
	public float speed;
	public float health;
	private bool mainLoop = false;
	private float t = 0.0f;
	private GameObject mainCamera = null;
	private CameraController cMover;
	public AudioSource [] audioSource;
	private bool laughed = false;
	public GameObject player;
	public GameObject leftEye;
	public GameObject rightEye;
	
	void TheStart(Vector3 direction)
	{
		rigidbody.velocity = direction * speed;
		cMover = mainCamera.GetComponent<CameraController>();
		cMover.setTarget(gameObject);
		cMover.ZoomIn (0.5f, 15f);
		invincible = true;

		//get a reference to the game controller
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
		if(mainLoop)
		{
			float deltaX = (2 * Mathf.Cos ( t ));
			float deltaZ = (2 * Mathf.Sin ( t*2 ));
			rigidbody.velocity = new Vector3(deltaX, 0, deltaZ) * 6;
			t += 180 * Mathf.Deg2Rad * Time.deltaTime;
		} else
		{
			if(transform.position.z < 9)
			{
				rigidbody.velocity = Vector3.zero;
				if (!laughed)
				{
					audioSource[0].Play();
					laughed = true;
				}
				if( audioSource[0].isPlaying == false && laughed )
				{
					cMover.returnHome();
					mainLoop = true;
					invincible = false;
					leftEye.GetComponent<GingerEyeController>().toggleWeaponsFree();
					rightEye.GetComponent<GingerEyeController>().toggleWeaponsFree();
				}
			}
		}
	}

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;
	public bool invincible = false;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Boundary" || other.tag == "GingerBolt" || invincible) 
		{
			return;
		}
		if (other.tag == "Player") {
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}
		Destroy(other.gameObject);

		ProjectileTemplate pt = other.gameObject.GetComponent<ProjectileTemplate>();
		if(pt != null){
			audioSource[1].Play();
			health -= pt.damage;
			checkHealth ();
		}
	}
	
	void checkHealth()
	{
		if(health < 0.0)
		{
			Instantiate(explosion, transform.position, transform.rotation);
			gameController.AddScore (scoreValue);
			Destroy(gameObject);
		}
	}

	public void setCamera(GameObject myCamera)
		{
			mainCamera = myCamera;
		}
}
