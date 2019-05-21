using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simbolo {

    private string nombre;
    //propiedades
    //java tenia getters y setters
    //propiedades

    public string Nombre
    {
        private set
        {
            nombre = value;
        }
        get
        {
            return nombre;
        }
    }

    public Simbolo(string nombre)
    {
        this.nombre = nombre;
        //Nombre=nombre
        //this.Nombre=nombre
        Debug.Log(Nombre);
    }


    
}
