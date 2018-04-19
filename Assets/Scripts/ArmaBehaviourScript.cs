using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaBehaviourScript : MonoBehaviour {

	public GameObject projetilPrefab;
	public float intervalo;

	void Update () {
		
		if (Input.GetKeyDown ("f"))
			//instancia na cena
			Atirar();
			
	}

	public void Atirar () {
		Instantiate (projetilPrefab, transform.position, transform.rotation);
	}
		

//	IEnumerator Start () {
//		//aguarda para executar
//		yield return new WaitForSeconds (intervalo);
//		//instancia na cena
//		Instantiate (projetilPrefab, transform.position, transform.rotation);
//		//metodo chamado toda vez q for executado
//		StartCoroutine(Start());
//	}
}


