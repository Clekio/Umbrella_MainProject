using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicManager : MonoBehaviour {

	bool waterfall;
	bool wind;
	bool swirl;

	bool waterGrowing;

	public GameObject waterBall;
	public GameObject viento1;
	public GameObject remol1;
	public Camera camera;

	public Texture2D cursorTextureVie;
	public Texture2D cursorTextureRaf;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

	public float maxWaterSize;
	public float growSpeed;
	GameObject bola;

	float waterGravity;
	Transform waterTransform;

	// Use this for initialization
	void Start () {
		ResetOption ();
		if (!camera) {
			camera = Camera.main;
		}

		waterGrowing = false;
		waterGravity = waterBall.GetComponent<Rigidbody2D> ().gravityScale;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 p = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 21));
		
		if (waterfall) {
			if (Input.GetButtonDown ("Fire1")) {
				bola = Instantiate (waterBall, new Vector3 (p.x, p.y, 0), Quaternion.identity);
				waterTransform = bola.GetComponent <Transform> ();
				bola.GetComponent<Rigidbody2D> ().gravityScale = 0;
				waterGrowing = true;
			}
			if (Input.GetButtonUp ("Fire1")) {
				waterGrowing = false;
				bola.GetComponent<Rigidbody2D> ().gravityScale = waterGravity;
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

		if (waterGrowing) {
			if (waterTransform.localScale.x < maxWaterSize) {
				waterTransform.localScale += new Vector3 (growSpeed, growSpeed, 0);
			} else {
				waterTransform.localScale = new Vector3 (maxWaterSize, maxWaterSize, 1);
			}
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
