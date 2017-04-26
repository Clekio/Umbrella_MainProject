using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEffects : MonoBehaviour {

	public bool barro;
	public bool planta;
	public bool fuego;
	public float speed;

	public Transform plantPosition;

	bool plantActivated;

	// Use this for initialization
	void Start () {
		plantActivated = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (plantActivated) {
			if (transform.position != plantPosition.position) {
				transform.position = Vector2.MoveTowards (transform.position, plantPosition.position, speed);
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

}
