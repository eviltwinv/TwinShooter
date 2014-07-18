using UnityEngine;
using System.Collections;

public class Mover_Two : MonoBehaviour {
	
	public float speed;
	
	void Start()
	{
		Vector3 forward = Vector3.forward;
		forward.x += 0.5f;
		rigidbody.velocity =  forward * speed;
	}
}
