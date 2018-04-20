using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosaoBehaviourScript : MonoBehaviour {

	public float intervalo;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, intervalo);
	}
	
}
