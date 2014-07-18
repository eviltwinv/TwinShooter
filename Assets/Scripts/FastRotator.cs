using UnityEngine;
using System.Collections;

public class FastRotator : MonoBehaviour {

	public Vector3 eulerAngleVelocity = new Vector3(0, 100, 0);
	void FixedUpdate() {
		Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
		rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
	}
}
