using UnityEngine;
using System.Collections;

public class GingerEyeController : MonoBehaviour {

	public GameObject shot;
	public AudioSource shotAudio;
	public float fireRate = 0.5f;
	public float nextFire = 0.0f;
	public bool weaponsFree = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 backward = transform.forward;
		if(weaponsFree && Time.time >= nextFire)
		{
			nextFire = Time.time + fireRate;
			GameObject go = Instantiate (shot, transform.position, transform.rotation) as GameObject;
			go.SendMessage("TheStart", backward);
			shotAudio.Play();
		}
	
	}

	public void toggleWeaponsFree()
	{
		weaponsFree = !weaponsFree;
	}
}
