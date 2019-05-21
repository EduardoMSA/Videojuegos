using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Movimiento : MonoBehaviour {

    public float velocidad;
    public Text txt;
    public Camera cam;
    private int puntos;
    private bool estado;
    // Use this for initialization
    void Start () {
        estado = true;
        puntos = 0;
        txt.text = "";
	}
	
	// Update is called once per frame
	void Update () {


        Vector3 pos = cam.WorldToScreenPoint(transform.position);
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        txt.text = "Puntos: " + puntos;

        

        if (pos.x >= Screen.width)
        {
            h = -0.1f;
        }
        if(pos.x <= 0)
        {
            h = 0.1f;
        }
        if(pos.y >= Screen.height)
        {
            v = -0.1f;
        }
        if(pos.y <= 0)
        {
            v = 0.1f;
        }

        if (estado)
        {
            if (pos.y >= Screen.height)
            {
                puntos++;
                estado = false;
            }
        }
        else
        {
            if (pos.y <= 0)
            {
                puntos++;
                estado = true;
            }
        }

        transform.Translate(velocidad * h * Time.deltaTime,
                            velocidad * v * Time.deltaTime,
                            0,
                            Space.World);
        
    }

    void OnCollisionEnter(Collision collision)
    {
        puntos--;
    }
}
