using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour {

    public float velocidad;
    private int direccion;
    public Camera cam;

	// Use this for initialization
	void Start () {
        direccion = 1;
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 pos = cam.WorldToScreenPoint(transform.position);

        if (pos.x >= Screen.width)
        {
            direccion = -1;
        }
        if (pos.x <= 0)
        {
            direccion = 1;
        }

        transform.Translate(velocidad * direccion * Time.deltaTime,
                            0,
                            0,
                            Space.World);

    }
}
