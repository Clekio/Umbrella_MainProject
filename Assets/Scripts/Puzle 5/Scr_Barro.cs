using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Barro : MonoBehaviour
{
    public Collider2D player;

    void OnTriggerEnter2D(Collider2D player)
    {
        Scr_PlayerVictor.Velocity.x /= 5;
    }
}
