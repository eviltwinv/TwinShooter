using UnityEngine;
using System.Collections;

public class GingerMover : MonoBehaviour {
	
	public float speed;
	private bool mainLoop = false;
	private float t = 0.0f;
	
	void TheStart(Vector3 direction)
	{
		rigidbody.velocity = direction * speed;
	}

	void Update()
	{
		if (transform.position.z < 9)
		{
			rigidbody.velocity = Vector3.zero;
			mainLoop = true;
		}
		if(mainLoop)
		{
			float deltaX = (2 * Mathf.Cos ( t ));
			float deltaZ = (2 * Mathf.Sin ( t*2 ));
			rigidbody.velocity = new Vector3(deltaX, 0, deltaZ) * 6;
			t += 180 * Mathf.Deg2Rad * Time.deltaTime;
		}
	}
}
