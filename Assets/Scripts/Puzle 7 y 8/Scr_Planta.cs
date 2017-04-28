using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Planta : MonoBehaviour
{
    public GameObject generarObjeto;
    public Vector3 spawn = new Vector3(113, 15, 0);

    public static GameObject objetoGenerado;

    void Start()
    {
        InvokeRepeating("spawnObject", 2.0f, 5f);
    }

    void spawnObject()
    {
        objetoGenerado = (GameObject) Instantiate(generarObjeto, spawn, Quaternion.identity);
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.transform.tag == "SpawnObject")
        {
            Destroy(objetoGenerado, 1);
        }
    }
}