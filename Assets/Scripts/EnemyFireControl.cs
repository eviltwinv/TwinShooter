using UnityEngine;
using System.Collections;

public class EnemyFireControl : MonoBehaviour {

	public GameObject enemyShot;
	public Transform shotSpawn;
	public float fireRate = 0.5f;
	public float nextFire = 0.0f;
	public AudioSource[] audioSource;
	private int shotAudioIndex;

	// Use this for initialization
	void Start () 
	{
		shotAudioIndex = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 shotDirection = (Vector3.back);
		if (Time.time >= nextFire) 
		{
			nextFire = Time.time + fireRate;
			GameObject go = Instantiate (enemyShot, shotSpawn.position, shotSpawn.rotation) as GameObject;
			go.SendMessage ("TheStart", shotDirection);
			audioSource[shotAudioIndex].Play();
		} //if
	} //Update
} //EnemyFireControl
