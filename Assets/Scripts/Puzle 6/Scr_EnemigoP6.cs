using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_EnemigoP6 : MonoBehaviour
{
    public int speed = 6;
    public Vector2 aPosition1 = new Vector2(3, 3);

    void Update()
    {
        bool barro = Scr_Barro.ralentizar;
        bool colisionAgua = Scr_Barro.agua;

        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), aPosition1, speed * Time.deltaTime);
        if (barro == true && colisionAgua == true)
        {
            slowStop();
        }
    }

    void slowStop()
    {
        for(int contador = 0; contador < (speed * (Time.deltaTime * 20)); contador++)
        {
            speed -= 1;
        }
    }
}