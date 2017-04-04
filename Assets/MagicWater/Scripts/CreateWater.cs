using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWater : MonoBehaviour {

	public GameObject Particler;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Debug.Log ("ButtonDown");
			Particler.SetActive (true);
		}
		if (Input.GetButtonUp ("Fire1")) {
			Debug.Log ("ButtonUp");
			Particler.SetActive (false);
		}

		Particler.transform.position = Input.mousePosition;
			
		
	}
}
