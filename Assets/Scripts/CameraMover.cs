using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {

	public Vector3 homePosition;
	public Quaternion homeRotation;
	public GameController gameController;
	public Vector3 offset;

	void Awake()
	{
		homePosition = camera.transform.position;
		homeRotation = camera.transform.rotation;
	}

	void Start()
	{

		if (gameController.bossActive) 
		{
			transform.position += offset;
		} //if
	} //moveCamera

	public void attachTo (GameObject gObject)
	{
		camera.isOrthoGraphic = false;
		camera.transform.position = new Vector3 (0f, 5f, 9); 
	}

	public void returnHome()
	{
		camera.isOrthoGraphic = true;
		camera.transform.position = homePosition;
		camera.transform.rotation = homeRotation;
	}

} //CameraMover : MonoBehaviour
