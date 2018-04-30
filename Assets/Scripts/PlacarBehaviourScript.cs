using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlacarBehaviourScript : MonoBehaviour {

	public Text txtVidas;
	public Text txtHamburguer;
	public static int vidas;
	public static int hamburguer;

	// Use this for initialization
	void Start () {
		vidas = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if (vidas <= 0) {
			vidas = 0;
			txtVidas.text = vidas.ToString ();
		} else {
			txtVidas.text = vidas.ToString ();
		}

		txtHamburguer.text = hamburguer.ToString ();

	}
}
