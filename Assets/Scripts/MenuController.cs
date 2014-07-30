using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public AudioSource[] audioSource;
	private int shotAudioIndex = 0;

	// Use this for initialization
	void Start () {
		audioSource[shotAudioIndex].Play();
	}
	

}
