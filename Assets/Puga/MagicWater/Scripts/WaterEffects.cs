using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEffects : MonoBehaviour {

	public bool barro;
	public bool planta;
	public bool fuego;
	public bool seta;

	public float plantSpeed;
	public float mushroomForce;
	public float jumpMultiplier = 1.5f;

	public Transform plantPosition;

	bool plantActivated;
	bool setaActivated;

	// Use this for initialization
	void Start () {
		plantActivated = false;
		setaActivated = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (plantActivated) {
			if (transform.position != plantPosition.position) {
				transform.position = Vector2.MoveTowards (transform.position, plantPosition.position, plantSpeed);
			} else {
				plantActivated = false;
			}
		}
		
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "Water") {
//			if (col.GetComponent <DynamicParticle> ().currentState == col.GetComponent <DynamicParticle> ().STATES.WATER) {
				ApplyEffect ();
//			}
		}

		if (col.tag == "Player" && setaActivated) {
			col.GetComponent<Rigidbody2D>().AddForce (transform.up*mushroomForce*jumpMultiplier, ForceMode2D.Impulse);
			Debug.Log ("jump");
			setaActivated = false;
		}
	}

	void ApplyEffect (){
		if (barro) {
			EfectoBarro ();
		}
		if (planta) {
			EfectoPlanta ();
		}
		if (fuego) {
			EfectoFuego ();
		}
		if (seta) {
			EfectoSeta ();
		}
	}

	void EfectoBarro (){
		gameObject.GetComponent <Renderer> ().material.color = Color.grey;
	}
	void EfectoPlanta (){
		gameObject.GetComponent <Renderer> ().material.color = Color.green;
		plantActivated = true;
	}
	void EfectoFuego (){
		gameObject.GetComponent <Renderer> ().material.color = Color.yellow;
	}
	void EfectoSeta (){
		gameObject.GetComponent <Renderer> ().material.color = Color.magenta;
		setaActivated = true;
	}

}
