using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilEnemigo : MonoBehaviour {
    private Vector3 point;
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        float x = Random.Range(-8.0f, 8.0f);
        float y = Random.Range(0.0f, 4.0f);
        float z = 58f;
        point = new Vector3(x, y, z);
        transform.LookAt(point);
        rb.AddForce(transform.forward * 15, ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}


