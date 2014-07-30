using UnityEngine;
using System.Collections;

public class TextController : MonoBehaviour {


	public bool isQuitButton = false;

	void OnMouseEnter()
	{
		//change color of text
		renderer.material.color = Color.green;
	}

	void OnMouseExit()
	{
		renderer.material.color = Color.white;
	}

	void OnMouseUp()
	{
		//is this a quit button?
		if (isQuitButton) 
		{
			//quit the game	
			Application.Quit ();
		} 
		else 
		{
			//load the level
			Application.LoadLevel(1);
		}

	}
}
