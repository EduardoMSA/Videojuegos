using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {

    public float velocidad;
    float j = 0;
    public GameObject proyectil;
    public Transform pos;
    public Transform boca;
    public Transform[] path;
    public float Threshold;

    private Transform target;
    private int current;
    private IEnumerator ie;
    private Coroutine c;
    // Use this for initialization
    void Start () {
        current = 0;
        target = path[current];
        ie = verificarDistancia();
        c = StartCoroutine(ie);
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target);
        transform.Translate(5 * transform.forward * Time.deltaTime, Space.World);

        float h = Input.GetAxis("Horizontal");
        transform.Translate( h * velocidad * Time.deltaTime,0,0);
        
        if(Input.GetKeyDown(KeyCode.UpArrow) && boca.transform.rotation.eulerAngles.x > 45)
        {
           boca.transform.Rotate(-5, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && boca.transform.rotation.eulerAngles.x < 90)
        {
            boca.transform.Rotate(5, 0, 0);
        }




        float jActual = Input.GetAxis("Jump");
        if(j==0 && jActual == 1)
        {
            Instantiate<GameObject>(proyectil, pos.position, pos.rotation);
        }
        j = jActual;
	}

    private IEnumerator verificarDistancia()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.33f);
            print("CORRUTINA");
            float d = Vector3.Distance(transform.position, target.position);
            print(d);
            if (d < Threshold)
            {
                current++;
                current %= path.Length;
                target = path[current];
            }
        }
    }
}
