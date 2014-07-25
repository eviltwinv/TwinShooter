using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject target = null;
	public Vector3 homePosition;
	public Quaternion homeRotation;
	public GameController gameController;
	public Vector3 offset = new Vector3 (0f, 20f, 0f);
	private bool zoomIn = false;
	private float zoomSpeed = 0.0f;
	private float heightDefault = 10f;
	public float distance = 3.0f;
	public float height;

	void Awake()
	{
		height = heightDefault;
		homePosition = camera.transform.position;
		homeRotation = camera.transform.rotation;
		returnHome ();
	}

	void Start()
	{
	}

	public void setTarget(GameObject gObject)
	{
		target = gObject;
	}

	public void ZoomIn (float speed, float toHeight)
	{
		if (target == null)
		{
			Debug.LogError("Attempted to Zoom In to null Target");
			return;
		}
		zoomSpeed = speed;
		height = toHeight;
		Camera.main.transform.LookAt(target.transform.position);
		zoomIn = true;
	}

	public void returnHome()
	{
		zoomIn = false;
		target = GameObject.FindGameObjectWithTag ("Player");
		camera.transform.position = homePosition;
		camera.transform.rotation = homeRotation;
	}

	void Update()
	{
		if(zoomIn)
		{
			Transform cam = Camera.main.transform;
			Vector3 wantedPosition = target.transform.TransformPoint(0, -distance, -height); 
			cam.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * zoomSpeed);
			cam.LookAt(target.transform.position);
		}
	}

} //CameraMover : MonoBehaviour
