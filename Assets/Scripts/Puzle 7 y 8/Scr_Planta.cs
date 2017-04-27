using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Planta : MonoBehaviour
{
    public GameObject generarObjeto;
    public Vector3 spawn = new Vector3(112, 21, 0);

    void Start()
    {
        Instantiate(generarObjeto, spawn, Quaternion.identity);
    }
}