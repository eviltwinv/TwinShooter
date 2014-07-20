using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {

	private GameController gameController;
	public Vector3 offset;

	void Start()
	{

		if (gameController.bossActive) 
		{
			transform.position += offset;
		} //if
	} //moveCamera
} //CameraMover : MonoBehaviour
