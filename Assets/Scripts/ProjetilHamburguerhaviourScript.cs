using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilHamburguerhaviourScript : MonoBehaviour {

	public float velocidade;
	public float tempoDeVida;

	// Use this for initialization
	void Start () {
		//tempo de vida do hamburguer
		Destroy (gameObject, tempoDeVida);
		//remove o efeito de gravidade do objeto
		GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
		
	}
	
	// Update is called once per frame
	void Update () {
		//move o hamburguer
		transform.Translate(Vector2.right * velocidade * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D c) {
		print ("colidiiu com" + c.gameObject.tag); 
		if (c.gameObject.tag == "Inimigo")
			Destroy (gameObject);
	}
}
