using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate = 0.5f;
	public float nextFire = 0.0f;
	public bool poweredUp;
	public AudioSource[] audioSource;
	private int shotAudioIndex;

	void Start()
	{
		poweredUp = false;
		shotAudioIndex = 0;
		Object.DontDestroyOnLoad (transform.gameObject);
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		rigidbody.velocity = (new Vector3 (moveHorizontal, 0.0f, moveVertical) * speed);

		rigidbody.position = new Vector3 
		(
			Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
		);

		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}

	void Update ()
	{
		Vector3 forward = transform.forward;
		if(Input.GetButton("Fire1") && Time.time >= nextFire)
		{
			nextFire = Time.time + fireRate;
			GameObject go = Instantiate (shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
			go.SendMessage("TheStart", forward);

			if(poweredUp)
			{
				shotAudioIndex = 1;
				Vector3 rightShot = Vector3.forward;
				Vector3 leftShot = Vector3.forward;
				rightShot.x += 0.5f;
				go = Instantiate (shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
				go.SendMessage("TheStart", rightShot);
				leftShot.x -= 0.5f;
				go = Instantiate (shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
				go.SendMessage("TheStart", leftShot);
			}
			audioSource[shotAudioIndex].Play();
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if(other.tag == "PowerUp")
		{
			poweredUp = true;
			audioSource[2].Play();
		}
	}
}
