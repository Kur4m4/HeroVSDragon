using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedirectToSceneScript : MonoBehaviour {

	public string Scene;
	private bool Clicked;

	// Use this for initialization
	void Start () {
		Clicked = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0) && Clicked == false) {
			Clicked = true;
			SceneManager.LoadScene (this.Scene);
		}
	}
}
