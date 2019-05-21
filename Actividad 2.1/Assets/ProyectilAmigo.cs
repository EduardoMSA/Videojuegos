using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilAmigo : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 10, ForceMode.Impulse);
        //StartCoroutine(tiempoDeVida());
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

}
