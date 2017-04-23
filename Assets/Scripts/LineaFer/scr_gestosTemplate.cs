﻿using System.Collections.Generic;
using UnityEngine;

public class scr_gestosTemplate : MonoBehaviour
{
    public struct Gesto
    {
        public List<Vector2> dirList;
        public string Name;
    }

    public static List<Gesto> TemplateRunas = new List<Gesto>();
    public scr_gestosTemplate()
    {
        //Triangulo
        Gesto Triangulo1 = new Gesto();
        Triangulo1.Name = "Triangulo";
        Triangulo1.dirList = new List<Vector2>(new Vector2[] { new Vector2(0, 1), new Vector2(1, -1), new Vector2(-1, 0) });
        TemplateRunas.Add(Triangulo1);

        Gesto Triangulo2 = new Gesto();
        Triangulo2.Name = "Triangulo";
        Triangulo2.dirList = new List<Vector2>(new Vector2[] { new Vector2(0, 1), new Vector2(1, -1), new Vector2(-1, -1) });
        TemplateRunas.Add(Triangulo2);

        Gesto Triangulo3 = new Gesto();
        Triangulo3.Name = "Triangulo";
        Triangulo3.dirList = new List<Vector2>(new Vector2[] { new Vector2(0, 1), new Vector2(1, -1), new Vector2(-1, 1) });
        TemplateRunas.Add(Triangulo3);

        //Cuadrado
        Gesto Cuadrado1 = new Gesto();
        Cuadrado1.Name = "Cuadrado";
        Cuadrado1.dirList = new List<Vector2>(new Vector2[] {new Vector2(0, 1), new Vector2(1, 0), new Vector2(0, -1), new Vector2(-1, 0)});
        TemplateRunas.Add(Cuadrado1);

        Gesto Cuadrado2 = new Gesto();
        Cuadrado2.Name = "Cuadrado";
        Cuadrado2.dirList = new List<Vector2>(new Vector2[] {new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, -1), new Vector2(-1, -1)});
        TemplateRunas.Add(Cuadrado2);

        Gesto Cuadrado3 = new Gesto();
        Cuadrado3.Name = "Cuadrado";
        Cuadrado3.dirList = new List<Vector2>(new Vector2[] {new Vector2(0, 1), new Vector2(1, -1), new Vector2(0, -1), new Vector2(-1, 1)});
        TemplateRunas.Add(Cuadrado3);
    }
}