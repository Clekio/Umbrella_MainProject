using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spr_Caja : MonoBehaviour
{
    public GameObject caja;

    void OnCollisionEnter2D(Collision2D suelo)
    {
        if (suelo.gameObject.tag == "Obstacle")
        {
            Debug.Log("rgesafd");
        }
          //  Destroy(caja, 3);
    }
}