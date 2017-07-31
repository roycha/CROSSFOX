using UnityEngine;
using System.Collections;

public class Movimiento : MonoBehaviour {

	public float velx = 0.1f;
	public float movx;
	public float posicionActual;
	public bool mirandoDerecha;
	public float inputx;
	
	//VARIABLES DE SALTO
	public float fuerzasalto = 100f;
	public Transform pie;
	public float radioPie = 0.08f;
	public LayerMask suelo;
	public bool enSuelo;

	Animator animator;
	
	void awake(){
		
		animator = GetComponent<Animator>(); 
	}
	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {
		float inputx = Input.GetAxis ("Horizontal"); //Almacena movimiento en el eje X
		if (inputx > 0) {

			movx = transform.position.x + (inputx * velx);
			transform.position = new Vector3 (movx, transform.position.y, 0);
			transform.localScale = new Vector3 (1,1,1);
			movx = posicionActual;
			animator.SetFloat ("velx", inputx);
		
		} 
		if (inputx < 0) {
			
			movx = transform.position.x + (inputx * velx);
			transform.position = new Vector3 (movx, transform.position.y, 0);
			transform.localScale = new Vector3 (-1,1,1);
			movx = posicionActual;
			animator.SetFloat ("velx", Mathf.Abs (inputx));
			
		} 
		enSuelo = Physics2D.OverlapCircle (pie.position, radioPie, suelo);
		if (enSuelo && Input.GetKeyDown (KeyCode.Space)) {
		
			GetComponent <Rigidbody2D>().AddForce (new Vector2 (0,fuerzasalto));
		
		}
	}
}
