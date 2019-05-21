using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//packages en java - namespaces
//C# - parecido a java
//.NET


    //toto el código que queramos agregar a un gameobject debe heredar de monobehavior
    // los  :  demuestran herencia
public class Movimiento : MonoBehaviour {

    //ciclo de vida
    // - serie de eventos que se ejecutan en momentos especificos de la vida de un script

    //Corre al inicio 1 sola vez en todos los casos
    void Awake()
    {
        print("Mensaje de AWAKE");
    
    }

    // Corre 1 vez después de TODOS los AWAKEs
    //Corre solo si el objeto está habilitado (palomita en Unity)
    void Start () {
        //Debug.log para imprimir en Unity
        Debug.Log("Mensaje de Start");
	}
	
	// El juego funciona como un loop gigante
    // lógica -> gráficos - (repetir n veces)
    //FPS - frames per second
    // - cuantas veces se hizo el proceso lógica -> gráficos en 1 segundo
    // realtime fps - 30
    // deseable - >=60
	void Update () {

        //lo que este aqui corre fps veces
        //queremos que este metodo sea lo más puro posible

        //2 cosas para este metodo
        // - input: respnde lo más cercano posible a la interacción
        if (Input.GetKeyDown(KeyCode.A))
        {
            print("frame anterior estaba suelta, este frame está presionada");
        }
        if (Input.GetKey(KeyCode.A))
        {
            print("frame anterior estaba presionada, este frame sigo");
            transform.Translate(0.05f, 0, 0);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            print("frame anterior estaba presionado, este ya no");
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(-0.05f, 0, 0);
        }

        //mismos metodos para los botones del mause que para el keyboard
        if (Input.GetMouseButtonDown(0))
        {
            print("piu, piu");
            print(Input.mousePosition);
        }



        // - movimiento: lo más fluido posible
       // Debug.Log("Update"); // operación no bloquea, no se detiene la ejecición al imprimir, desecha algunos mensajes

        //componentes - piezas que conforman el game object
        //transform.Translate(0.01f, 0, 0); //mueve el objeto
		
	}


    //seejecuta una vez por loop
    // después de todos los update
    void LateUpdate()
    {
        //Raro usarlo
       // Debug.Log("LateUpdate");
    }

    //se puede poner la lógica aquí en vez del Update
    //Se ejecuta una configurada cantidad de updates
    //preferible usar el update
    void FixedUpdate()
    {
        //Debug.Log("Fixed Update");
    }
}
