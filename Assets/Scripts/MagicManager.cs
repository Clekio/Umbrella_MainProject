using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicManager : MonoBehaviour {

	bool waterfall;
	bool wind;
	bool swirl;

    public string magicName;

	bool waterGrowing;

	public GameObject waterBall;
	public GameObject viento1;
	public GameObject remol1;
	public Camera camera;

	public Texture2D cursorTextureVie;
	public Texture2D cursorTextureRaf;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

	public float maxWaterSize = 0.9f;
	public float growSpeed = 0.01f;
	GameObject bola;

	float waterGravity;
	Transform waterTransform;
    private Gestures scr_gestos;

	// Use this for initialization
	void Start () {
		ResetOption ();
		if (!camera) {
			camera = Camera.main;
		}

		waterGrowing = false;
		waterGravity = waterBall.GetComponent<Rigidbody2D> ().gravityScale;

        scr_gestos = GetComponent<Gestures>();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z - Camera.main.transform.position.z));//new Vector3(Input.mousePosition.x, Input.mousePosition.y, 21));

        if (Input.GetMouseButtonDown(1))
        {
            if (magicName == "waterfall")
            {
                bola = Instantiate(waterBall, new Vector3(p.x, p.y, 0), Quaternion.identity);
                waterTransform = bola.GetComponent<Transform>();
                bola.GetComponent<Rigidbody2D>().gravityScale = 0;
                waterGrowing = true;
            }
            else if (magicName == "wind")
            {
                Cursor.SetCursor(cursorTextureVie, hotSpot, cursorMode);
                Instantiate(viento1, new Vector3(p.x, p.y, 0), Quaternion.identity);
                Cursor.SetCursor(null, Vector2.zero, cursorMode);
                ResetOption();
            }
            else if (magicName == "swirl")
            {
                Cursor.SetCursor(cursorTextureRaf, hotSpot, cursorMode);
                Instantiate(remol1, new Vector3(p.x, p.y, 0), Quaternion.identity);
                Cursor.SetCursor(null, Vector2.zero, cursorMode);
                ResetOption();
            }
            else if (magicName == "thunder")
            {
                //magia thunder
            }
        }
        else if (Input.GetMouseButtonUp(1) && magicName == "waterfall")
        {
            if (magicName == "waterfall")
            {
                waterGrowing = false;
                bola.GetComponent<Rigidbody2D>().gravityScale = waterGravity;
                ResetOption();
            }
            else if (magicName == "wind")
            {

            }
            
        }

        //if (magicName == "waterfall")
        //{
        //    if (Input.GetMouseButtonDown(1))
        //    {
        //        bola = Instantiate(waterBall, new Vector3(p.x, p.y, 0), Quaternion.identity);
        //        waterTransform = bola.GetComponent<Transform>();
        //        bola.GetComponent<Rigidbody2D>().gravityScale = 0;
        //        waterGrowing = true;
        //    }
        //    if (Input.GetMouseButtonUp(1))
        //    {
        //        waterGrowing = false;
        //        bola.GetComponent<Rigidbody2D>().gravityScale = waterGravity;
        //        ResetOption();
        //    }
        //}

        //if (magicName == "wind")
        //{
        //    if (Input.GetMouseButtonDown(1))
        //    {
        //        Cursor.SetCursor(cursorTextureVie, hotSpot, cursorMode);
        //        Instantiate(viento1, new Vector3(p.x, p.y, 0), Quaternion.identity);
        //        Cursor.SetCursor(null, Vector2.zero, cursorMode);
        //        ResetOption();
        //    }
        //}

        //if (magicName == "swirl")
        //{

        //    if (Input.GetMouseButtonDown(1))
        //    {
        //        Cursor.SetCursor(cursorTextureRaf, hotSpot, cursorMode);
        //        Instantiate(remol1, new Vector3(p.x, p.y, 0), Quaternion.identity);
        //        Cursor.SetCursor(null, Vector2.zero, cursorMode);
        //        ResetOption();
        //    }
        //}

        if (Input.GetKeyDown ("1")) {
			ActivateWaterfall ();
		}
        else if (Input.GetKeyDown ("2")) {
			ActivateWind ();
		}
        else if (Input.GetKeyDown ("3")) {
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
        magicName = null;
	}

	void ActivateWaterfall (){
        magicName = "waterfall";

    }

	void ActivateWind (){
        magicName = "wind";
    }

	void ActivateSwirl (){
        magicName = "swirl";
    }
}
