using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Pinchos : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
            Debug.Log("Muerte jugador");
        if (coll.gameObject.tag == "SpawnObject")
            Destroy(Scr_Planta.objetoGenerado, 0.1f);
    }
}