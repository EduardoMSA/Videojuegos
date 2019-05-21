using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodo : MonoBehaviour {

    public Nodo[] vecinos;
    public List<Nodo> historial;

    public float g, h;
    //properties
    public float F
    {
        get
        {
            return g + h;
        }
  
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //2 metodos / eventos
    //gizmos - iconos y graficos que sirven de comunicacion con developer
    //NO salen en el juego 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 1);

        if(vecinos != null && vecinos.Length > 0)
        {
            for(int i=0; i < vecinos.Length; i++)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, vecinos[i].gameObject.transform.position);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(transform.position, 1);
    }

}
