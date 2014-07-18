using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

	public float tumble;

	void Start ()
	{
		rigidbody.angularVelocity = Random.insideUnitSphere * Random.Range (1, tumble);
	}
}
