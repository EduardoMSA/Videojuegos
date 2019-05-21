using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour {
    public GameObject proyectil;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(-h * 10 * Time.deltaTime,
                             v * 10 * Time.deltaTime,
                             0);
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayito = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(rayito, out hit))
            {
                print(hit.point);
                Vector3 inicio = new Vector3(0, 0, 0);
                proyectil.transform.LookAt(inicio);
                Vector3 punto = hit.point;
                //Vector3 punto2 = new Vector3();
                proyectil.transform.LookAt(punto);
                Instantiate(proyectil, transform.position, proyectil.transform.rotation);
            }
        }
	}

    
}
