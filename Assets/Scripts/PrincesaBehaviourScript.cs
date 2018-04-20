using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrincesaBehaviourScript : MonoBehaviour {

	public GameObject coracaoPrefab;
	private Animator an;

	// Use this for initialization
	void Start () {
		an = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Animation() {
		an.SetBool ("Pulando", true);
	}

	void OnCollisionEnter2D(Collision2D c) {
		if (c.gameObject.tag == "Player") {
			Animation();
			Instantiate (coracaoPrefab, transform.position, transform.rotation);
			StartCoroutine(Finish());

		}
	}

	IEnumerator Finish(){
			yield return new WaitForSecondsRealtime(3);
			SceneManager.LoadScene ("start");
	}
}
