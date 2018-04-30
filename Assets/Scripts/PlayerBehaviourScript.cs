using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviourScript : MonoBehaviour {

	private Rigidbody2D rb;
	private Transform tr;
	private Animator an;
	public Transform verificaChao;
	public Transform verificaParede;
	public GameObject explosaoPrefab;

	private bool estaAndando;
	private bool estaNoChao;
	private bool estaNaParede;
	private bool estaVivo;
	public bool viradoParaDireita;
	private bool atacandoBool;

	public int vidas;
	public int hamburguers;

	private float axis;
	public float velocidade;
	public float forcaPulo;
	public float raioValidaChao;
	public float raioValidaParede;

	public LayerMask solido;


	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D>();
		tr = GetComponent<Transform>();
		an = GetComponent<Animator>();

		estaVivo = true;
		viradoParaDireita = true;
		atacandoBool = true;
		vidas = 3;
		hamburguers = 3;
	}
	
	// Update is called once per frame
	void Update () {

		estaNoChao = Physics2D.OverlapCircle (verificaChao.position, raioValidaChao, solido);
		estaNaParede = Physics2D.OverlapCircle (verificaParede.position, raioValidaParede, solido);

		if (estaVivo) {

			axis = Input.GetAxisRaw ("Horizontal");

			estaAndando = Mathf.Abs (axis) > 0f;

			if (axis > 0f && !viradoParaDireita)
				Flip ();
			else if (axis < 0f && viradoParaDireita)
				Flip ();

			if (Input.GetButtonDown ("Jump") && estaNoChao)
				rb.AddForce (tr.up * forcaPulo);

			Animation ();
		}

		if (Input.GetKeyDown ("f") && atacandoBool == true)
			Atacando ();

	}

	void FixedUpdate() {

		if (estaAndando && !estaNaParede) {
			if (viradoParaDireita)
				rb.velocity = new Vector2 (velocidade, rb.velocity.y);
			else
				rb.velocity = new Vector2 (-velocidade, rb.velocity.y);
		}
	
	}

	public void Flip() {
		viradoParaDireita = !viradoParaDireita;

		tr.localScale = new Vector2 (-tr.localScale.x, tr.localScale.y);
	}

	void Animation() {
		an.SetBool ("Andando", (estaNoChao && estaAndando));
		an.SetBool ("Pulando", !estaNoChao);
		an.SetFloat ("VelVertical", rb.velocity.y);
		an.SetBool ("Morrendo", vidas == 0);
	}

	void OnCollisionEnter2D(Collision2D c) {
		if (c.gameObject.tag == "Inimigo" || c.gameObject.tag == "Mestre") {
			//StartCoroutine(Invencivel());
			//transform.position = Vector3(0.0f, 0.0f, 0.0f);
			Instantiate (explosaoPrefab, transform.position, transform.rotation);
			transform.position = new Vector3(transform.position.x - 1f, transform.position.y + 1f, transform.position.z);
			vidas--;
			//GetComponent<Collider2D>().enabled = false;
			if (vidas == 0 || c.gameObject.tag == "LimiteInferior") {
				StartCoroutine (Finish ());
			} else {
				PlacarBehaviourScript.vidas--;
			}
		}

		if (c.gameObject.tag == "Hamburguer") {
			hamburguers += 3;
		}

		if (c.gameObject.tag == "LimiteInferior")
			StartCoroutine(Finish());

	}

	void OnDrawGizmosSelected() {

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (verificaChao.position, raioValidaChao);
		Gizmos.DrawWireSphere (verificaParede.position, raioValidaParede);
	
	}

	void Atacando() {
		hamburguers =  hamburguers - 1;
		PlacarBehaviourScript.hamburguer = hamburguers;
		StartCoroutine(Atack());
	}

	IEnumerator Atack()
	{
			an.SetBool ("Atacando", true);
			yield return new WaitForSecondsRealtime(0.2f);
			an.SetBool ("Atacando", false);
	}

	IEnumerator Finish(){
			yield return new WaitForSecondsRealtime(2);
			SceneManager.LoadScene ("start");
	}

	IEnumerator Invencivel() {
		for (int x = 0; x <= 3; x++) {
			yield return new WaitForSeconds (1.0f);
			if (GetComponent<SpriteRenderer>().enabled) {
				GetComponent<SpriteRenderer>().enabled = false;
			} else {
				GetComponent<SpriteRenderer>().enabled = false;
			}
		}
		GetComponent<SpriteRenderer>().enabled = true;
		GetComponent<Collider2D>().enabled = true;
	}

}




