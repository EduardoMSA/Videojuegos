using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

    private Rigidbody rb;
    

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up*10, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
