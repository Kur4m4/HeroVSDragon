using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaBehaviourScript : MonoBehaviour {

	public GameObject projetilPrefab;
	public float intervalo;

	void Update () {
		
		if (Input.GetKeyDown ("f"))
			//instancia na cena
				StartCoroutine(Lancar());
			
	}

	IEnumerator Lancar()
	{
			yield return new WaitForSecondsRealtime(0.1f);
			Instantiate (projetilPrefab, transform.position, transform.rotation);
	}
}


