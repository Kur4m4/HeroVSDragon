using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilHamburguerhaviourScript : MonoBehaviour {

	public GameObject explosaoPrefab;
	public GameObject armaDirecao;

	public float velocidade;
	public float tempoDeVida;
	public bool direita;

	// Use this for initialization
	void Start () {
		//tempo de vida do hamburguer

		Destroy (gameObject, tempoDeVida);
		//remove o efeito de gravidade do objeto
		GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
		//direita = armaDirecao.GetComponent<PlayerBehaviourScript>().viradoParaDireita;
		//print(direita);
		
	}
	
	// Update is called once per frame
	void Update () {
		//move o hamburguer
		if (PlayerBehaviourScript.viradoParaDireita) {
			transform.Translate (Vector2.right * velocidade * Time.deltaTime);
		} else {
			transform.Translate (Vector2.left * velocidade * Time.deltaTime);
		}
	}

	void OnCollisionEnter2D(Collision2D c) {
		print(c.gameObject.tag);
		if (c.gameObject.tag != "Player")
			Instantiate (explosaoPrefab, transform.position, transform.rotation);
			Destroy (gameObject);
	}
}
