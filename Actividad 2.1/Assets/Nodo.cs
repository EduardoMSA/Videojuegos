using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodo : MonoBehaviour {

    public Nodo[] vecinos;
    public List<Nodo> historial;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 1);
        Gizmos.color = Color.red;
        if(vecinos != null && vecinos.Length > 0)
        {
            for(int i = 0; i < vecinos.Length; i++)
            {
                Gizmos.DrawLine(transform.position, vecinos[i].transform.position);
            }
        }
    }
}
