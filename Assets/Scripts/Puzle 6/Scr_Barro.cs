using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Barro : MonoBehaviour
{
    Scr_PlayerVictor player = new Scr_PlayerVictor();

    public Collider2D coll;
    bool enBarro = false;

    public static bool ralentizar = false;
    public static bool agua = false;


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("pene");
            enBarro = true;/*
            Scr_PlayerVictor.CrouchInputValue = true;
            player.CalculateVelocity();*/
        }

        if (coll.gameObject.tag == "Enemy")
        {
            ralentizar = true;
        }

        if (coll.tag == "Water")
        {
            agua = true;
            GetComponent<Renderer>().material.color = Color.black;
        }
    }
    
    void Update()
    {
        if (enBarro == true)
        {

        }
        /*
        if (enBarro == true)
        {
            Scr_PlayerVictor.CrouchInputValue = true;
            player.CalculateVelocity();
        }
        */
    }
}