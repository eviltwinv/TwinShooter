using UnityEngine;
using System.Collections;

public class GingerMover : MonoBehaviour {
	
	public float speed;
	private bool mainLoop = false;
	private float t = 0.0f;
	private GameObject mainCamera = null;
	private CameraMover cMover;
	public AudioSource laugh;
	private bool laughed = false;
	public GameObject player;
	
	void TheStart(Vector3 direction)
	{
		rigidbody.velocity = direction * speed;
		cMover = mainCamera.GetComponent<CameraMover>();
		//cMover.attachTo (gameObject);
		cMover.setTarget(gameObject);
		cMover.ZoomIn (1f, 15f);
		player = GameObject.FindGameObjectWithTag ("Player");
		gameObject.GetComponent<DestroyByContact> ().setInvincible(true);
	}

	void Update()
	{
		if(mainLoop)
		{
			float deltaX = (2 * Mathf.Cos ( t ));
			float deltaZ = (2 * Mathf.Sin ( t*2 ));
			rigidbody.velocity = new Vector3(deltaX, 0, deltaZ) * 6;
			t += 180 * Mathf.Deg2Rad * Time.deltaTime;
		} else
		{
			if(transform.position.z < 9)
			{
				rigidbody.velocity = Vector3.zero;
				if (!laughed)
				{
					laugh.Play();
					laughed = true;
				}
				if( laugh.isPlaying == false && laughed )
				{
					cMover.returnHome();
					mainLoop = true;
					gameObject.GetComponent<DestroyByContact> ().setInvincible(false);
				}
			}
		}
	}

	public void setCamera(GameObject myCamera)
		{
			mainCamera = myCamera;
		}
}
