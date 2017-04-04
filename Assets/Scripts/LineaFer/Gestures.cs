﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gestures : MonoBehaviour {

    struct NormalizedGesture {
        public Vector2 originalCenter;
        public float rotation;
        public float size;
        public bool inverted;
        public List<Vector2> gesture;
    }

	struct Gesto
	{
		public List<Vector2> dirList;
		public string Name;
	}
	
	List<Gesto> listaGestos = new List<Gesto>();
	Vector2 lastMousePos;
    Vector2 lastDelta;

	private void Start()
	{
		//Gesto Lazo = new Gesto();
		//Lazo.Name = "Lazo";
		//Lazo.dirList.Add(new Vector2 (0.0f, -1.0f));
		//Lazo.dirList.Add(new Vector2(1.0f, 1.0f));
		//Lazo.dirList.Add(new Vector2(-1.0f, -1.0f));
		//listaGestos.Add(Lazo);
	}

	List<Vector2> currentGesture;

    NormalizedGesture currentNormalized;

    void Update () {

        Vector2 thisDelta = ((Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition) - lastMousePos)/Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            currentGesture = new List<Vector2>();
        }
        if (Input.GetMouseButton(0)) {
            RecordPosition(Camera.main.ScreenToViewportPoint(Input.mousePosition) , thisDelta, lastDelta, currentGesture);
        }
        if (Input.GetMouseButtonUp(0))
        {
            currentGesture = OptimizeGesture(currentGesture);
			currentNormalized = Normalize(currentGesture);

		}
		lastDelta = thisDelta;
        lastMousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        if (currentGesture != null) {
            Vector2 vP = currentGesture[0];
            for(int i = 1; i < currentGesture.Count; i++) {
                if(vP != null)
                    Debug.DrawLine(vP, currentGesture[i], Color.red);
                vP = currentGesture[i];
            }

        }

        if (currentNormalized.gesture != null)
        {
            Vector2 vP = currentNormalized.gesture[0];
            for (int i = 1; i < currentNormalized.gesture.Count; i++)
            {
                if (vP != null)
                    Debug.DrawLine(vP, currentNormalized.gesture[i], Color.green);
                vP = currentNormalized.gesture[i];
            }

        }
    }

    [SerializeField] float distanceMargin = 0.05f;
    [SerializeField] float mouseDeltaNeeded = 0.05f;

    void RecordPosition(Vector2 position, Vector2 thisframeMouseSpeed, Vector2 lastFrameMouseSpeed, List<Vector2> previouspoints) {
        if (previouspoints.Count > 0)
        {
            Vector2 lastpoint = previouspoints[previouspoints.Count - 1];
            if (Vector2.Distance(lastpoint, position) > distanceMargin && (thisframeMouseSpeed - lastFrameMouseSpeed).magnitude < mouseDeltaNeeded) {
                previouspoints.Add(position);
            }
        }
        else {
            previouspoints.Add(position);
        }
    }

    [SerializeField] float minimumAngle = 10;

    List<Vector2> OptimizeGesture(List<Vector2> points) {
        if (points.Count >= 3)
        {
            List<Vector2> optimized = new List<Vector2>();
            optimized.Add(points[0]);
            optimized.Add(points[1]);
            Vector2 vP = points[1] - points[0];
            Vector2 cursor = points[1];
            for (int i = 2; i < points.Count; i++)
            {
                if (Vector2.Angle(vP, points[i] - cursor) > minimumAngle || Vector2.Angle(vP, points[i] - cursor) < -minimumAngle)
                {
                    vP = points[i] - cursor;
                    cursor = points[i];
                    optimized.Add(points[i]);
                }
            }
            return optimized;
        } else {
            return points;
        }
    }

    NormalizedGesture Normalize(List<Vector2> gesture) {
        NormalizedGesture normalized = new NormalizedGesture();
        List<Vector2> normalizedList = new List<Vector2>(gesture);

        //sacamos centro de puntos y normalizamos posición
        Vector2 center = Vector2.zero;
        foreach(Vector2 v in gesture) {
            center += v;
        }
        center = center / ((float)gesture.Count);
        normalized.originalCenter = center;
        Vector2 c = normalizedList[0];
        for (int i = 0; i < normalizedList.Count; i++)
        {
            normalizedList[i] = normalizedList[i] - c;
        }

        //sacamos angulo y normalizamos rotación;
        float angle = Vector2.Angle(gesture[1] - gesture[0], Vector2.up);
        if ((gesture[1] - gesture[0]).x < 0) {
            angle = 360 - angle;
        }
        for (int i = 0; i < normalizedList.Count; i++)
        {
            normalizedList[i] = Rotate(normalizedList[i], angle);
        }
        normalized.rotation = angle;

        //normalized inversion;
        //if ((normalizedList[1] - normalizedList[0]).x < 0)
        //{
        //    for (int i = 0; i < normalizedList.Count; i++)
        //    {
        //        normalizedList[i] = new Vector2(-normalizedList[i].x, normalizedList[i].y);
        //    }
        //    normalized.inverted = true;
        //}
        //else
        //{
        //    normalized.inverted = false;
        //}
		
        normalized.gesture = normalizedList;
        return normalized;
    }

	void Recognition(List<Vector2> pointList)
	{
		string signo = "";
		List<Vector2> directionList = new List<Vector2>();
		List<Vector2> endSigno = new List<Vector2>();
		for (int i = 1; i < pointList.Count; i++)
		{
			Vector2 dir = pointList[i - 1] - pointList[i];
			Vector2 dirBasica;
			
			//Horizontal
			//Up
			if (dir.y < -0.1)
				dirBasica.y = -1;
			else if (dir.y > 0.1)
				dirBasica.y = 1;
			else
				dirBasica.y = 0;

			//Vertical
			if (dir.x < -0.1)
				dirBasica.x = -1;
			else if (dir.x > 0.1)
				dirBasica.x = 1;
			else
				dirBasica.x = 0;

			endSigno.Add(dirBasica);
			Debug.Log(dirBasica);
		}

        Reconocer(endSigno);
        //return signo;
    }
	
	private void Reconocer(List<Vector2> basicpointlist)
	{
		foreach (Gesto agesto in listaGestos)
		{
			Debug.Log(agesto.Name);
		}
	}

	Vector2 Rotate(Vector2 v, float degrees)
    {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }
}
