using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;

	void TheStart(Vector3 direction)
	{
		rigidbody.velocity = direction * speed;
	}
}
