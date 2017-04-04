using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicManager : MonoBehaviour {

	bool waterfall;
	bool wind;
	bool swirl;

	public GameObject Particler;
	public GameObject viento1;
	public GameObject remol1;
	public Camera camera;

	public Texture2D cursorTextureVie;
	public Texture2D cursorTextureRaf;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

	GameObject waterSource;

	// Use this for initialization
	void Start () {
		ResetOption ();
		if (!camera) {
			camera = Camera.main;
		}
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 p = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 15));
		
		if (waterfall) {
			if (Input.GetButtonDown ("Fire1")) {
				waterSource = Instantiate (Particler, new Vector3 (p.x, p.y, 0), Quaternion.identity);
			}
			if (Input.GetButtonUp ("Fire1")) {
				Destroy (waterSource);
				ResetOption ();
			}
		}
			
		if (wind) {
			if (Input.GetButtonDown ("Fire1")) {
				Cursor.SetCursor (cursorTextureVie, hotSpot, cursorMode);
				Instantiate (viento1, new Vector3 (p.x, p.y, 0), Quaternion.identity);
				Cursor.SetCursor (null, Vector2.zero, cursorMode);
				ResetOption ();
			}
		}

		if (swirl) {
			if (Input.GetButtonDown ("Fire1")) {
				Cursor.SetCursor (cursorTextureRaf, hotSpot, cursorMode);
				Instantiate (remol1, new Vector3 (p.x, p.y, 0), Quaternion.identity);
				Cursor.SetCursor (null, Vector2.zero, cursorMode);
				ResetOption ();
			}

		}

		if (Input.GetKeyDown ("1")) {
			ActivateWaterfall ();
		}

		if (Input.GetKeyDown ("2")) {
			ActivateWind ();
		}

		if (Input.GetKeyDown ("3")) {
			ActivateSwirl ();
		}

	}

	void ResetOption (){
		waterfall = false;
		wind = false;
		swirl = false;
	}

	void ActivateWaterfall (){
		waterfall = true;
		wind = false;
		swirl = false;
	}

	void ActivateWind (){
		waterfall = false;
		wind = true;
		swirl = false;
	}

	void ActivateSwirl (){
		waterfall = false;
		wind = false;
		swirl = true;
	}
}
