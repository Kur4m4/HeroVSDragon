using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour {
	
	public GameObject explosaoPrefab;
	private Rigidbody2D rb;
	private Transform tr;
	private Animator an;
	public Transform verificaChao;
	public Transform verificaParede;

	private bool estaNoChao;
	private bool estaNaParede;
	private bool viradoParaDireita;

	public float velocidade;
	public float raioValidaChao;
	public float raioValidaParede;

	public LayerMask solido;

	int vidas;



	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D>();
		tr = GetComponent<Transform>();
		an = GetComponent<Animator>();

		viradoParaDireita = true;
		if (tag == "Mestre")
			vidas = 12;
		else
			vidas = 3;
	}
	
	// Update is called once per frame
	void Update () {
		EnemyMovements ();
		print (tag);


	}

	void AnimationDragon () {

		an.SetBool ("Transformado", true);

	}

	void EnemyMovements() {
		estaNoChao = Physics2D.OverlapCircle (verificaChao.position, raioValidaChao, solido);
		estaNaParede = Physics2D.OverlapCircle (verificaParede.position, raioValidaParede, solido);

		if (!estaNoChao || estaNaParede && viradoParaDireita)
			Flip ();
		else if (!estaNoChao || estaNaParede && !viradoParaDireita)
			Flip ();

		if (estaNoChao && rb.gravityScale == 1) 
			rb.velocity = new Vector2 (velocidade, rb.velocity.y);
	}

	void Flip(){
		viradoParaDireita = !viradoParaDireita;
		tr.localScale = new Vector2 (-tr.localScale.x, tr.localScale.y);

		velocidade *= -1;
	}

	void OnCollisionEnter2D(Collision2D c) {
		if (c.gameObject.tag == "Projetil") {
			vidas--;
			if (tag == "Mestre" && vidas == 10) 
				AnimationDragon ();
			if (vidas == 0)
				
				Destroy (gameObject);
				Instantiate (explosaoPrefab, transform.position, transform.rotation);

		}
			
	}

	IEnumerator UsingYield(int seconds)
	{
		yield return new WaitForSeconds(seconds);
	} 

	void OnDrawGizmosSelected() {

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (verificaChao.position, raioValidaChao);
		Gizmos.DrawWireSphere (verificaParede.position, raioValidaParede);

	}
}
